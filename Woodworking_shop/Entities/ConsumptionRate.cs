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
            throw new ArgumentException("ID изделия должен быть больше нуля.", nameof(productId));

        if (materialId == null)
            throw new ArgumentException("ID материала должен быть больше нуля.", nameof(materialId));

        if (qtyPerProduct == null)
            throw new ArgumentException("Количество на изделие должно быть больше нуля.", nameof(qtyPerProduct));

        return new ConsumptionRate(id, productId.Value, materialId.Value, qtyPerProduct.Value);
    }
}