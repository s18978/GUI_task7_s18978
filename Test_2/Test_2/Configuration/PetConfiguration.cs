using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_2.Models;

namespace Test_2.Configuration
{
    public class PetConfiguration: IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(e => e.IdPet);
            builder.HasOne(e => e.BreedType).WithMany(e => e.Pets);
            
            builder.Property(e => e.Name).HasMaxLength(80).IsRequired();
            
            builder.Property(e => e.IsMale).IsRequired();
            builder.Property(e => e.DateRegistered).IsRequired();
            builder.Property(e => e.ApproximateDateOfBirth).IsRequired();
        }
    }
}