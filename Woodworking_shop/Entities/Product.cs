using System;
using System.ComponentModel.DataAnnotations;
using Woodworking_shop.Entities.Enums;

namespace Woodworking_shop.Entities;

public class Product
{
    [Key]
    public int Id { get; private set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; private set; }

    public ProductCategory Category { get; private set; }

    public double Price { get; private set; }
    public int StorageQty { get; private set; }

    public Product()
    {
    }

    private Product(int id, string name, ProductCategory category, double price, int storageQty)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        StorageQty = storageQty;
    }

    public static Product CreateEntity(int id, string name, ProductCategory category, double? price, int? storageQty)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "Название изделия не может быть пустым.");

        if (price == null)
            throw new ArgumentNullException(nameof(price), "Цена не должна быть null.");

        if (price < 0)
            throw new ArgumentException("Цена не может быть отрицательной.", nameof(price));

        if (storageQty == null)
            throw new ArgumentNullException(nameof(storageQty), "Остаток на складе не должен быть null.");

        if (storageQty < 0)
            throw new ArgumentException("Остаток на складе не может быть отрицательным.", nameof(storageQty));

        return new Product(id, name, category, price.Value, storageQty.Value);
    }
}