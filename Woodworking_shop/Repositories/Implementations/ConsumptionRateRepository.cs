using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Woodworking_shop.Entities;

namespace Woodworking_shop.Repositories.Implementations;

internal class ConsumptionRateRepository : IConsumptionRateRepository
{
    private readonly DataContext _context;
    private readonly ILogger<ConsumptionRateRepository> _logger;

    public ConsumptionRateRepository(DataContext context, ILogger<ConsumptionRateRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void CreateConsumptionRate(ConsumptionRate rate)
    {
        _logger.LogInformation("Добавление нормы расхода");
        _context.ConsumptionRates.Add(rate);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public void DeleteConsumptionRate(int id)
    {
        _logger.LogInformation("Удаление нормы расхода ID: {Id}", id);
        var rate = _context.ConsumptionRates.FirstOrDefault(x => x.Id == id);
        if (rate != null)
        {
            _context.ConsumptionRates.Remove(rate);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }

    public IEnumerable<ConsumptionRate> ReadConsumptionRates(int productId)
    {
        _logger.LogInformation("Получение норм расхода для изделия ID: {ProductId}", productId);
        return _context.ConsumptionRates.AsNoTracking().Where(x => x.ProductId == productId).ToList();
    }

    public void UpdateConsumptionRate(ConsumptionRate rate)
    {
        _logger.LogInformation("Обновление нормы расхода ID: {Id}", rate.Id);
        _context.ConsumptionRates.Update(rate);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
}
