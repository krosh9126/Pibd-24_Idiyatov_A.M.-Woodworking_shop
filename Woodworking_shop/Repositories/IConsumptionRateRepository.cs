using Woodworking_shop.Entities;

namespace Woodworking_shop.Repositories;

public interface IConsumptionRateRepository
{
    IEnumerable<ConsumptionRate> ReadConsumptionRates();
    IEnumerable<ConsumptionRate> ReadConsumptionRates(int productId);
    void CreateConsumptionRate(ConsumptionRate rate);
    void UpdateConsumptionRate(ConsumptionRate rate);
    void DeleteConsumptionRate(int id);
}
