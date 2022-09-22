using MySql.Data.MySqlClient;

namespace DataBaseTask.Utils
{
    public class ResponseParser
    {
        public static bool ParseToLog(MySqlDataReader reader, string columnNames)
        {
            Test.Log.Info("Start parsing");
            try
            {
                int columnsCount = StringUtil.GetSeparatedStrings(columnNames, "\t").Count;

                Test.Log.Info(columnNames);

                while (reader.Read())
                {
                    switch (columnsCount)
                    {
                        case 1:
                            Test.Log.Info(reader[0].ToString());
                            continue;
                        case 2:
                            Test.Log.Info(string.Format(reader[0] + "\t" + reader[1]));
                            continue;
                        case 3:
                            Test.Log.Info(string.Format(reader[0] + "\t" + reader[1] + "\t" + reader[2]));
                            continue;
                    }
                }
                reader.Close();
                DataBase.mySqlDb.Close();
                return true;
            }
            catch (Exception e)
            {
                Test.Log.Error("Parse error");
                return false;
            }
        }
    }
}
