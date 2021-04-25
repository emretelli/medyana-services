using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medyana.Services.Api.Migrations
{
    public partial class MedyanaDbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolyclinicCode = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    DoctorRegistryCode = table.Column<int>(type: "int", fixedLength: true, maxLength: 8, nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DoctorSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false, comment: "1-Kadın 2-Erkek 3-Belirtilmemiş"),
                    CitizenshipNumber = table.Column<int>(type: "int", fixedLength: true, maxLength: 11, nullable: false),
                    TelephoneNumber = table.Column<int>(type: "int", fixedLength: true, maxLength: 10, nullable: false),
                    VisitationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextVisitationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorNote = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
