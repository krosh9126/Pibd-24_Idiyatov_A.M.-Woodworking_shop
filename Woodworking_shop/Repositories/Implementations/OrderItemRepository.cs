using Woodworking_shop.Entities;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Repositories.Implementations
{
    internal class OrderItemRepository : IOrderItemRepository
    {
        public void CreateOrderItem(OrderItem orderItem) { }
        public void DeleteOrderItem(int id) { }
        public IEnumerable<OrderItem> ReadOrderItems(int orderId) => new List<OrderItem>();
    }
}