using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
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
                    { "23dbf9c8-1aee-4e4c-8da8-a03e0a5df0ba", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "4943517a-8d21-414f-9487-b3192b2a2737", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "63f22dc9-4a66-45a7-8c0f-3b684b7d5eb3", null, "admin", "ADMIN" },
                    { "806d4686-dcfc-40e0-8b6a-2175c0bc90f5", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "f09a99c6-253f-4761-b694-92aea36bef9c", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "fa4fa3d4-47ac-4afc-bba3-daaf36dc82f5", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" }
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
                keyValue: "23dbf9c8-1aee-4e4c-8da8-a03e0a5df0ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4943517a-8d21-414f-9487-b3192b2a2737");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63f22dc9-4a66-45a7-8c0f-3b684b7d5eb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "806d4686-dcfc-40e0-8b6a-2175c0bc90f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f09a99c6-253f-4761-b694-92aea36bef9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa4fa3d4-47ac-4afc-bba3-daaf36dc82f5");

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
