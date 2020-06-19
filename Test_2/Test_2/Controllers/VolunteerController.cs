
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_2.DTO.Request;
using Test_2.Services;

namespace Test_2.Controllers
{
    [Route("api/volunteers")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerDbService _dbService;

        public VolunteerController(IVolunteerDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}/pets")]
        public IActionResult GetPets(int id, int year)
        {
            var request = new GetPetRequest()
            {
                IdVolunteer = id,
                Year = year
            };
            try
            {
                return Ok(_dbService.GetPets(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/pets")]
        public IActionResult AssignPetToVolunteer(int id, PetRequest request)
        {
            request.idVolunteer = id;

            try
            {
                _dbService.AssignPetToVolunteer(request);
            }
            catch (Exception ex)
            {
            }

            return Ok();
        }
    }
}