namespace DataBaseTask.Utils
{
    public class StringUtil
    {
        public static List<string> GetSeparatedStrings(string text, string splitter)
        {
            Test.Log.Info("strings separated");
            string[] separatedData = text.Split(splitter);

            List<string> userInfoFields = new List<string>();

            for (int i = 0; i < separatedData.Length; i++)
            {
                userInfoFields.Add(separatedData[i]);
            }
            return userInfoFields;
        }
    }
}
