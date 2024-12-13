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
                columns: new[] { "Id", "Einddatum", "Max_huurders", "Naam", "Prijs_per_maand", "Soort" },
                values: new object[] { 1, new DateOnly(2026, 1, 1), 10, "abbo", 12.199999999999999, "prepaid" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09b7e096-c863-4309-a6c7-b252d99167ae", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "14255037-edd4-423d-b3e2-42cb886939ba", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "6894fdbc-943e-4146-a95f-7603daef5660", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "d73c6189-7c77-47fc-9fdf-5904e8b876c9", null, "admin", "ADMIN" },
                    { "e7ce95d3-49aa-449f-a37f-eae9145897f6", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "e81a5518-9daa-4dee-a8e0-f8539d0a2be7", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" }
                });

            migrationBuilder.InsertData(
                table: "Voertuigen",
                columns: new[] { "Id", "Aanschafjaar", "EindDatum", "Kenteken", "Kleur", "Merk", "Opmerking", "Prijs", "Soort", "StartDatum", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 2018, new DateOnly(2016, 4, 12), "AB-123-CD", "Red", "Toyota", "", 50.0, "Auto", new DateOnly(2012, 2, 24), "Verhuurbaar", "Corolla" },
                    { 2, 2019, new DateOnly(2020, 8, 12), "EF-456-GH", "Blue", "Ford", "", 51.390000000000001, "Auto", new DateOnly(2017, 4, 3), "Verhuurbaar", "Focus" },
                    { 3, 2020, new DateOnly(2024, 11, 9), "IJ-789-KL", "Black", "Volkswagen", "", 40.0, "Auto", new DateOnly(2019, 10, 12), "Verhuurbaar", "Golf" },
                    { 105, 2021, new DateOnly(2016, 4, 12), "QR-345-ST", "Gray", "Citroën", "", 65.0, "Camper", new DateOnly(2012, 2, 24), "Verhuurbaar", "Jumper" },
                    { 106, 2016, new DateOnly(2016, 4, 12), "UV-678-WX", "Black", "Peugeot", "", 68.0, "Camper", new DateOnly(2012, 2, 24), "Verhuurbaar", "Boxer" },
                    { 185, 2020, new DateOnly(2016, 4, 12), "GH-456-IJ", "Blue", "Dethle-s", "", 52.5, "Caravan", new DateOnly(2012, 2, 24), "Verhuurbaar", "C'go" },
                    { 186, 2017, new DateOnly(2016, 4, 12), "KL-789-MN", "Red", "Burstner", "", 48.0, "Caravan", new DateOnly(2012, 2, 24), "Verhuurbaar", "Premio Life" }
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
                keyValue: "09b7e096-c863-4309-a6c7-b252d99167ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14255037-edd4-423d-b3e2-42cb886939ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6894fdbc-943e-4146-a95f-7603daef5660");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d73c6189-7c77-47fc-9fdf-5904e8b876c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7ce95d3-49aa-449f-a37f-eae9145897f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e81a5518-9daa-4dee-a8e0-f8539d0a2be7");

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
