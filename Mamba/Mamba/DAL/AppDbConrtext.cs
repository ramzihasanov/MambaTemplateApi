using Mamba.Configuration;
using Mamba.Entites;
using Microsoft.EntityFrameworkCore;

namespace Mamba.DAL
{
    public class AppDbConrtext : DbContext
    {
        public AppDbConrtext(DbContextOptions<AppDbConrtext> options) : base(options)
        { }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerPosition> workerPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkerPositionConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
     
}
