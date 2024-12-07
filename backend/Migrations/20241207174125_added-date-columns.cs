using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class addeddatecolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ea696d4-b933-467f-85a1-01fb543dec8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f687e54-015a-4f03-8978-19a86acb35d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "652ae5f0-3da9-4a4a-84f5-9d12a75f3405");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b62a363-6418-4127-b90c-f064edcc16aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b510e06e-e8bf-4d28-8135-98c53fa27472");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f92fe0bf-c4ef-48fc-82ec-86ecaa88c72f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12d3330d-24c9-4e63-8716-67b2fda97f45", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "245b3d69-8518-4f59-9291-6eda0fad3509", null, "admin", "ADMIN" },
                    { "3c0af0be-bb61-4bbd-9ad9-6bb8dc63b6ea", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "7bf944b8-7d77-41f1-94f0-cf3090a22b60", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "a8489479-8f30-4d6a-8bc6-c3612e1bb023", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "eedb6def-bbad-4b9b-9347-d7fa6d112259", null, "particuliere_huurder", "PARTICULIERE_HUURDER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12d3330d-24c9-4e63-8716-67b2fda97f45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "245b3d69-8518-4f59-9291-6eda0fad3509");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c0af0be-bb61-4bbd-9ad9-6bb8dc63b6ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bf944b8-7d77-41f1-94f0-cf3090a22b60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8489479-8f30-4d6a-8bc6-c3612e1bb023");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eedb6def-bbad-4b9b-9347-d7fa6d112259");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ea696d4-b933-467f-85a1-01fb543dec8d", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "3f687e54-015a-4f03-8978-19a86acb35d9", null, "admin", "ADMIN" },
                    { "652ae5f0-3da9-4a4a-84f5-9d12a75f3405", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "6b62a363-6418-4127-b90c-f064edcc16aa", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "b510e06e-e8bf-4d28-8135-98c53fa27472", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "f92fe0bf-c4ef-48fc-82ec-86ecaa88c72f", null, "particuliere_huurder", "PARTICULIERE_HUURDER" }
                });
        }
    }
}
