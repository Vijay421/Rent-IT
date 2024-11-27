using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class createdvoertuigdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bedrijven");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2de163ac-d38e-4bdd-9a65-8f34810dd084");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50e651aa-fbe0-4e34-9677-511d8d0788d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72127a9e-7d62-4bb8-8f53-c61226e6ee3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c993550f-9a1f-4c18-8c80-98ace06abf18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e54b5a49-73f1-466a-b6f1-bbaca6a62b3b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.CreateTable(
                name: "Voertuigen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Merk = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Kenteken = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Kleur = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Aanschafjaar = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Soort = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Opmerking = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voertuigen", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bd528a1-17a1-47cc-afe8-463def6bf1f7", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "6e8e4617-13f3-4d5a-9dba-b627bf7f6bde", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "9862ee43-a40b-48b6-acf2-aef39e4775de", null, "admin", "ADMIN" },
                    { "ae9e3d91-59a2-4e6c-8a41-9acace7ad820", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "ca45e2b3-891b-4a99-a5c4-a7e862b4d2a0", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" }
                });

            migrationBuilder.InsertData(
                table: "Voertuigen",
                columns: new[] { "Id", "Aanschafjaar", "Kenteken", "Kleur", "Merk", "Opmerking", "Soort", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 2018, "AB-123-CD", "Red", "Toyota", "", "Auto", "Verhuurbaar", "Corolla" },
                    { 2, 2019, "EF-456-GH", "Blue", "Ford", "", "Auto", "Verhuurbaar", "Focus" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voertuigen");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bd528a1-17a1-47cc-afe8-463def6bf1f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e8e4617-13f3-4d5a-9dba-b627bf7f6bde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9862ee43-a40b-48b6-acf2-aef39e4775de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae9e3d91-59a2-4e6c-8a41-9acace7ad820");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca45e2b3-891b-4a99-a5c4-a7e862b4d2a0");

            migrationBuilder.CreateTable(
                name: "Bedrijven",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrijven", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2de163ac-d38e-4bdd-9a65-8f34810dd084", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "50e651aa-fbe0-4e34-9677-511d8d0788d3", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "72127a9e-7d62-4bb8-8f53-c61226e6ee3b", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "c993550f-9a1f-4c18-8c80-98ace06abf18", null, "admin", "ADMIN" },
                    { "e54b5a49-73f1-466a-b6f1-bbaca6a62b3b", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackOfficeId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FrontOfficeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParticuliereHuurderId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZakelijkeHuurderId" },
                values: new object[] { "1", 0, null, "QJ9Z", "test@email.com", true, null, true, null, "TEST@EMAIL.COM", "USER1", null, "AQAAAAEAACcQAAAAEJ9Z", "1234567890", true, "QJ9Z", false, "user1", null });

            migrationBuilder.InsertData(
                table: "Bedrijven",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Bedrijf1", "1234567890" },
                    { 2, "Bedrijf2", "1234567891" },
                    { 3, "Bedrijf3", "1234567892" }
                });
        }
    }
}
