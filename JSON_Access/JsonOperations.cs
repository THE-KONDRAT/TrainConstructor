using Newtonsoft.Json;
using System;

namespace JSON_Access
{
    public static class JsonOperations
    {
        private static JsonSerializerSettings GetJSONSetstings()
        {
            return new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
        }

        /// <summary>
        /// Method to serialize and save object to json file
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <param name="overwrite"></param>
        public static void SaveJSON(object obj, string filePath, bool overwrite)
        {
            string jstring = JsonConvert.SerializeObject(obj, Formatting.Indented, GetJSONSetstings());
            FileAccess.FileOperation.SaveTextToFile(jstring, filePath, overwrite);
        }
    }
}
