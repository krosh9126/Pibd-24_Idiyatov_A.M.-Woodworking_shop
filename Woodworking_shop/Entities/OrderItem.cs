using System;

namespace Woodworking_shop.Entities;

public class OrderItem
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }

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
            throw new ArgumentException("ID заказа не должно быть null", nameof(orderId));

        if (productId == null)
            throw new ArgumentException("ID изделия не должно быть null", nameof(productId));

        if (quantity == null)
            throw new ArgumentException("Количество изделий не должно быть null", nameof(quantity));

        return new OrderItem(id, orderId.Value, productId.Value, quantity.Value);
    }
}