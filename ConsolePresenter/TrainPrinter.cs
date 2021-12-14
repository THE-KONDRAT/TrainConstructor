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
                trainString = train.Wagons == null ? "Train has no wagons" : train.Wagons.Count < 1 ? "Train has no wagons" : CreateTrainString(train);
            }
            Console.WriteLine(trainString);
        }

        /// <summary>
        /// Method to create string with train data
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        private static string CreateTrainString(ClassLibrary.Train.Train train)
        {
            string result = string.Empty;

            /*if (train.Wagons != null)
            {
                
            }*/
            result = $"Train — {train.Number}";
            int i = 0;
            foreach (ClassLibrary.Train.Wagon.Wagon wagon in train.Wagons)
            {
                result += Environment.NewLine;
                i++;
                string wagonType = wagon.GetType().Name;
                result += $"{Tabs(1)}{i}. — {wagonType}";

                result += Environment.NewLine + CreateWagonCargoString(wagon.Cargo, 1, 1);
                /*int j = 0;
                foreach (ClassLibrary.Cargo cargo in wagon.Cargo)
                {
                    result += Environment.NewLine;
                    j++;
                    result += $"{Tabs(2)}{j}. — {cargo.Number}:{cargo.Name}";
                }*/
            }


            return result;
        }

        /// <summary>
        /// Method to create string of wagon cargo data
        /// </summary>
        /// <param name="cargo"></param>
        /// <param name="wagonTabs"></param>
        /// <param name="cargoTabs"></param>
        /// <returns></returns>
        private static string CreateWagonCargoString(List<ClassLibrary.Cargo> cargo, uint wagonTabs, uint cargoTabs)
        {
            string result = $"{Tabs(wagonTabs + cargoTabs)}Empty";

            if (cargo == null)
            {
                return result;
            }
            else if (cargo.Count < 1)
            {
                return result;
            }
            result = string.Empty;
            int i = 0;
            foreach (ClassLibrary.Cargo c in cargo)
            {
                if (i != 0)
                {
                    result += Environment.NewLine;
                }
                i++;
                result += $"{Tabs(wagonTabs + cargoTabs)}{i}. — {c.Number}:{c.Name}";
                if (c.GetType() == typeof(ClassLibrary.Container))
                {
                    result += Environment.NewLine;
                    result += CreateWagonCargoString(((ClassLibrary.Container)c).Cargo, wagonTabs + cargoTabs, cargoTabs);
                }
            }


            return result;
        }

        /// <summary>
        /// Method to create string of tabs
        /// </summary>
        /// <param name="n">Count of tabs</param>
        /// <returns></returns>
        private static string Tabs(uint n)
        {
            return new String('\t', (int)n);
        }
    }
}
