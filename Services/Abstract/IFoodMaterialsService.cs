using Models;

namespace Services.Abstract;

public interface IFoodMaterialsService
{
    IEnumerable<FoodMaterial> GetAllFoodMaterials();
    FoodMaterial GetFoodMaterialById(int foodId, int materialId);
    void AddFoodMaterial(FoodMaterial foodMaterial);
    void UpdateFoodMaterial(FoodMaterial foodMaterial);
    void DeleteFoodMaterial(int foodId, int materialId);
}