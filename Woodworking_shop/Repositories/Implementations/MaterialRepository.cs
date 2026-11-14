using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Woodworking_shop.Entities;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Repositories.Implementations;

internal class MaterialRepository : IMaterialRepository
{
    private readonly DataContext _context;
    private readonly ILogger<MaterialRepository> _logger;

    public MaterialRepository(DataContext context, ILogger<MaterialRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void CreateMaterial(Material material)
    {
        _logger.LogInformation("Добавление материала: {Name}", material.Name);
        _context.Materials.Add(material);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    public void DeleteMaterial(int id)
    {
        _logger.LogInformation("Удаление материала ID: {Id}", id);
        var material = _context.Materials.FirstOrDefault(m => m.Id == id);
        if (material != null)
        {
            _context.Materials.Remove(material);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }

    public Material ReadMaterialById(int id)
    {
        return _context.Materials.AsNoTracking().FirstOrDefault(m => m.Id == id);
    }

    public IEnumerable<Material> ReadMaterials()
    {
        _logger.LogInformation("Получение всех материалов");
        return _context.Materials.AsNoTracking().ToList();
    }

    public void UpdateMaterial(Material material)
    {
        _logger.LogInformation("Обновление материала ID: {Id}", material.Id);
        _context.Materials.Update(material);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
}
