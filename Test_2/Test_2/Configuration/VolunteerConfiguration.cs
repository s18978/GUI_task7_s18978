using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_2.Models;

namespace Test_2.Configuration
{
    public class VolunteerConfiguration: IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.HasKey(e => e.IdVolunteer);
            builder.HasOne(e => e.VolunteerInst).WithMany(e => e.Volunteers);
            builder.Property(e => e.IdVolunteer).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(80).IsRequired();
            builder.Property(e => e.Surname).HasMaxLength(80).IsRequired();
            builder.Property(e => e.Phone).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(80).IsRequired();
            builder.Property(e => e.StartingDate).IsRequired();
        }
    }
}