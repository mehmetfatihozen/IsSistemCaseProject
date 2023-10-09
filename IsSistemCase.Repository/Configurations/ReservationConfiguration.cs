using IsSistemCase.Core.Models.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsSistemCase.Repository.Configurations
{
    internal class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.TableId).IsRequired();
            builder.Property(x => x.ReservationDate).IsRequired();
            builder.Property(x => x.NumberOfGuests).IsRequired();

            builder.HasOne(x => x.Customer).WithMany(x => x.Reservations).HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.Table).WithMany(x => x.Reservations).HasForeignKey(x => x.TableId);

            builder.ToTable("Reservations");
        }
    }
}
