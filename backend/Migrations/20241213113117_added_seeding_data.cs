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
                    { "344d7da8-500d-493a-92aa-5c6b80057e02", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "7c0e96b3-5a27-4aa3-8546-50c716fa2d73", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "860d6dfc-bd84-4702-95f1-afdf484a7f8d", null, "admin", "ADMIN" },
                    { "87da7358-570b-498b-8b1e-23c475d29df5", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "c68d2cc5-3a9b-491c-82a0-a2bced7464be", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "fbd1bd38-d6eb-421f-ac63-224369647304", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" }
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
                keyValue: "344d7da8-500d-493a-92aa-5c6b80057e02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c0e96b3-5a27-4aa3-8546-50c716fa2d73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "860d6dfc-bd84-4702-95f1-afdf484a7f8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87da7358-570b-498b-8b1e-23c475d29df5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c68d2cc5-3a9b-491c-82a0-a2bced7464be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbd1bd38-d6eb-421f-ac63-224369647304");

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
