using MySql.Data.MySqlClient;

namespace DataBaseTask.Utils
{
    public class DataBase
    {
        public static MySqlConnection mySqlDb;
        const string host = "localhost";
        const string user = "root";
        const string database = "union_reporting";
        const string password = "2146407";
        static string connect;

        private static void ConnectToDataBase()
        {
            connect = "Database=" + database + ";Datasource=" + host + ";User=" + user + ";Password=" + password;
            mySqlDb = new MySqlConnection(connect);
            mySqlDb.Open();
        }
        
        public static MySqlDataReader SendRequest(string request)
        {
            ConnectToDataBase();

            MySqlCommand command = new MySqlCommand(request, mySqlDb);

            MySqlDataReader reader = command.ExecuteReader();
            
            return reader;
        }
    }
}
