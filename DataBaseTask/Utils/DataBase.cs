using DataBaseTask.Constants;
using DataBaseTask.Models;
using MySql.Data.MySqlClient;

namespace DataBaseTask.Utils
{
    public class DataBase
    {
        private static TestData testData = JsonUtils.ReadJsonDataFromPath<TestData>(ProjectConstants.PathToTestData);

        public static MySqlConnection mySqlDb;
        static string connect;

        private static void ConnectToDataBase()
        {
            Test.Log.Info("Connect to data base");
            connect = "Database=" + testData.database + ";Datasource=" + testData.host + ";User=" + testData.user + ";Password=" + testData.password;
            mySqlDb = new MySqlConnection(connect);
            mySqlDb.Open();
        }
        
        public static MySqlDataReader SendRequest(string request)
        {
            ConnectToDataBase();

            Test.Log.Info(string.Format("Send request {0}", request));

            MySqlCommand command = new MySqlCommand(request, mySqlDb);

            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}
