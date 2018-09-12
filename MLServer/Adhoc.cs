using System;
using MMLServer;
using MMLServer.Models;

namespace MLServer
{
    public class Adhoc : Session
    {
        public String Code { get; set; }

        public Adhoc()
        {

        }
        public void RunScript()
        {
            LogIn();
            var executeRequest = new ExecuteRequest();
            executeRequest.Code = Code;
            if (InputParameters.Count != 0)
            {
                executeRequest.InputParameters = InputParameters;
            }

            if (OutputParameters.Count != 0)
            {
                executeRequest.OutputParameters = OutputParameters;
            }

            var executeResponse = Client.ExecuteCode(Response.SessionId, executeRequest);

            if (executeResponse.Success.Value)
            {
                PopulateResults(executeResponse);
                LogOut();
            }
            else
            {
                LogOut();
                throw new Exception(executeResponse.ErrorMessage);
            }
        }
    }
}
