using IsSistemCase.Core.Models.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsSistemCase.Repository.Configurations
{
    internal class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.Capacity).IsRequired();

            builder.HasMany(x => x.Reservations).WithOne(x => x.Table).HasForeignKey(x => x.TableId);

            builder.ToTable("Tables");
        }
    }
}
