using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FoodValue { get; set; }
       // public ICollection<FoodMaterial> FoodMaterials { get; set; }
    }
}
