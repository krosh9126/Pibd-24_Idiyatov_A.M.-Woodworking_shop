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

    public static OrderItem CreateEntity(int id, int orderId, int productId, int quantity)
    {
        if (orderId <= 0)
            throw new ArgumentException("ID заказа должен быть больше нуля.", nameof(orderId));

        if (productId <= 0)
            throw new ArgumentException("ID изделия должен быть больше нуля.", nameof(productId));

        if (quantity <= 0)
            throw new ArgumentException("Количество изделий должно быть больше нуля.", nameof(quantity));

        return new OrderItem(id, orderId, productId, quantity);
    }
}