using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class added_admin__account : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "QJ9Z", "test@email.com", true, true, null, "TEST@EMAIL.COM", "ADMIN1", "AQAAAAEAACcQAAAAEJ9Z", "1234567890", true, "QJ9Z", false, "admin1" },
                    { "2", 0, "QJ9Z", "test@email.com", true, true, null, "TEST@EMAIL.COM", "USER1", "AQAAAAEAACcQAAAAEJ9Z", "1234567890", true, "QJ9Z", false, "user1" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                column: "Id",
                value: "1");

            migrationBuilder.InsertData(
                table: "Users",
                column: "Id",
                value: "2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
