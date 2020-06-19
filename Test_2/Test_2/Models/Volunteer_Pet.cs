using System;
using System.Collections.Generic;

namespace Test_2.Models
{
    public class Volunteer_Pet
    {
        public int idVolunteer { get; set; }

        public int idPet { get; set; }

        public DateTime DateAccepted { get; set; }

        public Volunteer volunteer { get; set; }

        public Pet pet { get; set; }
        
    }
}