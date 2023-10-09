using IsSistemCase.Core.Models.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsSistemCase.Repository.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Phone).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Email).IsRequired();

            builder.HasMany(x => x.Reservations).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);

            builder.ToTable("Customers");
        }
    }
}
