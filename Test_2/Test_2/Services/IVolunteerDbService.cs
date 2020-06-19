using Test_2.DTO.Request;
using Test_2.DTO.Response;

namespace Test_2.Services
{
    public interface IVolunteerDbService
    { public GetPetResponse GetPets(GetPetRequest request);
        
        public void AssignPetToVolunteer(PetRequest request);
    }
}