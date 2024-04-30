using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Abstract;
using Repositories.Context;

namespace Repositories.Concreate
{
    public class FoodMaterialRepository : IFoodMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodMaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<FoodMaterial> GetMaterials()
        {
            return _context.FoodsMaterials.ToList();
        }


        public FoodMaterial GetFoodMaterialById(int foodId, int materialId)
        {
            return _context.FoodsMaterials.FirstOrDefault(fm => fm.FoodId == foodId && fm.MaterialId == materialId);
        }

        public void AddFoodMaterial(FoodMaterial foodMaterial)
        {
            _context.FoodsMaterials.Add(foodMaterial);
            _context.SaveChanges();
        }

        public void UpdateFoodMaterial(FoodMaterial foodMaterial)
        {
            _context.Entry(foodMaterial).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteFoodMaterial(int foodId, int materialId)
        {
            var foodMaterial = _context.FoodsMaterials.FirstOrDefault(fm => fm.FoodId == foodId && fm.MaterialId == materialId);
            if (foodMaterial != null)
            {
                _context.FoodsMaterials.Remove(foodMaterial);
                _context.SaveChanges();
            }
        }
    }
}

