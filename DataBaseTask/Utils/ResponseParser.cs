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
        public static void ParseToLogMinimalTimeWorkResponse(MySqlDataReader reader)
        {
            Test.Log.Info("ProjectName\tTestName\tMinimalWorkingTime");

            while (reader.Read())
            {
                string projectName = reader[0].ToString();
                string testName = reader[1].ToString();
                string minWorkingTime = reader[2].ToString();

                Test.Log.Info(string.Format("{0}\t{1}\t{2}", projectName, testName, minWorkingTime));
            }
            reader.Close();
            DataBase.mySqlDb.Close();
        }

        public static void ParseToLogUniqueTestsOnProject(MySqlDataReader reader)
        {
            Test.Log.Info("ProjectName\tUniqueTestsCount");

            while (reader.Read())
            {
                string projectName = reader[0].ToString();
                string testsCount = reader[1].ToString();
                
                Test.Log.Info(string.Format("{0}\t{1}", projectName, testsCount));
            }
            reader.Close();
            DataBase.mySqlDb.Close();
        }

        public static void Parse(MySqlDataReader reader)
        {
            Test.Log.Info("ProjectName\tUniqueTestsCount");

            while (reader.Read())
            {
                string projectName = reader[0].ToString();
                //string testsCount = reader[1].ToString();

                Test.Log.Info(string.Format("{0}", projectName));
            }
            reader.Close();
            DataBase.mySqlDb.Close();
        }

    }
}
