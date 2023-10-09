using IsSistemCase.Core.Models.DbEntities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IsSistemCase.Repository.Contexts
{
    public class IsSistemSqlDbContext : DbContext
    {
        public IsSistemSqlDbContext(DbContextOptions<IsSistemSqlDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
