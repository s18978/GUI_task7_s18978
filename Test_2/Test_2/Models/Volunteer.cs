using System;
using System.Collections.Generic;
using System.Runtime;

namespace Test_2.Models
{
    public class Volunteer
    {
        public int IdVolunteer { get; set; }

        public int IdSupervisor { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }
        
        public string Phone { get; set; }
        
        public string Address { get; set; }
        
        public string Email { get; set; }

        public DateTime StartingDate { get; set; }

        public virtual ICollection<Volunteer_Pet> Volunteer_Pets{ get; set; }
        
        public virtual ICollection<Volunteer> Volunteers{ get; set; }

        public Volunteer VolunteerInst { get; set; }
        
    }
}