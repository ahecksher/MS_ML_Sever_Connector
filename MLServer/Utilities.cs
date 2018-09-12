using System.Data;
using Newtonsoft.Json.Linq;

namespace MLServer
{
    public class Utilities
    {
        public static DataTable JsonToDataTable(string Name, object json)
        {
            var dataTable = new DataTable();

            switch (json.GetType().Name)
            {
                case "JObject":
                    dataTable = JObjectToDataTable(json);
                    break;
                case "JArray":
                    dataTable = JArrayToDataTable(json);
                    break;
            }

            dataTable.TableName = Name;

            return dataTable;
        }
        private static DataTable JObjectToDataTable(object json)
        {
            var jsonTable = new JObject();

            jsonTable = JObject.Parse(json.ToString());

            var newDt = new DataTable();

            var firstColumn = true;

            foreach (var jsonCol in jsonTable.Children())
            {
                var col = new DataColumn();
                col.ColumnName = jsonCol.Path.ToString();

                foreach (var i in jsonCol.Children())
                {
                    var curRow = 0;
                    foreach (var value in i.Children())
                    {
                        

                        if (curRow == 0)
                        {
                            col.DataType = GetDotNetType(value);
                            newDt.Columns.Add(col);
                        }

                        if (firstColumn)
                        {
                            var newRow = newDt.NewRow();

                            newRow[jsonCol.Path] = value.ToString();
                            newDt.Rows.Add(newRow);
                        }
                        else
                        {
                            newDt.Rows[curRow][jsonCol.Path] = value.ToString();

                        }
                        curRow++;
                    }

                    firstColumn = false;
                }

            }

            return newDt;
        }

        private static DataTable JArrayToDataTable(object json)
        {
            var jsonTable = new JArray();

            jsonTable = JArray.Parse(json.ToString());

            var newDt = new DataTable();

            foreach (var jsonCol in jsonTable.Children())
            {
                var col = new DataColumn();
                col.ColumnName = jsonCol.Path.ToString();

                col.DataType = GetDotNetType(jsonCol);

                newDt.Columns.Add(col);

                var newRow = newDt.NewRow();

                newRow[jsonCol.Path] = jsonCol.ToString();

                newDt.Rows.Add(newRow);
            }

            return newDt;
        }

        private static System.Type GetDotNetType(JToken value)
        {
            switch (value.Type)
            {
                case JTokenType.Float:
                    return typeof(decimal);
                case JTokenType.Boolean:
                    return typeof(bool);
                case JTokenType.Integer:
                    return typeof(int);
                case JTokenType.Date:
                    return typeof(System.DateTime);
                default:
                    return typeof(string);
            }
        }
    }
}
