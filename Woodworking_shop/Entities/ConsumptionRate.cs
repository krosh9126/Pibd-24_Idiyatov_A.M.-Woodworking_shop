using System;

namespace Woodworking_shop.Entities;

public class ConsumptionRate
{
    public int Id { get; private set; }
    public int ProductId { get; private set; }
    public int MaterialId { get; private set; }
    public double QtyPerProduct { get; private set; }

    private ConsumptionRate(int id, int productId, int materialId, double qtyPerProduct)
    {
        Id = id;
        ProductId = productId;
        MaterialId = materialId;
        QtyPerProduct = qtyPerProduct;
    }

    public static ConsumptionRate CreateEntity(int id, int? productId, int? materialId, double? qtyPerProduct)
    {
        if (productId == null)
            throw new ArgumentException("ID изделия не должно быть null.", nameof(productId));

        if (materialId == null)
            throw new ArgumentException("ID материала не должно быть null.", nameof(materialId));

        if (qtyPerProduct <= 0)
            throw new ArgumentException("Количество на изделие должно быть больше нуля.", nameof(qtyPerProduct));

        if (qtyPerProduct == null)
            throw new ArgumentException("Количество на изделие не должно быть null.", nameof(qtyPerProduct));

        return new ConsumptionRate(id, productId.Value, materialId.Value, qtyPerProduct.Value);
    }
}