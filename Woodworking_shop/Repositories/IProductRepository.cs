using Woodworking_shop.Entities;

namespace Woodworking_shop.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> ReadProducts();
    Product ReadProductById(int id);
    void CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}