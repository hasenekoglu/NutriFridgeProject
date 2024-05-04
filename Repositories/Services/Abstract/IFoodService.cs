using Models;

namespace Repositories.Services.Abstract;

public interface IFoodService
{
    IEnumerable<Food> GetAllFoods();
    Food GetFoodById(int id);
    void AddFood(Food food);
    void UpdateFood(Food food);
    void DeleteFood(int id);
}