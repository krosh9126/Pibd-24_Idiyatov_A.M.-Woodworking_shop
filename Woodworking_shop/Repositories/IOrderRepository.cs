using Woodworking_shop.Entities;

namespace Woodworking_shop.Repositories;

public interface IOrderRepository
{
    IEnumerable<Order> ReadOrders(DateTime? dateFrom = null, string? client = null);
    void CreateOrder(Order order);
    void DeleteOrder(int id);
}