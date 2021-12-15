using System;

namespace ConsolePresenter
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassLibrary.Train.Train train = TestTrain();
            
            TrainPrinter.PrintTrain(train);
            string trainString = TrainPrinter.CreateTrainString(train);

            //Export to text file
            string txtFilePath = "";
            #region Tests
            //Test empty path
            //Error appears
            //ClassLibrary.Export.DataExporter.SaveTextToFile(trainString, "", true);

            //Test create file
            //ClassLibrary.Export.DataExporter.SaveTextToFile(trainString, @"E:\tp.txt", true);

            //Test overwrite denied variant.
            //Exception appears
            //ClassLibrary.Export.DataExporter.SaveTextToFile(trainString, @"E:\tp.txt", false);

            //File without extension
            //We have no restrictions
            //ClassLibrary.Export.DataExporter.SaveTextToFile(trainString, @"E:\tpvb", true);

            //Already existed folder
            //Error: wrong path type
            //ClassLibrary.Export.DataExporter.SaveTextToFile(trainString, @"E:\Новая папка", false);
            #endregion
            //Exception handler needed
            ClassLibrary.Export.DataExporter.SaveTextToFile(trainString, txtFilePath, true);


            //Serialize and export json to file
            string jsonFilePath = @"";
            ClassLibrary.Export.DataExporter.SaveJSON(train, jsonFilePath, true);

            //Export to excel document
            string excelFilePath = "";
            ClassLibrary.Export.DataExporter.SaveToExcel(train, excelFilePath, true);

            /*using (ClassLibrary.DBLogic.InMemoryDB db = new ClassLibrary.DBLogic.InMemoryDB())
            {
                Console.WriteLine("Train created:");
                TrainPrinter.PrintTrain(train);
                db.TrainContext.Trains.Add(train);
                db.TrainContext.SaveChanges();
                Console.WriteLine("Data saved.");

                ClassLibrary.Train.Train trainFromDB = null;
                var trains = db.GetTrains();
                trainFromDB = trains == null ? null : trains.Count > 0 ? trains[0] : null;

                Console.WriteLine("Train from DB:");
                TrainPrinter.PrintTrain(trainFromDB);
            }*/
        }

        /// <summary>
        /// Method to create test train from code
        /// </summary>
        /// <returns></returns>
        private static ClassLibrary.Train.Train TestTrain()
        {
            ClassLibrary.Train.Train train = new ClassLibrary.Train.Train();

            train.Number = "345-123-546-765";

            ClassLibrary.Cargo c1 = new ClassLibrary.Cargo("10-21384", "Box");
            ClassLibrary.Cargo c2 = new ClassLibrary.Cargo("10-21385", "Box");
            ClassLibrary.Cargo c3 = new ClassLibrary.Cargo("65-21383", "Box");
            ClassLibrary.Cargo c4 = new ClassLibrary.Cargo("4-21334", "Box");
            ClassLibrary.Cargo c5 = new ClassLibrary.Cargo("1-61384", "Box");
            ClassLibrary.Cargo c6 = new ClassLibrary.Cargo("10-71389", "Box");
            ClassLibrary.Cargo c7 = new ClassLibrary.Cargo("13-214", "Box");
            ClassLibrary.Container c8 = new ClassLibrary.Container("13-13", "Container");
            ClassLibrary.Cargo cc1 = new ClassLibrary.Cargo("1-4", "Box");
            ClassLibrary.Cargo cc2 = new ClassLibrary.Cargo("21", "Smth");

            ClassLibrary.Container cc3 = new ClassLibrary.Container("1", "Container2");
            cc3.AddCargo(c1);
            cc3.AddCargo("123-qwerty-55", "Small box");
            cc3.AddCargo(c6);
            c8.AddCargo(cc1);
            c8.AddCargo(cc2);
            //Container into another container
            c8.AddCargo(cc3);

            ClassLibrary.Train.Wagon.FlatWagon w1 = new ClassLibrary.Train.Wagon.FlatWagon(c1);
            w1.AddCargo(c2);
            w1.AddCargo(c3);
            w1.AddCargo(c4);
            w1.AddCargo(c5);
            w1.AddCargo(c6);
            w1.AddCargo(c7);
            w1.AddCargo(c8);

            ClassLibrary.Cargo c9 = new ClassLibrary.Cargo("1-84", "Smth1");
            ClassLibrary.Cargo c10 = new ClassLibrary.Cargo("1-85", "Smth2");
            ClassLibrary.Cargo c11 = new ClassLibrary.Cargo("65-3", "Smth3");
            ClassLibrary.Train.Wagon.CoveredGoodsWagon w2 = new ClassLibrary.Train.Wagon.CoveredGoodsWagon();
            w2.AddCargo(c9);
            w2.AddCargo(c10);
            w2.AddCargo(c11);

            ClassLibrary.Cargo c12 = new ClassLibrary.Cargo("--00", "Bottles");
            ClassLibrary.Cargo c13 = new ClassLibrary.Cargo("*9*0*3-2", "Sofa");
            ClassLibrary.Cargo c14 = new ClassLibrary.Cargo("двадцать", "Notebooks");
            ClassLibrary.Train.Wagon.OpenWagon w3 = new ClassLibrary.Train.Wagon.OpenWagon();
            w3.AddCargo(c12);
            w3.AddCargo(c13);
            w3.AddCargo(c14);

            ClassLibrary.Cargo c15 = new ClassLibrary.Cargo("212154687632165574", "Oil");

            ClassLibrary.Train.Wagon.TankWagon w4 = new ClassLibrary.Train.Wagon.TankWagon();
            w4.AddCargo(c15);

            //Container into the tank (error appears)
            //w2.AddCargo(c8);


            train.AddWagon(w1);
            train.AddWagon(w2);
            train.AddWagon(w3);
            train.AddWagon(w4);

            return train;
        }


    }
}
