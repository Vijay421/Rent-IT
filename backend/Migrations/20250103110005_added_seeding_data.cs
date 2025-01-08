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
<<<<<<<< HEAD:backend/Migrations/20250103151240_added_seeding_data.cs
                    { "05bc708c-a700-4e36-b334-612271a9d565", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "71429550-a524-4484-a67f-e0859e4083f9", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "7f0a6bf3-694c-4aa9-8618-bacd2b25da79", null, "admin", "ADMIN" },
                    { "b44ea369-a68c-49f9-a9dc-5edf6cee2357", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "de3a98fd-3cb1-41cd-82a0-a57dddbbbd13", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "fb692bbd-1752-4cda-aac4-f53f20bbcdac", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" }
========
                    { "331432c4-bf46-49a2-ad3f-6555e991e74b", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "676a7de6-98ad-4f50-8341-2c5d80e8e8b8", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "a82f3097-cf66-4ccb-9408-943c22c7bbc1", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "b78963c3-e37d-47fd-8f0a-9da79045d92c", null, "admin", "ADMIN" },
                    { "bf99f5bc-350d-4b61-83e1-d44af454712b", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "f81d6348-6d24-4cd3-9666-e59fb26bb6cb", null, "particuliere_huurder", "PARTICULIERE_HUURDER" }
>>>>>>>> 1575ab05184df40321ba659834bb8c783f80a7fe:backend/Migrations/20250103110005_added_seeding_data.cs
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
<<<<<<<< HEAD:backend/Migrations/20250103151240_added_seeding_data.cs
                keyValue: "05bc708c-a700-4e36-b334-612271a9d565");
========
                keyValue: "331432c4-bf46-49a2-ad3f-6555e991e74b");
>>>>>>>> 1575ab05184df40321ba659834bb8c783f80a7fe:backend/Migrations/20250103110005_added_seeding_data.cs

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
<<<<<<<< HEAD:backend/Migrations/20250103151240_added_seeding_data.cs
                keyValue: "71429550-a524-4484-a67f-e0859e4083f9");
========
                keyValue: "676a7de6-98ad-4f50-8341-2c5d80e8e8b8");
>>>>>>>> 1575ab05184df40321ba659834bb8c783f80a7fe:backend/Migrations/20250103110005_added_seeding_data.cs

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
<<<<<<<< HEAD:backend/Migrations/20250103151240_added_seeding_data.cs
                keyValue: "7f0a6bf3-694c-4aa9-8618-bacd2b25da79");
========
                keyValue: "a82f3097-cf66-4ccb-9408-943c22c7bbc1");
>>>>>>>> 1575ab05184df40321ba659834bb8c783f80a7fe:backend/Migrations/20250103110005_added_seeding_data.cs

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
<<<<<<<< HEAD:backend/Migrations/20250103151240_added_seeding_data.cs
                keyValue: "b44ea369-a68c-49f9-a9dc-5edf6cee2357");
========
                keyValue: "b78963c3-e37d-47fd-8f0a-9da79045d92c");
>>>>>>>> 1575ab05184df40321ba659834bb8c783f80a7fe:backend/Migrations/20250103110005_added_seeding_data.cs

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
<<<<<<<< HEAD:backend/Migrations/20250103151240_added_seeding_data.cs
                keyValue: "de3a98fd-3cb1-41cd-82a0-a57dddbbbd13");
========
                keyValue: "bf99f5bc-350d-4b61-83e1-d44af454712b");
>>>>>>>> 1575ab05184df40321ba659834bb8c783f80a7fe:backend/Migrations/20250103110005_added_seeding_data.cs

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
<<<<<<<< HEAD:backend/Migrations/20250103151240_added_seeding_data.cs
                keyValue: "fb692bbd-1752-4cda-aac4-f53f20bbcdac");
========
                keyValue: "f81d6348-6d24-4cd3-9666-e59fb26bb6cb");
>>>>>>>> 1575ab05184df40321ba659834bb8c783f80a7fe:backend/Migrations/20250103110005_added_seeding_data.cs

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
