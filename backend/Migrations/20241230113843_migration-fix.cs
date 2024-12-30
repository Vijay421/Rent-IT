using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class migrationfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ZakelijkeHuurders_ZakelijkeHuurderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ZakelijkeHuurderId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27652548-b1a3-4d5f-9866-738098777c36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ee4fe72-e986-4b66-a4af-64214ad86773");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "575c4fb2-a0dd-40ae-b4f1-cdc6b1051433");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "990ef634-981b-4c58-994a-5c306b808f31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "effd4964-5eee-451a-b065-b7104cbe0fe2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc78feb9-f89f-4015-bf41-33c59b017d63");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Voertuigen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "ZakelijkeHuurderId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schadeclaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoertuigId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schadeclaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schadeclaims_Voertuigen_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voertuigregistraties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoertuigId = table.Column<int>(type: "int", nullable: false),
                    Inname = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voertuigregistraties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voertuigregistraties_Voertuigen_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuigen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15e83a12-17d8-4a74-88e9-b9ff8324e336", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "2f26bb85-50c3-49c4-bb77-e8eea36ac16b", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" },
                    { "7a864fa4-19c3-42be-aa8b-a49b4512ea8d", null, "admin", "ADMIN" },
                    { "83dc68c1-9990-41e5-abbe-1ce95612bbc9", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "9701bccf-e3cd-49e3-aa24-27ad8e66a28e", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "dbb36049-7d38-4c1e-b9bd-2073b780e1c8", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ZakelijkeHuurderId1",
                table: "AspNetUsers",
                column: "ZakelijkeHuurderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Schadeclaims_VoertuigId",
                table: "Schadeclaims",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Voertuigregistraties_VoertuigId",
                table: "Voertuigregistraties",
                column: "VoertuigId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ZakelijkeHuurders_ZakelijkeHuurderId1",
                table: "AspNetUsers",
                column: "ZakelijkeHuurderId1",
                principalTable: "ZakelijkeHuurders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ZakelijkeHuurders_ZakelijkeHuurderId1",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Schadeclaims");

            migrationBuilder.DropTable(
                name: "Voertuigregistraties");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ZakelijkeHuurderId1",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15e83a12-17d8-4a74-88e9-b9ff8324e336");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f26bb85-50c3-49c4-bb77-e8eea36ac16b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a864fa4-19c3-42be-aa8b-a49b4512ea8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83dc68c1-9990-41e5-abbe-1ce95612bbc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9701bccf-e3cd-49e3-aa24-27ad8e66a28e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbb36049-7d38-4c1e-b9bd-2073b780e1c8");

            migrationBuilder.DropColumn(
                name: "ZakelijkeHuurderId1",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Voertuigen",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27652548-b1a3-4d5f-9866-738098777c36", null, "backoffice_medewerker", "BACKOFFICE_MEDEWERKER" },
                    { "3ee4fe72-e986-4b66-a4af-64214ad86773", null, "zakelijke_huurder", "ZAKELIJKE_HUURDER" },
                    { "575c4fb2-a0dd-40ae-b4f1-cdc6b1051433", null, "particuliere_huurder", "PARTICULIERE_HUURDER" },
                    { "990ef634-981b-4c58-994a-5c306b808f31", null, "admin", "ADMIN" },
                    { "effd4964-5eee-451a-b065-b7104cbe0fe2", null, "zakelijke_beheerder", "ZAKELIJKE_BEHEERDER" },
                    { "fc78feb9-f89f-4015-bf41-33c59b017d63", null, "frontoffice_medewerker", "FRONTOFFICE_MEDEWERKER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ZakelijkeHuurderId",
                table: "AspNetUsers",
                column: "ZakelijkeHuurderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ZakelijkeHuurders_ZakelijkeHuurderId",
                table: "AspNetUsers",
                column: "ZakelijkeHuurderId",
                principalTable: "ZakelijkeHuurders",
                principalColumn: "Id");
        }
    }
}
