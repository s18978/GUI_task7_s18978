using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_2.Models;

namespace Test_2.Configuration
{
    public class Volunteer_PetConfiguration : IEntityTypeConfiguration<Volunteer_Pet>
    {
        public void Configure(EntityTypeBuilder<Volunteer_Pet> builder)
        {
            builder.HasKey(e => new {e.idVolunteer, e.idPet});
            builder.HasOne(e => e.pet).WithMany(e => e.Volunteer_Pets);
            builder.HasOne(e => e.volunteer).WithMany(e => e.Volunteer_Pets);
            builder.Property(e => e.DateAccepted).IsRequired();
            
        }
    }
}