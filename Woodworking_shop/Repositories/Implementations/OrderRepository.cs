using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Woodworking_shop.Entities;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Repositories.Implementations;

internal class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;
    private readonly ILogger<OrderRepository> _logger;

    public OrderRepository(DataContext context, ILogger<OrderRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void CreateOrder(Order order)
    {
        _logger.LogInformation("Создание заказа для клиента: {Client}", order.Client);

        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var newOrder = Order.CreateOperation(0, order.Client, order.Status, order.Type, new List<OrderItem>());
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            foreach (var item in order.OrderItems)
            {
                var orderItem = OrderItem.CreateEntity(0, newOrder.Id, item.ProductId, item.Quantity);
                _context.OrderItems.Add(orderItem);
            }

            _context.SaveChanges();
            transaction.Commit();
            _context.ChangeTracker.Clear();
            _logger.LogInformation("Заказ успешно создан. ID: {OrderId}", newOrder.Id);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            _context.ChangeTracker.Clear();
            _logger.LogError(ex, "Ошибка при создании заказа");
            throw;
        }
    }

    public void DeleteOrder(int id)
    {
        _logger.LogInformation("Удаление заказа ID: {Id}", id);
        var order = _context.Orders.FirstOrDefault(o => o.Id == id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }

    public IEnumerable<Order> ReadOrders(DateTime? dateFrom = null, string? client = null)
    {
        _logger.LogInformation("Получение списка заказов");

        var query = _context.Orders.AsNoTracking().AsQueryable();

        if (dateFrom.HasValue)
        {
            query = query.Where(o => o.DateStart >= dateFrom.Value);
        }

        if (!string.IsNullOrWhiteSpace(client))
        {
            query = query.Where(o => o.Client.Contains(client));
        }

        return query.ToList();
    }
}
