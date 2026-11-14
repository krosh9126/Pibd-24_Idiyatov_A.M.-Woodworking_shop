using System;
using Woodworking_shop.Entities.Enums;

namespace Woodworking_shop.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public ProductCategory Category { get; private set; }
    public double Price { get; private set; }
    public int StorageQty { get; private set; }

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
            throw new ArgumentException("Название изделия не может быть пустым.", nameof(name));

        if (price < 0 || price == null)
            throw new ArgumentException("Цена не может быть отрицательной и не должно быть null.", nameof(price));

        if (storageQty < 0 || storageQty == null)
            throw new ArgumentException("Остаток на складе не может быть отрицательным и не должно быть null.", nameof(storageQty));

        return new Product(id, name, category, price.Value, storageQty.Value);
    }
}