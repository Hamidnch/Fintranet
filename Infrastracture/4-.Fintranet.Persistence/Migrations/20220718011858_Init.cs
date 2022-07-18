using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4_.Fintranet.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nch");

            migrationBuilder.CreateTable(
                name: "DoctorOffices",
                schema: "nch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    Phone1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    WhatsUp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "getdate()"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorOffices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "nch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalSystemNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BusinessMobileNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    PersonalMobileNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    PhoneNumber = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    TurningMethod = table.Column<byte>(type: "tinyint", nullable: true),
                    MedicalHistory = table.Column<int>(type: "int", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, computedColumnSql: "[LastName] + ', ' + [FirstName]"),
                    GenderType = table.Column<byte>(type: "tinyint", maxLength: 1, nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastIpAddress = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastLoginDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastActivityDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "nch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNumber = table.Column<Guid>(type: "uniqueidentifier", maxLength: 20, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, computedColumnSql: "[LastName] + ', ' + [FirstName]"),
                    GenderType = table.Column<byte>(type: "tinyint", maxLength: 1, nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastIpAddress = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastLoginDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastActivityDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorDoctorOfficeMapping",
                schema: "nch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doctor_Id = table.Column<int>(type: "int", nullable: false),
                    DoctorOffice_Id = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "getdate()"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDoctorOfficeMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorDoctorOfficeMapping_DoctorOffices_DoctorOffice_Id",
                        column: x => x.DoctorOffice_Id,
                        principalSchema: "nch",
                        principalTable: "DoctorOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorDoctorOfficeMapping_Doctors_Doctor_Id",
                        column: x => x.Doctor_Id,
                        principalSchema: "nch",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDoctorOfficeMapping_Doctor_Id",
                schema: "nch",
                table: "DoctorDoctorOfficeMapping",
                column: "Doctor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDoctorOfficeMapping_DoctorOffice_Id",
                schema: "nch",
                table: "DoctorDoctorOfficeMapping",
                column: "DoctorOffice_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Email_MedicalSystemNumber",
                schema: "nch",
                table: "Doctors",
                columns: new[] { "Email", "MedicalSystemNumber" },
                unique: true,
                filter: "[Email] IS NOT NULL AND [MedicalSystemNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_FirstName_LastName_DateOfBirth",
                schema: "nch",
                table: "Doctors",
                columns: new[] { "FirstName", "LastName", "DateOfBirth" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Email_DocumentNumber",
                schema: "nch",
                table: "Patients",
                columns: new[] { "Email", "DocumentNumber" },
                unique: true,
                filter: "[Email] IS NOT NULL AND [DocumentNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorDoctorOfficeMapping",
                schema: "nch");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "nch");

            migrationBuilder.DropTable(
                name: "DoctorOffices",
                schema: "nch");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "nch");
        }
    }
}
