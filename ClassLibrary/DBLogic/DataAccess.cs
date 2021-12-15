using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.DBLogic
{
    public class DataAccess
    {
        
    }

    public class InMemoryDB : IDisposable
    {
        public TrainContext TrainContext { get; set; }

        public InMemoryDB()
        {
            TrainContext = InitDB();
        }

        public static TrainContext InitDB()
        {
            var options = new DbContextOptionsBuilder<TrainContext>().UseInMemoryDatabase(databaseName: "TrainsDB").Options;
            var trainContext = new TrainContext(options);

            return trainContext;
        }

        public  List<Train.Train> GetTrains()
        {
            var trains = TrainContext.Trains
                .Include(u => u.Wagons)
                .ToListAsync();

            return trains.Result;
        }

        public void Dispose()
        {
            TrainContext.Dispose();
        }
    }
}
