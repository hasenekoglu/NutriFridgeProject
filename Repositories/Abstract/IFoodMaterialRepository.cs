using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract
{
    public interface IFoodMaterialRepository
    {
        IEnumerable<FoodMaterial> GetAllFoodMaterials();
        public FoodMaterial GetFoodMaterialById(int foodId, int materialId);
        public void AddFoodMaterial(FoodMaterial foodMaterial);
        public void UpdateFoodMaterial(FoodMaterial foodMaterial);
        public void DeleteFoodMaterial(int foodId, int materialId);
    }
}
