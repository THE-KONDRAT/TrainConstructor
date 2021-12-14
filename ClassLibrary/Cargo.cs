using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Cargo
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public Cargo()
        {

        }

        public Cargo(string number, string name)
        {
            Number = number;
            Name = name;
        }

        /*public virtual void AddCargo(string number, string name)
        {
            Number = number;
            Name = name;
        }*/
    }

    public sealed class Container : Cargo
    {
        public List<Cargo> Cargo { get; set; }

        public Container()
        {

        }

        public Container(string number, string name)
        {
            Number = number;
            Name = name;
        }

        public Container(string number, string name, List<Cargo> cargo)
        {
            Number = number;
            Name = name;
            AddCargo(cargo);
        }


        /// <summary>
        /// Method to add cargo into the container
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        public void AddCargo(string number, string name)
        {
            Cargo cargo = new Cargo(number, name);

            AddCargo(cargo);
        }

        /// <summary>
        /// Method to add cargo into the container
        /// </summary>
        /// <param name="cargo"></param>
        public void AddCargo(Cargo cargo)
        {
            if (Cargo == null)
            {
                Cargo = new List<Cargo>();
            }

            Cargo.Add(cargo);
        }

        /// <summary>
        /// Method to add cargo into the container
        /// </summary>
        /// <param name="cargo"></param>
        public void AddCargo(List<Cargo> cargo)
        {
            if (Cargo == null)
            {
                Cargo = cargo;
            }
            else
            {
                Cargo.AddRange(cargo);
            }
        }
    }

}
