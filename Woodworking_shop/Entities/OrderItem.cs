using System;
using System.ComponentModel.DataAnnotations;

namespace Woodworking_shop.Entities;

public class OrderItem
{
    [Key]
    public int Id { get; private set; }

    public int OrderId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }

    public OrderItem()
    {
    }

    private OrderItem(int id, int orderId, int productId, int quantity)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    public static OrderItem CreateEntity(int id, int? orderId, int? productId, int? quantity)
    {
        if (orderId == null)
            throw new ArgumentNullException(nameof(orderId), "ID заказа не должно быть null");

        if (productId == null)
            throw new ArgumentNullException(nameof(productId), "ID изделия не должно быть null");

        if (quantity == null)
            throw new ArgumentNullException(nameof(quantity), "Количество изделий не должно быть null");

        if (quantity <= 0)
            throw new ArgumentException("Количество изделий должно быть больше нуля", nameof(quantity));

        return new OrderItem(id, orderId.Value, productId.Value, quantity.Value);
    }
}