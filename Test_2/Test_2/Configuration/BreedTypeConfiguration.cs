using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_2.Models;

namespace Test_2.Configuration
{
    public class BreedTypeConfiguration: IEntityTypeConfiguration<BreedType>
    {
        public void Configure(EntityTypeBuilder<BreedType> builder)
        {
            builder.HasKey(e => e.IdBreedType);

            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(500);
        }
    }
}