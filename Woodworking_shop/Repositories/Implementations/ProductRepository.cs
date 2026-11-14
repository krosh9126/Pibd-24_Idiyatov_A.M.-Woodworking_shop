using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Woodworking_shop.Entities;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Repositories.Implementations;

internal class ProductRepository : IProductRepository
{
    private readonly DataContext _context;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(DataContext context, ILogger<ProductRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void CreateProduct(Product product)
    {
        _logger.LogInformation("Добавление изделия: {Name}", product.Name);
        _context.Products.Add(product);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public void DeleteProduct(int id)
    {
        _logger.LogInformation("Удаление изделия ID: {Id}", id);
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }

    public Product ReadProductById(int id)
    {
        return _context.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> ReadProducts()
    {
        _logger.LogInformation("Получение списка изделий");
        return _context.Products.AsNoTracking().ToList();
    }

    public void UpdateProduct(Product product)
    {
        _logger.LogInformation("Обновление изделия ID: {Id}", product.Id);
        _context.Products.Update(product);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
}
