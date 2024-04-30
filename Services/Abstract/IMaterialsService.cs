using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Abstract
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
