using Microsoft.EntityFrameworkCore;
using Test_2.Configuration;

namespace Test_2.Models
{
    public class VolunteerDbContext : DbContext
    {
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<BreedType> BreedTypes { get; set; }
        public DbSet<Volunteer_Pet> Volunteer_Pets { get; set; }

        public VolunteerDbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration<Volunteer>(new VolunteerConfiguration());
            builder.ApplyConfiguration<Pet>(new PetConfiguration());
            builder.ApplyConfiguration<Volunteer_Pet>(new Volunteer_PetConfiguration());
            builder.ApplyConfiguration<BreedType>(new BreedTypeConfiguration());
        }
        
    }
}