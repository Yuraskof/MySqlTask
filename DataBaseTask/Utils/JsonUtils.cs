using DataBaseTask.Constants;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask.Utils
{
    public class JsonUtils
    {
        public static JObject ParseToJsonObject(string content)
        {
            Test.Log.Info("Start parsing to json object");
            return JObject.Parse(content);
        }

        public static T ReadJsonData<T>(string content)
        {
            Test.Log.Info("Start deserializing");
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
