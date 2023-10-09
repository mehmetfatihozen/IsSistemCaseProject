using IsSistemCase.Core.Models.DbEntities;
using IsSistemCase.Core.Repositories;
using IsSistemCase.Repository.Contexts;

namespace IsSistemCase.Repository.Repositories
{
    public class ReservationRepository : GenericRepositoy<Reservation>, IReservationRepository
    {
        public ReservationRepository(IsSistemSqlDbContext context) : base(context)
        {
        }
    }
}