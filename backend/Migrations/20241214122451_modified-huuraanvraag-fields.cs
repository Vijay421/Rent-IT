using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class modifiedhuuraanvraagfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huuraanvragen_Voertuigen_VoertuigId",
                table: "Huuraanvragen");

            migrationBuilder.AlterColumn<int>(
                name: "VoertuigId",
                table: "Huuraanvragen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Startdatum",
                table: "Huuraanvragen",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Einddatum",
                table: "Huuraanvragen",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Huuraanvragen_Voertuigen_VoertuigId",
                table: "Huuraanvragen",
                column: "VoertuigId",
                principalTable: "Voertuigen",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huuraanvragen_Voertuigen_VoertuigId",
                table: "Huuraanvragen");

            migrationBuilder.AlterColumn<int>(
                name: "VoertuigId",
                table: "Huuraanvragen",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Startdatum",
                table: "Huuraanvragen",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Einddatum",
                table: "Huuraanvragen",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_Huuraanvragen_Voertuigen_VoertuigId",
                table: "Huuraanvragen",
                column: "VoertuigId",
                principalTable: "Voertuigen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
