using Woodworking_shop.Entities;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Repositories.Implementations
{
    internal class ConsumptionRateRepository : IConsumptionRateRepository
    {
        public void CreateConsumptionRate(ConsumptionRate rate) { }
        public void DeleteConsumptionRate(int id) { }
        public IEnumerable<ConsumptionRate> ReadConsumptionRates(int productId) => new List<ConsumptionRate>();
        public void UpdateConsumptionRate(ConsumptionRate rate) { }
    }
}