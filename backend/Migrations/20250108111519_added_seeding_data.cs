using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class added_seeding_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Abonnementen",
                columns: new[] { "Id", "Einddatum", "HuurbeheerderId", "Max_huurders", "Naam", "Prijs_per_maand", "Soort" },
                values: new object[] { 1, new DateOnly(2026, 1, 1), null, 10, "abbo", 12.199999999999999, "prepaid" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ec72cbf-c33c-42f5-86e9-0d92778799c4", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "54b76d7f-99ed-4149-9704-b1e7f9f87f52", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "65bfed1e-e108-4804-a13f-350c64004734", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "6c4bb2fd-8e96-4f0a-adad-941af6b2cab1", null, "admin", "ADMIN" },
                    { "e1db0835-d8e5-42d2-b7db-6f7c77c272ba", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "ee4ab947-9ecd-4ae1-a8e9-8e8c3575b3df", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" }
                });

            migrationBuilder.InsertData(
                table: "Voertuigen",
                columns: new[] { "Id", "Aanschafjaar", "EindDatum", "Kenteken", "Kleur", "Merk", "Opmerking", "Prijs", "Soort", "StartDatum", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 2018, new DateOnly(2025, 1, 4), "AB-123-CD", "Red", "Toyota", "", 50.0, "Auto", new DateOnly(2025, 1, 1), "Verhuurbaar", "Corolla" },
                    { 2, 2019, new DateOnly(2025, 1, 4), "EF-456-GH", "Blue", "Ford", "", 51.390000000000001, "Auto", new DateOnly(2025, 1, 1), "Verhuurbaar", "Focus" },
                    { 3, 2020, new DateOnly(2025, 1, 5), "IJ-789-KL", "Black", "Volkswagen", "", 40.0, "Auto", new DateOnly(2025, 1, 3), "Verhuurbaar", "Golf" },
                    { 105, 2021, new DateOnly(2025, 1, 24), "QR-345-ST", "Gray", "Citroën", "", 65.0, "Camper", new DateOnly(2025, 1, 10), "Verhuurbaar", "Jumper" },
                    { 106, 2016, new DateOnly(2025, 2, 4), "UV-678-WX", "Black", "Peugeot", "", 68.0, "Camper", new DateOnly(2025, 2, 1), "Verhuurbaar", "Boxer" },
                    { 185, 2020, new DateOnly(2025, 6, 7), "GH-456-IJ", "Blue", "Dethle-s", "", 52.5, "Caravan", new DateOnly(2025, 5, 1), "Verhuurbaar", "C'go" },
                    { 186, 2017, new DateOnly(2025, 8, 24), "KL-789-MN", "Red", "Burstner", "", 48.0, "Caravan", new DateOnly(2025, 8, 21), "Verhuurbaar", "Premio Life" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abonnementen",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ec72cbf-c33c-42f5-86e9-0d92778799c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54b76d7f-99ed-4149-9704-b1e7f9f87f52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65bfed1e-e108-4804-a13f-350c64004734");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c4bb2fd-8e96-4f0a-adad-941af6b2cab1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1db0835-d8e5-42d2-b7db-6f7c77c272ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee4ab947-9ecd-4ae1-a8e9-8e8c3575b3df");

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Voertuigen",
                keyColumn: "Id",
                keyValue: 186);
        }
    }
}
