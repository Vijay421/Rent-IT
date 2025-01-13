using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class seeding_data : Migration
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
                    { "05ca4174-b818-497c-8f3b-bb9e5d350974", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "1f79e728-1017-4e46-91c3-c37adfeed9c4", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "5b890112-3bb3-420c-8185-a8979bf09dfe", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "8a3772a7-22b7-48e6-b3fa-64feb9024984", null, "admin", "ADMIN" },
                    { "8e6e0e22-3b27-43fb-8c92-292f1e30b6f7", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "f0d38323-95f9-467e-b2e4-7cc8f546f152", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" }
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
                keyValue: "05ca4174-b818-497c-8f3b-bb9e5d350974");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f79e728-1017-4e46-91c3-c37adfeed9c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b890112-3bb3-420c-8185-a8979bf09dfe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a3772a7-22b7-48e6-b3fa-64feb9024984");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e6e0e22-3b27-43fb-8c92-292f1e30b6f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0d38323-95f9-467e-b2e4-7cc8f546f152");

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
