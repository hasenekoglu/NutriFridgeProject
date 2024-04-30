using Models;
using Repositories.Abstract;
using Repositories.Concreate;
using Services.Abstract;

namespace Services.Concreate;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;

    public FoodService(FoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }

    public IEnumerable<Food> GetAllFoods()
    {
        return _foodRepository.GetAllFoods();
    }

    public Food GetFoodById(int id)
    {
        return _foodRepository.GetFoodById(id);
    }

    public void AddFood(Food food)
    {
        _foodRepository.AddFood(food);
    }

    public void UpdateFood(Food food)
    {
        _foodRepository.UpdateFood(food);
    }

    public void DeleteFood(int id)
    {
        _foodRepository.DeleteFood(id);
    }
}