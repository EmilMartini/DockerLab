using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugReporter.Database
{
    public class DatabaseClient
    {
        private string localPath;
        private string currentDir;
        private string fileName;

        public DatabaseClient()
        {
            currentDir = Environment.CurrentDirectory;
        }

        public void ReadFromFile()
        {
            //Read file and convert to json
        }

        public void SaveToFile()
        {
            //Save and overwrite current file
        }  
    }
}
