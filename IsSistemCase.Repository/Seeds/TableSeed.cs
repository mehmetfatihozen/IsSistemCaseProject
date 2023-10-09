using IsSistemCase.Core.Models.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsSistemCase.Repository.Seeds
{
    internal class TableSeed : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            List<Table> tables = new();

            for (ushort i = 1; i <= 6; i++)
            {
                tables.Add(new Table { Id = Guid.NewGuid(), Capacity = 2, Number = i });
            }
            for (ushort i = 7; i <= 16; i++)
            {
                tables.Add(new Table { Id = Guid.NewGuid(), Capacity = 4, Number = i });
            }
            for (ushort i = 17; i <= 18; i++)
            {
                tables.Add(new Table { Id = Guid.NewGuid(), Capacity = 6, Number = i });
            }
            for (ushort i = 19; i <= 20; i++)
            {
                tables.Add(new Table { Id = Guid.NewGuid(), Capacity = 8, Number = i });
            }

            builder.HasData(tables);
        }
    }
}
