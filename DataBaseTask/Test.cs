using DataBaseTask.Models;
using DataBaseTask.Utils;
using MySql.Data.MySqlClient;

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
        
        public void SqlRequestsTest()
        {
            Log.Info("Test case started");
            model = ModelUtils.GetSqlRequestModel("MinimalWorkTime");
            reader = DataBase.SendRequest(model.request);
            Assert.IsTrue(ResponseParser.ParseToLog(reader, model.columnsNames));
            Log.Info("Step 1 completed");

            model = ModelUtils.GetSqlRequestModel("UniqueTestsCount");
            reader = DataBase.SendRequest(model.request);
            Assert.IsTrue(ResponseParser.ParseToLog(reader, model.columnsNames));
            Log.Info("Step 2 completed");

            model = ModelUtils.GetSqlRequestModel("TestsAfterDate");
            reader = DataBase.SendRequest(model.request);
            Assert.IsTrue(ResponseParser.ParseToLog(reader, model.columnsNames));
            Log.Info("Step 3 completed");

            model = ModelUtils.GetSqlRequestModel("TestsInDifferentBrowsers");
            reader = DataBase.SendRequest(model.request);
            Assert.IsTrue(ResponseParser.ParseToLog(reader, model.columnsNames));
            Log.Info("Step 4 completed. Test case finished successfully.");
        }
    }
}