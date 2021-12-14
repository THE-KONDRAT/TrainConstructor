using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Train.Wagon
{
    public class Wagon
    {
        public List<ClassLibrary.Cargo> Cargo { get; set; }

        public Wagon()
        {

        }

        public Wagon(Cargo cargo)
        {
            AddCargo(cargo);
        }

        /// <summary>
        /// Method to add cargo into the wagon
        /// </summary>
        /// <param name="cargo"></param>
        public virtual void AddCargo(Cargo cargo)
        {
            if (Cargo == null)
            {
                Cargo = new List<Cargo>();
            }

            Cargo.Add(cargo);
        }

        internal virtual void ClearCargo(Cargo cargo)
        {
            if (Cargo == null)
            {
                Cargo = new List<Cargo>();
            }

            Cargo.Clear();
        }
    }

    public class FlatWagon : Wagon
    {
        public FlatWagon()
        {

        }

        public FlatWagon(Cargo cargo)
        {
            AddCargo(cargo);
        }
    }

    public class CoveredGoodsWagon : Wagon
    {
        public CoveredGoodsWagon()
        {

        }

        public CoveredGoodsWagon(Cargo cargo)
        {
            AddCargo(cargo);
        }

        public override void AddCargo(Cargo cargo)
        {
            if (cargo.GetType() == typeof(ClassLibrary.Container))
            {
                throw new Exception("You can not add this cargo to this wagon");
            }
            base.AddCargo(cargo);
        }
    }

    public class OpenWagon : Wagon
    {
        public OpenWagon()
        {

        }

        public OpenWagon(Cargo cargo)
        {
            AddCargo(cargo);
        }
    }

    public class TankWagon : Wagon
    {
        public TankWagon()
        {

        }

        public TankWagon(Cargo cargo)
        {
            AddCargo(cargo);
        }

        public override void AddCargo(Cargo cargo)
        {
            if (cargo.GetType() == typeof(ClassLibrary.Container))
            {
                throw new Exception("You can not add this cargo to this wagon");
            }
            base.AddCargo(cargo);
        }
    }
}
