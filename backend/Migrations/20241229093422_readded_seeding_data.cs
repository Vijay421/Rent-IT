using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class readded_seeding_data : Migration
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
                    { "15b3152a-acb9-4feb-8c8e-0d637a2b9d1a", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "187ba111-e08c-4aad-b950-5a33ee065624", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "200f2863-59ba-4ce0-9182-048e702aedde", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "4546610f-b957-43ae-850b-adbc7385df36", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "7808e9f9-ad6e-4b3e-bd57-f8050676f4e4", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "98374cba-110e-4252-9382-ac372c1d5f9a", null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Voertuigen",
                columns: new[] { "Id", "Aanschafjaar", "Kenteken", "Kleur", "Merk", "Opmerking", "Prijs", "Soort", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 2018, "AB-123-CD", "Red", "Toyota", "", 50.0, "Auto", "Verhuurbaar", "Corolla" },
                    { 2, 2019, "EF-456-GH", "Blue", "Ford", "", 51.390000000000001, "Auto", "Verhuurbaar", "Focus" },
                    { 3, 2020, "IJ-789-KL", "Black", "Volkswagen", "", 40.0, "Auto", "Verhuurbaar", "Golf" },
                    { 105, 2021, "QR-345-ST", "Gray", "Citroën", "", 65.0, "Camper", "Verhuurbaar", "Jumper" },
                    { 106, 2016, "UV-678-WX", "Black", "Peugeot", "", 68.0, "Camper", "Verhuurbaar", "Boxer" },
                    { 185, 2020, "GH-456-IJ", "Blue", "Dethle-s", "", 52.5, "Caravan", "Verhuurbaar", "C'go" },
                    { 186, 2017, "KL-789-MN", "Red", "Burstner", "", 48.0, "Caravan", "Verhuurbaar", "Premio Life" }
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
                keyValue: "15b3152a-acb9-4feb-8c8e-0d637a2b9d1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "187ba111-e08c-4aad-b950-5a33ee065624");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "200f2863-59ba-4ce0-9182-048e702aedde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4546610f-b957-43ae-850b-adbc7385df36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7808e9f9-ad6e-4b3e-bd57-f8050676f4e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98374cba-110e-4252-9382-ac372c1d5f9a");

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
