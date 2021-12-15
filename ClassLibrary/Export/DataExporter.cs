using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary.Export
{
    public static class DataExporter
    {
        /// <summary>
        /// Method to save text string to file
        /// </summary>
        /// <param name="contents">String to save</param>
        /// <param name="filePath"></param>
        /// <param name="overwrite"></param>
        public static void SaveTextToFile(string contents, string filePath, bool overwrite)
        {
            string validationError = ValidateFilePath(filePath, overwrite);
            if (validationError != null)
            {
                throw new Exception(validationError);
            }

            File.WriteAllText(filePath, contents);
        }

        /// <summary>
        /// Method to validate file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="overwrite"></param>
        /// <returns>Error string. If null - all is OK.</returns>
        private static string ValidateFilePath(string filePath, bool overwrite)
        {
            string error = null;

            if (string.IsNullOrWhiteSpace(filePath))
            {
                return "File path is empty.";
                //throw new Exception("File path is empty.");
            }

            //Check if file exists
            bool fileExists = false;
            try
            {
                if (File.Exists(filePath) || Directory.Exists(filePath))
                {
                    fileExists = true;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            if (fileExists)
            {
                FileAttributes attr = File.GetAttributes(filePath);
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    return "Wrong path: it's already existed directory.";
                    //throw new Exception("Wrong file path^ is directory.");
                }

                if (!overwrite)
                {
                    return $"File {filePath} is already exists. Overwriting denied";
                    //throw new Exception($"File{filePath} is already exists. Overwriting denied");
                }

            }

            return error;
        }


        #region JSON
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
            SaveTextToFile(jstring, filePath, overwrite);
        }
        #endregion

        #region Excel
        /// <summary>
        /// Method to serialize and save object to json file
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <param name="overwrite"></param>
        public static void SaveToExcel(object obj, string filePath, bool overwrite)
        {
            string validationError = ValidateFilePath(filePath, overwrite);
            if (validationError != null)
            {
                throw new Exception(validationError);
            }

            //Excel export realization
        }
        #endregion
    }
}
