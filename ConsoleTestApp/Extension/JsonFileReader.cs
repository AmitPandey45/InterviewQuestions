﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp.Extension
{
    public static class JsonFileReader
    {
        public static T ReadJsonDataByFileName<T>(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static T ReadJsonDataByFilePath<T>(string filePath)
        {
            ////using FileStream stream = File.OpenRead(filePath);
            ////return await JsonSerializer.DeserializeAsync<T>(stream);
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<dynamic>(json);
            }
        }
    }
}
