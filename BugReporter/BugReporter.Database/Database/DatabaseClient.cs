using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BugReporter.Database
{
    public class DatabaseClient
    {
        private string fileName = "BugReporter.json";

        public List<Bug> ReadFromFile()
        {
            try
            {
                using (StreamReader r = new StreamReader(fileName))
                {
                    string json = r.ReadToEnd();
                    List<Bug> items = JsonConvert.DeserializeObject<List<Bug>>(json);
                    return items;
                }
            }
            catch (FileNotFoundException)
            {
                SaveToFile("");
                return new List<Bug>();
            }
        }

        public bool SaveToFile(string contentBody)
        {
            try
            {
                File.WriteAllText(fileName, contentBody);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }  
    }
}
