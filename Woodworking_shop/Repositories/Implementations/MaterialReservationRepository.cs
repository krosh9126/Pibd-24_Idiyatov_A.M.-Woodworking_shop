using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Woodworking_shop.Entities;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Repositories.Implementations;

internal class MaterialReservationRepository : IMaterialReservationRepository
{
    private readonly DataContext _context;
    private readonly ILogger<MaterialReservationRepository> _logger;

    public MaterialReservationRepository(DataContext context, ILogger<MaterialReservationRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void CreateReservation(MaterialReservation reservation)
    {
        _logger.LogInformation("Создание резерва материала ID: {MaterialId} для заказа ID: {OrderId}", reservation.MaterialId, reservation.OrderId);
        _context.MaterialReservations.Add(reservation);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public IEnumerable<MaterialReservation> ReadReservations(DateTime? dateFrom = null, int? orderId = null)
    {
        _logger.LogInformation("Получение списка резервов");

        var query = _context.MaterialReservations.AsNoTracking().AsQueryable();

        if (dateFrom.HasValue)
        {
            query = query.Where(r => r.ReservationDate >= dateFrom.Value);
        }

        if (orderId.HasValue)
        {
            query = query.Where(r => r.OrderId == orderId.Value);
        }

        return query.ToList();
    }
}
