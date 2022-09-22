using DataBaseTask.Utils;
using MySql.Data.MySqlClient;
using RestApiTask.Utils;

namespace DataBaseTask
{
    public class Test
    {
        public static Logger Log => Logger.Instance;
        private MySqlDataReader reader;

        [SetUp]
        public void Setup()
        {
            FileReader.ClearLogFile();
        }

        [Test]
        public void SqlRequestsTest()
        {
            string request1 = "SELECT project.name, test.name, test.end_time - test.start_time AS MinTime FROM test JOIN project ON project.id = test.project_id ORDER BY project.name, test.name";
            reader = DataBase.SendRequest(request1);
            ResponseParser.ParseToLogMinimalTimeWorkResponse(reader);

            string request2 = "SELECT DISTINCT project.name, COUNT(test.name) FROM test JOIN project ON project.id = test.project_id GROUP BY project.name";
            reader = DataBase.SendRequest(request2);
            ResponseParser.ParseToLogUniqueTestsOnProject(reader);

            string request3 = "SELECT DISTINCT project.name, test.name, test.start_time FROM test JOIN project ON project.id = test.project_id WHERE test.start_time > '2015-11-07 23:59:59' ORDER BY project.name, test.name";
            reader = DataBase.SendRequest(request3);
            ResponseParser.ParseToLogMinimalTimeWorkResponse(reader);

            string request4 = "SELECT COUNT(browser) FROM test WHERE browser = 'Firefox' UNION SELECT COUNT(browser) FROM test WHERE browser = 'Chrome' GROUP BY browser";
            reader = DataBase.SendRequest(request4);
            ResponseParser.Parse(reader);
            Assert.Pass();
        }
    }
}