using System;
using System.Collections.Generic;
using MMLServer;
using MMLServer.Models;
using Newtonsoft.Json;
using System.Data;
using System.IO;


namespace MLServer
{
    public class Session : Utilities
    {
        public String ServerUri { get { return serverUri; } }
        private String serverUri { get; set; }
        
        public String ServerUser { get { return serverUser; } }
        private String serverUser { get; set; }

        public String ServerPassword { get { return serverPassword; } }
        private String serverPassword { get; set; }

        public RuntimeType Language { get; set; }
        private String sessionId { get; set; }
        public MRSServer Client { get; set; }
        public CreateSessionResponse Response { get; set; }

        public List<WorkspaceObject> InputParameters { get { return inputParameters; } }
        private List<WorkspaceObject> inputParameters { get; set; }

        public List<string> OutputParameters { get { return outputParameters; } }
        private List<string> outputParameters { get; set; }

        public Boolean Success { get { return success; } }
        private Boolean success { get; set; }

        public String ErrorMessage { get { return errorMessage; } }
        private String errorMessage { get; set; }

        public DataSet OutputDataSet { get { return outputDataSet; } }
        private DataSet outputDataSet { get; set; }

        public Dictionary<string, Stream> WorkspaceFiles { get { return workspaceFiles; } }
        private Dictionary<string, Stream> workspaceFiles { get; set; }

        public TimeSpan Timeout { get { return timeout; } }
        private TimeSpan timeout { get; set; }

        public String UserName { get { return userName; } }
        private String userName { get; set; }


        public Session()
        {
            inputParameters = new List<WorkspaceObject>();
            outputParameters = new List<string>();
            outputDataSet = new DataSet();
            workspaceFiles = new Dictionary<string, Stream>();
            Language = RuntimeType.R;
            timeout = TimeSpan.FromMinutes(30);
        }

        private void AddFiles(ExecuteResponse executeResponse)
        {
            var workspaceFilesResponse = executeResponse.ChangedFiles;

            foreach (var file in workspaceFilesResponse)
            {
                workspaceFiles.Add(file, Client.GetSessionFile(Response.SessionId, file));
            }
        }

        public void PopulateResults(ExecuteResponse executeResponse)
        {
            AddOutputs(executeResponse);
            AddFiles(executeResponse);
            UpdateStatus(executeResponse);
        }
        private void AddOutputs(ExecuteResponse executeResponse)
        {
            if (OutputParameters.Count != 0)
            {
                foreach (var output in executeResponse.OutputParameters)
                {
                    outputDataSet.Tables.Add(Utilities.JsonToDataTable(output.Name, output.Value));
                }
            }
        }

        private void UpdateStatus(ExecuteResponse executeResponse)
        {
            success = executeResponse.Success.Value;
            errorMessage = executeResponse.ErrorMessage;
        }

        private string GetAccessToken()
        {
            var client = new MRSServer(new Uri(serverUri));

            var loginRequest = new LoginRequest(serverUser, serverPassword);
            var loginResponse = client.Login(loginRequest);

            return loginResponse.AccessToken;
        }

        public void LogOut()
        {
            Client.CloseSessionByForce(Response.SessionId);            
        }

        public void LogIn()
        {
            var client = new MRSServer(new Uri(serverUri));

            var accessToken = GetAccessToken();
            var headers = client.HttpClient.DefaultRequestHeaders;

            client.HttpClient.Timeout = timeout;            

            headers.Remove("Authorization");
            headers.Add("Authorization", $"Bearer {accessToken}");

            Client = client;

            var createSessionRequest = new CreateSessionRequest()
            {
                Name = userName,
                RuntimeType = Language
            };
            Response = client.CreateSession(createSessionRequest);
        }

        public void AddInputParameter(string Name, object Value)
        {
            var workspaceObject = new WorkspaceObject();

            workspaceObject.Name = Name;

            switch (Value.GetType().Name)
            {
                case "Boolean":
                    workspaceObject.Value = (Boolean)Value;
                    break;
                case "DataTable":
                case "List`1":
                    workspaceObject.Value = JsonConvert.SerializeObject(Value, Formatting.Indented);
                    break;
                case "DateTime":
                    workspaceObject.Value = (DateTime)Value;
                    break;
                case "Decimal":
                    workspaceObject.Value = (decimal)Value;
                    break;
                case "Double":
                    workspaceObject.Value = (double)Value;
                    break;
                case "Int16":
                case "Int32":
                case "Int64":
                    workspaceObject.Value = (int)Value;
                    break;
                case "String":
                    workspaceObject.Value = (string)Value;
                    break;
                case "Dictionary`2":
                    workspaceObject.Value = JsonConvert.SerializeObject((Dictionary<string, object>)Value);
                    break;
                default:
                    workspaceObject.Value = JsonConvert.SerializeObject(Value);
                    break;
            }

            inputParameters.Add(workspaceObject);
        }

        public void AddOutputParameter(string Name)
        {
            outputParameters.Add(Name);
        }
    }
}
