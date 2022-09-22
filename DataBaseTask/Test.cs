using DataBaseTask.Models;
using DataBaseTask.Utils;
using MySql.Data.MySqlClient;
using RestApiTask.Utils;

namespace DataBaseTask
{
    public class Test
    {
        public static Logger Log => Logger.Instance;
        private MySqlDataReader reader;
        private RequestModel model;

        [SetUp]
        public void Setup()
        {
            FileReader.ClearLogFile();
        }

        [Test]
        [TestCaseSource(nameof(PrepareToTest))]
        public void SqlRequestsTest()
        {
            model = ModelUtils.GetSqlRequestModel("MinimalWorkTime");
            reader = DataBase.SendRequest(model.request);
            ResponseParser.ParseToLog(reader, model.columnsNames);
        }

        public static IEnumerable<object[]> PrepareToTest()
        {
            FileReader.ClearLogFile();

            List<ProductModel> modelsList = FileReader.GetModels();

            foreach (var model in modelsList)
            {
                yield return new[] { model };
            }
        }
    }
}