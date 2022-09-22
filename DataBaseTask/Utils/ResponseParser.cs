using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask.Utils
{
    public class ResponseParser
    {
        public static void ParseToLog(MySqlDataReader reader, string columnNames)
        {
            Test.Log.Info(columnNames);

            int columnsCount = StringUtil.GetSeparatedStrings(columnNames, "\t").Count;

            while (reader.Read())
            {
                switch (columnsCount)
                {
                    case 1:
                        Test.Log.Info(reader[0].ToString());
                        continue;
                    case 2:
                        Test.Log.Info(string.Format(reader[0]+"\t"+ reader[1]));
                        continue;
                    case 3:
                        Test.Log.Info(string.Format(reader[0] + "\t" + reader[1] + "\t" + reader[2]));
                        continue;
                }
            }
            reader.Close();
            DataBase.mySqlDb.Close();
        }

        //public static void ParseToLogUniqueTestsOnProject(MySqlDataReader reader)
        //{
        //    Test.Log.Info("");

        //    while (reader.Read())
        //    {
        //        string projectName = reader[0].ToString();
        //        string testsCount = reader[1].ToString();
                
        //        Test.Log.Info(string.Format("{0}\t{1}", projectName, testsCount));
        //    }
        //    reader.Close();
        //    DataBase.mySqlDb.Close();
        //}

        //public static void Parse(MySqlDataReader reader)
        //{
        //    Test.Log.Info("ProjectName\tUniqueTestsCount");

        //    while (reader.Read())
        //    {
        //        string projectName = reader[0].ToString();
        //        //string testsCount = reader[1].ToString();

        //        Test.Log.Info(string.Format("{0}", projectName));
        //    }
        //    reader.Close();
        //    DataBase.mySqlDb.Close();
        //}

    }
}
