using Woodworking_shop.Entities;
using Woodworking_shop.Entities.Enums;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Repositories.Implementations;

internal class ProductRepository : IProductRepository
{
    public void CreateProduct(Product product) { }
    public void DeleteProduct(int id) { }
    public Product ReadProductById(int id) => Product.CreateEntity(0, "Тестовое изделие", ProductCategory.None, 0, 0);
    public IEnumerable<Product> ReadProducts() => new List<Product>();
    public void UpdateProduct(Product product) { }
}