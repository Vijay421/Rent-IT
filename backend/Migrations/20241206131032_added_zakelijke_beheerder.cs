using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class added_zakelijke_beheerder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "009d6e93-e0d8-4156-910d-991f290b4c8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13f8ee81-9a9d-4538-901d-e93e935d49f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "778e336e-eb96-4583-926e-05ce1e93253d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "809c00fc-7456-4104-b888-df3a4d36d809");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c57c93f4-835b-491f-b1f0-44370867b655");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5242156-aa1b-4b6c-b709-e0c97043b079");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d8807a6-02b5-4410-9a13-5d35ca12c469", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d8807a6-02b5-4410-9a13-5d35ca12c469");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "009d6e93-e0d8-4156-910d-991f290b4c8f", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "13f8ee81-9a9d-4538-901d-e93e935d49f3", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "778e336e-eb96-4583-926e-05ce1e93253d", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "809c00fc-7456-4104-b888-df3a4d36d809", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "c57c93f4-835b-491f-b1f0-44370867b655", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "e5242156-aa1b-4b6c-b709-e0c97043b079", null, "admin", "ADMIN" }
                });
        }
    }
}
