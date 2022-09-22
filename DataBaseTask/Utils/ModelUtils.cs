using DataBaseTask.Constants;
using DataBaseTask.Models;

namespace DataBaseTask.Utils
{
    public class ModelUtils
    {
        public static RequestModel GetSqlRequestModel(string requestName)
        {
            Test.Log.Info("Model created");
            var json = File.ReadAllText(ProjectConstants.PathToRequestData);
            var jsonObj = JsonUtils.ParseToJsonObject(json);
            var jsonString = jsonObj[requestName].ToString();
            var request = JsonUtils.ReadJsonData<List<RequestModel>>(jsonString);
            return request[0];
        }
    }
}
