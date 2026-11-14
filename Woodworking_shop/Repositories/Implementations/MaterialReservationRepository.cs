using Woodworking_shop.Entities;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Repositories.Implementations
{
    internal class MaterialReservationRepository : IMaterialReservationRepository
    {
        public void CreateReservation(MaterialReservation reservation) { }
        public IEnumerable<MaterialReservation> ReadReservations(DateTime? dateFrom = null, int? orderId = null) => new List<MaterialReservation>();
    }
}