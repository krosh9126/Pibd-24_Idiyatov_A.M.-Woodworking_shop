using System;
using Woodworking_shop.Entities.Enums;

namespace Woodworking_shop.Entities;

public class Material
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public MaterialType Type { get; private set; }
    public string Unit { get; private set; }
    public double UnitPrice { get; private set; }
    public double StorageQty { get; private set; }
    public double ReservedQty { get; private set; }

    private Material(int id, string name, MaterialType type, string unit, double unitPrice, double storageQty, double reservedQty)
    {
        Id = id;
        Name = name;
        Type = type;
        Unit = unit;
        UnitPrice = unitPrice;
        StorageQty = storageQty;
        ReservedQty = reservedQty;
    }

    public static Material CreateEntity(int id, string name, MaterialType type, string unit, double unitPrice, double storageQty, double reservedQty)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название материала не может быть пустым.", nameof(name));

        if (string.IsNullOrWhiteSpace(unit))
            throw new ArgumentException("Единица измерения не может быть пустой.", nameof(unit));

        if (unitPrice < 0 || storageQty < 0 || reservedQty < 0)
            throw new ArgumentException("Числовые значения не могут быть отрицательными.");

        return new Material(id, name, type, unit, unitPrice, storageQty, reservedQty);
    }
}