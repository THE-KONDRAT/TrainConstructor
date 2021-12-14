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
    }
}
