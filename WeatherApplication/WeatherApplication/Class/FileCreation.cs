using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WeatherApplication.Class
{
    public class FileCreation
    {
        public void CreateFileByCityName(string data, string cityName)
        {
            string filename = String.Format(@"{0}_{1}.txt", cityName, DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
            string path = Path.Combine(@"C:\Documents", filename);

            File.WriteAllText(path, data);
        }
    }
}