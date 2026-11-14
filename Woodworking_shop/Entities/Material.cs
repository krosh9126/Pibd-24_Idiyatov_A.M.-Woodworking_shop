using System;
using System.ComponentModel.DataAnnotations;
using Woodworking_shop.Entities.Enums;

namespace Woodworking_shop.Entities;

public class Material
{
    [Key]
    public int Id { get; private set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; private set; }

    public MaterialType Type { get; private set; }

    [Required]
    [MaxLength(20)]
    public string Unit { get; private set; }

    public double UnitPrice { get; private set; }
    public double StorageQty { get; private set; }
    public double ReservedQty { get; private set; }

    public Material()
    {
    }

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

    public static Material CreateEntity(int id, string name, MaterialType type, string unit, double? unitPrice, double? storageQty, double? reservedQty)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "Название материала не может быть пустым.");

        if (string.IsNullOrWhiteSpace(unit))
            throw new ArgumentNullException(nameof(unit), "Единица измерения не может быть пустой.");

        if (unitPrice == null || storageQty == null || reservedQty == null)
            throw new ArgumentNullException("Числовые значения не могут быть null.");

        if (unitPrice < 0 || storageQty < 0 || reservedQty < 0)
            throw new ArgumentException("Числовые значения не могут быть отрицательными.");

        return new Material(id, name, type, unit, unitPrice.Value, storageQty.Value, reservedQty.Value);
    }
}