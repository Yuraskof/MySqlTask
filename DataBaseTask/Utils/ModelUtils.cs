using DataBaseTask.Constants;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DataBaseTask.Models;

namespace DataBaseTask.Utils
{
    public class ModelUtils
    {
        public static RequestModel GetSqlRequestModel(string requestName)
        {
            var json = File.ReadAllText(ProjectConstants.PathToRequestData);
            var jsonObj = JsonUtils.ParseToJsonObject(json);
            var jsonString = jsonObj[requestName].ToString();
            var request = JsonUtils.ReadJsonData<List<RequestModel>>(jsonString);
            return request[0];
        }
    }
}
