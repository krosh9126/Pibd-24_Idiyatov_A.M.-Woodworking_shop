using Woodworking_shop.Entities;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Repositories.Implementations
{
    internal class OrderRepository : IOrderRepository
    {
        public void CreateOrder(Order order) { }
        public void DeleteOrder(int id) { } 
        public IEnumerable<Order> ReadOrders(DateTime? dateFrom = null, string? client = null) => new List<Order>();
    }
}