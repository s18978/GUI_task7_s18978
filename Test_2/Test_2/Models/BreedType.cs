using System.Collections.Generic;

namespace Test_2.Models
{
    public class BreedType
    {
        public int IdBreedType { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public virtual ICollection<Pet> Pets{ get; set; }
        
    }
}