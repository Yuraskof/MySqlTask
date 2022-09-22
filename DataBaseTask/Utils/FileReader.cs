using DataBaseTask.Constants;

namespace DataBaseTask.Utils
{
    public static class FileReader
    {
        public static string ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                Test.Log.Info(string.Format("File {0} read", path));
                return sr.ReadToEnd();
            }
        }

        public static void ClearLogFile()
        {
            FileInfo file = new FileInfo(ProjectConstants.PathToLogFile);

            if (file.Exists)
            {
                file.Delete();
                Test.Log.Info("Log file deleted");
            }
        }
    }
}