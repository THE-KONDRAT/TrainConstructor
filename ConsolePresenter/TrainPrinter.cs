using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePresenter
{
    /// <summary>
    /// Method to print train data to console
    /// </summary>
    internal static class TrainPrinter
    {
        internal static void PrintTrain(ClassLibrary.Train.Train train)
        {
            string trainString = string.Empty;

            if (train == null)
            {
                trainString = "No train exists";
            }
            else
            {
                trainString = train.Wagons == null ? "Train has no wagons" : train.Wagons.Count < 1 ? "Train has no wagons" : train.GetTrainString();
            }
            Console.WriteLine(trainString);
        }
    }
}
