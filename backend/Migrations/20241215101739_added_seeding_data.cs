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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f13735c-4647-4944-8125-fda037f682e2", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "1fb00f4c-cf4a-4786-9e35-068f1175919a", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "51af771d-91fe-44b0-bb5c-9b6c6ba58f9f", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "6dc6571e-eb96-4e9c-810c-f3a1f2487203", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "6df26f47-11ea-41ce-a2f7-fd9726d65289", null, "admin", "ADMIN" },
                    { "a1c9eadf-0334-427f-9766-bd4ed9e4e914", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" }
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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f13735c-4647-4944-8125-fda037f682e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fb00f4c-cf4a-4786-9e35-068f1175919a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51af771d-91fe-44b0-bb5c-9b6c6ba58f9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dc6571e-eb96-4e9c-810c-f3a1f2487203");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6df26f47-11ea-41ce-a2f7-fd9726d65289");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1c9eadf-0334-427f-9766-bd4ed9e4e914");

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
