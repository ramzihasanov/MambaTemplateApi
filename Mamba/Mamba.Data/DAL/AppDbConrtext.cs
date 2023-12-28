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
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkerPositionConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                var entity = item.Entity;
                switch (item.State)
                {
                 
                    case EntityState.Modified:
                        entity.UpdateDate = DateTime.UtcNow.AddHours(4);
                        break;
                    case EntityState.Added:
                        entity.CreateDate = DateTime.UtcNow.AddHours(4);
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChanges();
        }

    }
     
}
