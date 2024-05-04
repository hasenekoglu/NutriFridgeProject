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
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public MaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Material> GetMaterials()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return
                    context.Set<Material>().ToList();

            }
            //return _context.Set<Material>().ToList();
        }

        public Material GetMaterialById(int id)
        {
            return _context.Materials.FirstOrDefault(m => m.Id == id);
        }

        public void AddMaterial(Material material)
        {
            _context.Materials.Add(material);
            _context.SaveChanges();
        }

        public void UpdateMaterial(Material material)
        {
            _context.Entry(material).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMaterial(int id)
        {
            var material = _context.Materials.Find(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
                _context.SaveChanges();
            }
        }
    }
}
