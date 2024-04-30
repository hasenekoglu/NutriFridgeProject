using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories.Abstract
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> GetMaterials();
        public Material GetMaterialById(int id);
        public void AddMaterial(Material material);
        public void UpdateMaterial(Material material);
        public void DeleteMaterial(int id);

    }
}
