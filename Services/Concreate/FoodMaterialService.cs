using Models;
using Repositories.Abstract;
using Repositories.Concreate;
using Services.Abstract;

namespace Services.Concreate;

public class FoodMaterialService :IFoodMaterialsService
{
    private readonly IFoodMaterialRepository _foodMaterialRepository;

    public FoodMaterialService(FoodMaterialRepository foodMaterialRepository)
    {
        _foodMaterialRepository = foodMaterialRepository;
    }

    public IEnumerable<FoodMaterial> GetAllFoodMaterials()
    {
        return _foodMaterialRepository.GetMaterials();
    }

    public FoodMaterial GetFoodMaterialById(int foodId, int materialId)
    {
        return _foodMaterialRepository.GetFoodMaterialById(foodId, materialId);
    }

    public void AddFoodMaterial(FoodMaterial foodMaterial)
    {
        _foodMaterialRepository.AddFoodMaterial(foodMaterial);
    }

    public void UpdateFoodMaterial(FoodMaterial foodMaterial)
    {
        _foodMaterialRepository.UpdateFoodMaterial(foodMaterial);
    }

    public void DeleteFoodMaterial(int foodId, int materialId)
    {
        _foodMaterialRepository.DeleteFoodMaterial(foodId, materialId);
    }
}