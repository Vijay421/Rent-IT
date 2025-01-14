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
                columns: new[] { "Id", "Einddatum", "Geaccepteerd", "HuurbeheerderId", "Max_huurders", "Naam", "Prijs_per_maand", "Reden", "Soort" },
                values: new object[] { 1, new DateOnly(2026, 1, 1), null, null, 10, "abbo", 12.199999999999999, null, "prepaid" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0985a118-7759-4cf4-b9f2-b29087d1a247", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "25995955-a4b5-4b10-8e5e-a47b7f8dce53", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "3e22c81c-fed9-4211-b8ce-a74f1dfb823b", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "5c9fd841-75b4-469d-a6cd-831cb4b21f43", null, "admin", "ADMIN" },
                    { "8c0aba69-353d-4fa9-a628-dfd7cc1e79b9", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "d151c634-0f0d-4074-9382-d81d3eaddf24", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" }
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
                keyValue: "0985a118-7759-4cf4-b9f2-b29087d1a247");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25995955-a4b5-4b10-8e5e-a47b7f8dce53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e22c81c-fed9-4211-b8ce-a74f1dfb823b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c9fd841-75b4-469d-a6cd-831cb4b21f43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c0aba69-353d-4fa9-a628-dfd7cc1e79b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d151c634-0f0d-4074-9382-d81d3eaddf24");

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
