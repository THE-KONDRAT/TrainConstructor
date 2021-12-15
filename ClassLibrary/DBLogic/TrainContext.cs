using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.DBLogic
{
    public class TrainContext : DbContext, IDisposable
    {
        public DbSet<Train.Train> Trains { get; set; }

        public TrainContext(DbContextOptions<TrainContext> options)
            : base(options)
        {

        }

        /*public TrainContext()
            : base("DBConnection")
        {
        }*/

        public void Dispose()
        {

        }
    }
}
