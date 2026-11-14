using Woodworking_shop.Entities;

namespace Woodworking_shop.Repositories;

public interface IMaterialReservationRepository
{
    IEnumerable<MaterialReservation> ReadReservations(DateTime? dateFrom = null, int? orderId = null);
    void CreateReservation(MaterialReservation reservation);
}