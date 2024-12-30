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
<<<<<<<< HEAD:backend/Migrations/20241229095854_added_seeding_data.cs
                    { "27652548-b1a3-4d5f-9866-738098777c36", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "3ee4fe72-e986-4b66-a4af-64214ad86773", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "575c4fb2-a0dd-40ae-b4f1-cdc6b1051433", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "990ef634-981b-4c58-994a-5c306b808f31", null, "admin", "ADMIN" },
                    { "effd4964-5eee-451a-b065-b7104cbe0fe2", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "fc78feb9-f89f-4015-bf41-33c59b017d63", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" }
========
                    { "1f7ce3b6-707e-406a-b9e7-06d4b7de25cb", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "384eab7b-056e-45ef-9983-f034300f3713", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "7d0e3067-e25b-4020-8c6f-d9d4ffe98280", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "e1d5fad1-4b5f-4185-b5df-48fd8283d66c", null, "admin", "ADMIN" },
                    { "e3c8727a-845e-490d-860e-2ac9d52f0532", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "f0d375e9-51e4-4cac-8c56-93736d2a8970", null, "particuliere_huurder", "PARTICULIERE_HUURDER" }
>>>>>>>> b026fd5 (added 2 endpoints):backend/Migrations/20241221094529_added_seeding_data.cs
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
<<<<<<<< HEAD:backend/Migrations/20241229095854_added_seeding_data.cs
                keyValue: "27652548-b1a3-4d5f-9866-738098777c36");
========
                keyValue: "1f7ce3b6-707e-406a-b9e7-06d4b7de25cb");
>>>>>>>> b026fd5 (added 2 endpoints):backend/Migrations/20241221094529_added_seeding_data.cs

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
<<<<<<<< HEAD:backend/Migrations/20241229095854_added_seeding_data.cs
                keyValue: "3ee4fe72-e986-4b66-a4af-64214ad86773");
========
                keyValue: "384eab7b-056e-45ef-9983-f034300f3713");
>>>>>>>> b026fd5 (added 2 endpoints):backend/Migrations/20241221094529_added_seeding_data.cs

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
<<<<<<<< HEAD:backend/Migrations/20241229095854_added_seeding_data.cs
                keyValue: "575c4fb2-a0dd-40ae-b4f1-cdc6b1051433");
========
                keyValue: "7d0e3067-e25b-4020-8c6f-d9d4ffe98280");
>>>>>>>> b026fd5 (added 2 endpoints):backend/Migrations/20241221094529_added_seeding_data.cs

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
<<<<<<<< HEAD:backend/Migrations/20241229095854_added_seeding_data.cs
                keyValue: "990ef634-981b-4c58-994a-5c306b808f31");
========
                keyValue: "e1d5fad1-4b5f-4185-b5df-48fd8283d66c");
>>>>>>>> b026fd5 (added 2 endpoints):backend/Migrations/20241221094529_added_seeding_data.cs

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
<<<<<<<< HEAD:backend/Migrations/20241229095854_added_seeding_data.cs
                keyValue: "effd4964-5eee-451a-b065-b7104cbe0fe2");
========
                keyValue: "e3c8727a-845e-490d-860e-2ac9d52f0532");
>>>>>>>> b026fd5 (added 2 endpoints):backend/Migrations/20241221094529_added_seeding_data.cs

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
<<<<<<<< HEAD:backend/Migrations/20241229095854_added_seeding_data.cs
                keyValue: "fc78feb9-f89f-4015-bf41-33c59b017d63");
========
                keyValue: "f0d375e9-51e4-4cac-8c56-93736d2a8970");
>>>>>>>> b026fd5 (added 2 endpoints):backend/Migrations/20241221094529_added_seeding_data.cs

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
