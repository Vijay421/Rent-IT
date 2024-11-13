using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class added_identity_roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "326f39c4-29e3-4724-ab1a-7443161904c7", null, "admin", "ADMIN" },
                    { "67eeb0fd-93b2-4654-9ac6-e5ade590bdd0", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "7da5d1a2-7883-4de2-84bd-01e4d69f2c93", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "c651ef8e-79a4-4108-b43e-9f4a69c2fbf3", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "ebec270d-50e9-4aeb-81f0-99a40ad3a9cd", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "326f39c4-29e3-4724-ab1a-7443161904c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67eeb0fd-93b2-4654-9ac6-e5ade590bdd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7da5d1a2-7883-4de2-84bd-01e4d69f2c93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c651ef8e-79a4-4108-b43e-9f4a69c2fbf3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebec270d-50e9-4aeb-81f0-99a40ad3a9cd");
        }
    }
}
