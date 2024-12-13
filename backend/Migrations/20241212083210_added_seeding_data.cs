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
                    { "0e7a69fc-16c9-442e-aa9c-11e68dfbc403", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "235552f8-37d5-46da-bd12-5a7acf16eb8d", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "30a7c14c-be46-49c6-aba3-0d8e02aa17a6", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "b85f24fe-eb41-4e05-bea4-670338125d6a", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "bbb664b3-c236-4e9e-97ef-da87362d1364", null, "admin", "ADMIN" },
                    { "efbe61c3-9004-4b6a-bc91-bca7af8704fe", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" }
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
                keyValue: "0e7a69fc-16c9-442e-aa9c-11e68dfbc403");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "235552f8-37d5-46da-bd12-5a7acf16eb8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30a7c14c-be46-49c6-aba3-0d8e02aa17a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b85f24fe-eb41-4e05-bea4-670338125d6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb664b3-c236-4e9e-97ef-da87362d1364");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efbe61c3-9004-4b6a-bc91-bca7af8704fe");

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
