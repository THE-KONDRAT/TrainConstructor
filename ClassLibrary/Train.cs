using System;
using System.Collections.Generic;

namespace ClassLibrary.Train
{
    public class Train
    {
        public string Number { get; set; }
        public List<ClassLibrary.Train.Wagon.Wagon> Wagons { get; set; }

        public Train()
        {

        }

        public Train(string number)
        {
            Number = number;
        }

        public Train(string number, List<ClassLibrary.Train.Wagon.Wagon> wagons)
        {
            Number = number;
            Wagons = wagons;
        }

        /// <summary>
        /// Method to add wagon into the list of wagons
        /// </summary>
        /// <param name="wagon"></param>
        public virtual void AddWagon(ClassLibrary.Train.Wagon.Wagon wagon)
        {
            if (Wagons == null)
            {
                Wagons = new List<Wagon.Wagon>();
            }
            Wagons.Add(wagon);
        }

        /// <summary>
        /// Method to clear list of wagons
        /// </summary>
        public virtual void ClearWagons()
        {
            if (Wagons == null)
            {
                Wagons = new List<Wagon.Wagon>();
            }
            Wagons.Clear();
        }

        #region train string
        public string GetTrainString()
        {
            return GetTrainString(this);
        }

        /// <summary>
        /// Method to create string with train data
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public static string GetTrainString(ClassLibrary.Train.Train train)
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
                result += $"{Tabs(wagonTabs + cargoTabs)}{i}. — {c.Number}: {c.Name}";
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
        #endregion
    }
}
