using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class added_roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "130dab9e-f9ca-496b-a65f-174bb31a7723");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2533523c-359c-4240-acff-2160d78c434d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c5a66fe-ef6f-4f48-8b71-e8153aa57507");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0d96e1a-d36a-4824-8339-2849da0854b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd225630-c191-40cf-85ce-4919de78cd3d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3554fdae-fe29-4c35-b63b-b895b9e858c6", null, "admin", "ADMIN" },
                    { "3c11627a-4d3a-4534-8bd8-68f896bfeb97", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "d25297b6-193d-4a48-ac58-5afafd86b534", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "e4620d6d-0936-4b01-8c85-313e5e6f3edb", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "f98b57b5-9812-48b2-8636-d1677d9ee707", null, "particuliere_huurder", "PARTICULIERE_HUURDER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3554fdae-fe29-4c35-b63b-b895b9e858c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c11627a-4d3a-4534-8bd8-68f896bfeb97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d25297b6-193d-4a48-ac58-5afafd86b534");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4620d6d-0936-4b01-8c85-313e5e6f3edb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f98b57b5-9812-48b2-8636-d1677d9ee707");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "130dab9e-f9ca-496b-a65f-174bb31a7723", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "2533523c-359c-4240-acff-2160d78c434d", null, "admin", "ADMIN" },
                    { "3c5a66fe-ef6f-4f48-8b71-e8153aa57507", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "a0d96e1a-d36a-4824-8339-2849da0854b2", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "cd225630-c191-40cf-85ce-4919de78cd3d", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" }
                });
        }
    }
}
