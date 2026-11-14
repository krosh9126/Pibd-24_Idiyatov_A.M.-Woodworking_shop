using System;
using System.Collections.Generic;

namespace Woodworking_shop.Entities;

public class Order
{
    public int Id { get; private set; }
    public string Client { get; private set; }
    public string Status { get; private set; }
    public string Type { get; private set; }
    public DateTime DateStart { get; private set; }
    public DateTime? DateFinish { get; private set; }

    public IEnumerable<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

    private Order(int id, string client, string status, string type, DateTime dateStart, DateTime? dateFinish, IEnumerable<OrderItem> orderItems)
    {
        Id = id;
        Client = client;
        Status = status;
        Type = type;
        DateStart = dateStart;
        DateFinish = dateFinish;
        OrderItems = orderItems;
    }

    public static Order CreateOperation(int id, string client, string status, string type, IEnumerable<OrderItem> orderItems, DateTime? dateFinish = null)
    {
        if (string.IsNullOrWhiteSpace(client))
            throw new ArgumentException("Имя клиента не может быть пустым.", nameof(client));
        if (string.IsNullOrWhiteSpace(status))
            throw new ArgumentException("Статус не может быть пустым.", nameof(status));
        if (string.IsNullOrWhiteSpace(type))
            throw new ArgumentException("Тип заказа не может быть пустым.", nameof(type));

        var items = orderItems ?? [];

        return new Order(id, client, status, type, DateTime.Now, dateFinish, items);
    }
}