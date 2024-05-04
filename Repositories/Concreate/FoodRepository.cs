using Models;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Repositories.Abstract;

namespace Repositories.Concreate
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodRepository(ApplicationDbContext context)
        {
            
            _context = new ApplicationDbContext();
        }


        public IEnumerable<Food> GetAllFoods()
        {
            return _context.Foods.ToList();
        }

        public Food GetFoodById(int id)
        {
            return _context.Foods.FirstOrDefault(f => f.Id == id);
        }

        public void AddFood(Food food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();
        }

        public void UpdateFood(Food food)
        {
            _context.Entry(food).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteFood(int id)
        {
            var food = _context.Foods.Find(id);
            if (food !=null)
            {
                _context.Foods.Remove(food);
                _context.SaveChanges();
            }
        }
    }
}

