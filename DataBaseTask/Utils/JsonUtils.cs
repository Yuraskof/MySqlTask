using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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

        public static T ReadJsonDataFromPath<T>(string path)
        {
            Test.Log.Info("Start deserializing");
            return JsonConvert.DeserializeObject<T>(FileReader.ReadFile(path));
        }
    }
}
