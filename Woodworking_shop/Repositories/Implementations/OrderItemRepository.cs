using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Woodworking_shop.Entities;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Repositories.Implementations;

internal class OrderItemRepository : IOrderItemRepository
{
    private readonly DataContext _context;
    private readonly ILogger<OrderItemRepository> _logger;

    public OrderItemRepository(DataContext context, ILogger<OrderItemRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void CreateOrderItem(OrderItem orderItem)
    {
        _logger.LogInformation("Добавление позиции заказа для заказа ID: {OrderId}", orderItem.OrderId);
        _context.OrderItems.Add(orderItem);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public void DeleteOrderItem(int id)
    {
        _logger.LogInformation("Удаление позиции заказа ID: {Id}", id);
        var orderItem = _context.OrderItems.FirstOrDefault(x => x.Id == id);
        if (orderItem != null)
        {
            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }

    public IEnumerable<OrderItem> ReadOrderItems(int orderId)
    {
        _logger.LogInformation("Получение позиций заказа ID: {OrderId}", orderId);
        return _context.OrderItems.AsNoTracking().Where(x => x.OrderId == orderId).ToList();
    }
}
