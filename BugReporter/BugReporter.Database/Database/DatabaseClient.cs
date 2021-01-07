using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BugReporter.Database
{
    public class DatabaseClient
    {
        private string fileName = "BugReporter.json";

        public List<Bug> ReadFromFile()
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                List<Bug> items = JsonConvert.DeserializeObject<List<Bug>>(json);
                return items;
            }
        }

        public void SaveToFile(string contentBody)
        {
            string jsonString = JsonConvert.SerializeObject(contentBody);
            File.WriteAllText(fileName, jsonString);
        }  
    }
}
