using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class added_huurders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BackOffice_BackOfficeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FrontOffice_FrontOfficeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BackOffice");

            migrationBuilder.DropTable(
                name: "FrontOffice");

            migrationBuilder.AddColumn<string>(
                name: "ParticuliereHuurderId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZakelijkeHuurderId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BackOfficeMedewerker",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackOfficeMedewerker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrontOfficeMedewerker",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontOfficeMedewerker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticuliereHuurder",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticuliereHuurder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZakelijkeHuurder",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZakelijkeHuurder", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ParticuliereHuurderId",
                table: "AspNetUsers",
                column: "ParticuliereHuurderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ZakelijkeHuurderId",
                table: "AspNetUsers",
                column: "ZakelijkeHuurderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BackOfficeMedewerker_BackOfficeId",
                table: "AspNetUsers",
                column: "BackOfficeId",
                principalTable: "BackOfficeMedewerker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FrontOfficeMedewerker_FrontOfficeId",
                table: "AspNetUsers",
                column: "FrontOfficeId",
                principalTable: "FrontOfficeMedewerker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ParticuliereHuurder_ParticuliereHuurderId",
                table: "AspNetUsers",
                column: "ParticuliereHuurderId",
                principalTable: "ParticuliereHuurder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ZakelijkeHuurder_ZakelijkeHuurderId",
                table: "AspNetUsers",
                column: "ZakelijkeHuurderId",
                principalTable: "ZakelijkeHuurder",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BackOfficeMedewerker_BackOfficeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FrontOfficeMedewerker_FrontOfficeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ParticuliereHuurder_ParticuliereHuurderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ZakelijkeHuurder_ZakelijkeHuurderId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BackOfficeMedewerker");

            migrationBuilder.DropTable(
                name: "FrontOfficeMedewerker");

            migrationBuilder.DropTable(
                name: "ParticuliereHuurder");

            migrationBuilder.DropTable(
                name: "ZakelijkeHuurder");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ParticuliereHuurderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ZakelijkeHuurderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ParticuliereHuurderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZakelijkeHuurderId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "BackOffice",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackOffice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrontOffice",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontOffice", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BackOffice_BackOfficeId",
                table: "AspNetUsers",
                column: "BackOfficeId",
                principalTable: "BackOffice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FrontOffice_FrontOfficeId",
                table: "AspNetUsers",
                column: "FrontOfficeId",
                principalTable: "FrontOffice",
                principalColumn: "Id");
        }
    }
}
