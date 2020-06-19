using System.Collections.Generic;

namespace Test_2.DTO.Response
{
    public class GetPetResponse
    {
        public ICollection<PetResponse> Pets { get; set; }
    }
}