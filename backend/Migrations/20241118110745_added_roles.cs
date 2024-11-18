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
                keyValue: "5eab4cab-b84a-4a14-b95c-7920d8354aa9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83d40d7c-db62-4acd-ae4d-3c939240cfb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c815ec6e-8e75-4f68-87dd-4aa874e7d871");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e69a863b-26e9-49e7-b7b7-c71c69247115");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8e922ed-6e1c-4228-beeb-484c0b9e089a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "410cc187-b6dd-49bc-8023-144a00e05d58", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "a40ea996-32b7-4cdc-ab08-ba561d372814", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "a90a301e-585d-455e-9447-3e04a016fe57", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "e277a8e7-db76-41ca-969f-cadc77a8a181", null, "admin", "ADMIN" },
                    { "fc49af1a-1f3e-4baa-b536-ef2ea9f1c65e", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410cc187-b6dd-49bc-8023-144a00e05d58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a40ea996-32b7-4cdc-ab08-ba561d372814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a90a301e-585d-455e-9447-3e04a016fe57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e277a8e7-db76-41ca-969f-cadc77a8a181");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc49af1a-1f3e-4baa-b536-ef2ea9f1c65e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5eab4cab-b84a-4a14-b95c-7920d8354aa9", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "83d40d7c-db62-4acd-ae4d-3c939240cfb2", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "c815ec6e-8e75-4f68-87dd-4aa874e7d871", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "e69a863b-26e9-49e7-b7b7-c71c69247115", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "e8e922ed-6e1c-4228-beeb-484c0b9e089a", null, "admin", "ADMIN" }
                });
        }
    }
}
