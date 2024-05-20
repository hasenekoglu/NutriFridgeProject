using Models;
using Repositories.Abstract;
using Repositories.Concreate;
using Repositories.Services.Abstract;

namespace Repositories.Services.Concreate
{
    public class MaterialsService : IMaterialsService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialsService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public IList<Material> GetAllMaterials()
        {
            return _materialRepository.GetMaterials();
        }

        public Material GetMaterialById(int id)
        {
            return _materialRepository.GetMaterialById(id);
        }

        public void AddMaterial(Material material)
        {
            _materialRepository.AddMaterial(material);
        }

        public void UpdateMaterial(Material material)
        {
            _materialRepository.UpdateMaterial(material);
        }

        public void DeleteMaterial(int id)
        {
            _materialRepository.DeleteMaterial(id);
        }


    }
}
