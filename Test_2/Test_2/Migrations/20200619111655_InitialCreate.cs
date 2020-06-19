using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreedTypes",
                columns: table => new
                {
                    IdBreedType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedTypes", x => x.IdBreedType);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    IdVolunteer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSupervisor = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Surname = table.Column<string>(maxLength: 80, nullable: false),
                    Phone = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    VolunteerInstIdVolunteer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.IdVolunteer);
                    table.ForeignKey(
                        name: "FK_Volunteers_Volunteers_VolunteerInstIdVolunteer",
                        column: x => x.VolunteerInstIdVolunteer,
                        principalTable: "Volunteers",
                        principalColumn: "IdVolunteer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    IdPet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBreedType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    IsMale = table.Column<bool>(nullable: false),
                    DateRegistered = table.Column<DateTime>(nullable: false),
                    ApproximateDateOfBirth = table.Column<DateTime>(nullable: false),
                    DateAdopted = table.Column<DateTime>(nullable: false),
                    BreedTypeIdBreedType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.IdPet);
                    table.ForeignKey(
                        name: "FK_Pets_BreedTypes_BreedTypeIdBreedType",
                        column: x => x.BreedTypeIdBreedType,
                        principalTable: "BreedTypes",
                        principalColumn: "IdBreedType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer_Pets",
                columns: table => new
                {
                    idVolunteer = table.Column<int>(nullable: false),
                    idPet = table.Column<int>(nullable: false),
                    DateAccepted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer_Pets", x => new { x.idVolunteer, x.idPet });
                    table.ForeignKey(
                        name: "FK_Volunteer_Pets_Pets_idPet",
                        column: x => x.idPet,
                        principalTable: "Pets",
                        principalColumn: "IdPet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Volunteer_Pets_Volunteers_idVolunteer",
                        column: x => x.idVolunteer,
                        principalTable: "Volunteers",
                        principalColumn: "IdVolunteer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BreedTypeIdBreedType",
                table: "Pets",
                column: "BreedTypeIdBreedType");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_Pets_idPet",
                table: "Volunteer_Pets",
                column: "idPet");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_VolunteerInstIdVolunteer",
                table: "Volunteers",
                column: "VolunteerInstIdVolunteer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteer_Pets");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "BreedTypes");
        }
    }
}
