using Mamba.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Configuration
{
    public class WorkerPositionConfiguration : IEntityTypeConfiguration<WorkerPosition>
    {
        public void Configure(EntityTypeBuilder<WorkerPosition> builder)
        {
            builder.HasOne(x => x.worker).WithMany(x => x.WorkerPosition);
            builder.HasOne(x => x.position).WithMany(x => x.WorkerPosition);


        }
    }
}
