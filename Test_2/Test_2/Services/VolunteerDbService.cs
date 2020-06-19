using System;
using System.Collections.Generic;
using System.Linq;
using Test_2.DTO.Request;
using Test_2.DTO.Response;
using Test_2.Models;

namespace Test_2.Services
{
    public class VolunteerDbService : IVolunteerDbService
    {
        private readonly VolunteerDbContext _volunteerDbContext;

        public VolunteerDbService(VolunteerDbContext context)
        {
            _volunteerDbContext = context;
        }
        public GetPetResponse GetPets(GetPetRequest request)
        {
            var response = new GetPetResponse()
            {
                Pets = new List<PetResponse>()
            };
            if (_volunteerDbContext.Volunteers.Where(v => v.IdVolunteer == request.IdVolunteer).Count() != 1)
                throw new Exception();

            _volunteerDbContext.Join(_volunteerDbContext.Volunteer_Pets,
                vol => vol.IdVolunteer, vol_pet => vol_pet.IdVolunteer, (vol, vol_pet) => new {vol.IdVolunteer, vol_pet.IdPet});
            return response;
        }
        public void AssignPetToVolunteer(PetRequest request)
        {
            if (_volunteerDbContext.Volunteers.Where(v => v.IdVolunteer == request.idVolunteer).Count() != 1)
                throw new Exception();
            if (_volunteerDbContext.Pets.Where(pet => pet.IdPet == request.idPet).Count() != 1)
                throw new Exception();
            if (_volunteerDbContext.Volunteers.Where(v => v.IdVolunteer == request.idVolunteer && v.IdSupervisor == null).Count() !=
                1)
                throw new Exception();
            using (var trans = _volunteerDbContext.Database.BeginTransaction())
            {
                Volunteer_Pet volunteer_Pet = new Volunteer_Pet()
                {
                    idPet = request.idPet,
                    idVolunteer = request.idVolunteer,
                    DateAccepted = DateTime.Now
                };
                _volunteerDbContext.Add<Volunteer_Pet>(volunteer_Pet);
                _volunteerDbContext.SaveChanges();
                trans.Commit();
            }
        }
    }
}