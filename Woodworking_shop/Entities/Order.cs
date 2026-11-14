using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Woodworking_shop.Entities;

public class Order
{
    [Key]
    public int Id { get; private set; }

    [Required]
    [MaxLength(200)]
    public string Client { get; private set; }

    [Required]
    [MaxLength(50)]
    public string Status { get; private set; }

    [Required]
    [MaxLength(50)]
    public string Type { get; private set; }

    public DateTime DateStart { get; private set; }

    public DateTime? DateFinish { get; private set; }

    public IEnumerable<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

    public Order()
    {
    }

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
            throw new ArgumentNullException(nameof(client), "Имя клиента не может быть пустым.");

        if (string.IsNullOrWhiteSpace(status))
            throw new ArgumentNullException(nameof(status), "Статус не может быть пустым.");

        if (string.IsNullOrWhiteSpace(type))
            throw new ArgumentNullException(nameof(type), "Тип заказа не может быть пустым.");

        var items = orderItems ?? new List<OrderItem>();

        return new Order(id, client, status, type, DateTime.UtcNow, dateFinish, items);
    }
}