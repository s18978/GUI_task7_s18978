using System;

namespace Test_2.DTO.Response
{
    public class PetResponse
    {
        public int IdPet { get; set; }

        public int IdBreedType { get; set; }

        public DateTime DateRegistered { get; set; }

        public DateTime DateAdopted { get; set; }

        public int Age { get; set; }
        
        public string Name { get; set; }

        public bool IsMale { get; set; }
        
        public DateTime ApproximateDateOfBirth { get; set; }
    }
}