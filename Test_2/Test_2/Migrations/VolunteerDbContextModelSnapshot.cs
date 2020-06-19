﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test_2.Models;

namespace Test_2.Migrations
{
    [DbContext(typeof(VolunteerDbContext))]
    partial class VolunteerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Test_2.Models.BreedType", b =>
                {
                    b.Property<int>("IdBreedType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdBreedType");

                    b.ToTable("BreedTypes");
                });

            modelBuilder.Entity("Test_2.Models.Pet", b =>
                {
                    b.Property<int>("IdPet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApproximateDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BreedTypeIdBreedType")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdopted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdBreedType")
                        .HasColumnType("int");

                    b.Property<bool>("IsMale")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("IdPet");

                    b.HasIndex("BreedTypeIdBreedType");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Test_2.Models.Volunteer", b =>
                {
                    b.Property<int>("IdVolunteer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int>("IdSupervisor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int?>("VolunteerInstIdVolunteer")
                        .HasColumnType("int");

                    b.HasKey("IdVolunteer");

                    b.HasIndex("VolunteerInstIdVolunteer");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("Test_2.Models.Volunteer_Pet", b =>
                {
                    b.Property<int>("idVolunteer")
                        .HasColumnType("int");

                    b.Property<int>("idPet")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAccepted")
                        .HasColumnType("datetime2");

                    b.HasKey("idVolunteer", "idPet");

                    b.HasIndex("idPet");

                    b.ToTable("Volunteer_Pets");
                });

            modelBuilder.Entity("Test_2.Models.Pet", b =>
                {
                    b.HasOne("Test_2.Models.BreedType", "BreedType")
                        .WithMany("Pets")
                        .HasForeignKey("BreedTypeIdBreedType");
                });

            modelBuilder.Entity("Test_2.Models.Volunteer", b =>
                {
                    b.HasOne("Test_2.Models.Volunteer", "VolunteerInst")
                        .WithMany("Volunteers")
                        .HasForeignKey("VolunteerInstIdVolunteer");
                });

            modelBuilder.Entity("Test_2.Models.Volunteer_Pet", b =>
                {
                    b.HasOne("Test_2.Models.Pet", "pet")
                        .WithMany("Volunteer_Pets")
                        .HasForeignKey("idPet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test_2.Models.Volunteer", "volunteer")
                        .WithMany("Volunteer_Pets")
                        .HasForeignKey("idVolunteer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
