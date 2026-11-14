using Woodworking_shop.Entities;

namespace Woodworking_shop.Repositories;

public interface IOrderItemRepository
{
    IEnumerable<OrderItem> ReadOrderItems(int orderId);
    void CreateOrderItem(OrderItem orderItem);
    void DeleteOrderItem(int id);
}