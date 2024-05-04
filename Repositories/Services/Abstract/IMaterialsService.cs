using Models;

namespace Repositories.Services.Abstract
{
    public interface IMaterialsService
    {
        IEnumerable<Material> GetAllMaterials();
        Material GetMaterialById(int id);
        void AddMaterial(Material material);
        void UpdateMaterial(Material material);
        void DeleteMaterial(int id);
    }
}
