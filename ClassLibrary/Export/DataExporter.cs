using System;

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
        public static void ExportToTextFile(Train.Train train, string filePath, bool overwrite)
        {
            FileAccess.FileOperation.SaveTextToFile(train.GetTrainString(), filePath, overwrite);
        }
        /// <summary>
        /// Method to serialize and save object to json file
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <param name="overwrite"></param>
        public static void ExportToJsonFile(Train.Train train, string filePath, bool overwrite)
        {
            string validationError = FileAccess.FileOperation.ValidateFilePath(filePath, overwrite);
            if (validationError != null)
            {
                throw new Exception(validationError);
            }

            JSON_Access.JsonOperations.SaveJSON(train, filePath, overwrite);
        }
        /// <summary>
        /// Method to serialize and save object to Excel file
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <param name="overwrite"></param>
        public static void ExportToExcel(object obj, string filePath, bool overwrite)
        {
            string validationError = FileAccess.FileOperation.ValidateFilePath(filePath, overwrite);
            if (validationError != null)
            {
                throw new Exception(validationError);
            }

            //Excel export realization using ExcelAccess class
        }
    }
}
