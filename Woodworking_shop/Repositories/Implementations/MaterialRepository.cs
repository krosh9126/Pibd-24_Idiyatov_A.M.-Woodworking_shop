using Woodworking_shop.Entities;
using Woodworking_shop.Entities.Enums;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Repositories.Implementations
{
    internal class MaterialRepository : IMaterialRepository
    {
        public void CreateMaterial(Material material) { }
        public void DeleteMaterial(int id) { }
        public Material ReadMaterialById(int id) => Material.CreateEntity(0, "Stub", MaterialType.None, "шт", 0, 0, 0);
        public IEnumerable<Material> ReadMaterials() => new List<Material>();
        public void UpdateMaterial(Material material) { }
    }
}