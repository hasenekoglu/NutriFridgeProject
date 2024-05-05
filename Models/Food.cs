using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class Food 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FoodValue { get; set; }
        public string Recipe { get; set; }

       // public ICollection<FoodMaterial> FoodMaterials { get; set; }
    }
}
