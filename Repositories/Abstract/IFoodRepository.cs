using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract
{
    public interface IFoodRepository
    {
        IEnumerable<Food> GetAllFoods();
        public Food GetFoodById(int id);
        public void AddFood(Food food);
        public void UpdateFood(Food food);
        public void DeleteFood(int id);
    }
}
