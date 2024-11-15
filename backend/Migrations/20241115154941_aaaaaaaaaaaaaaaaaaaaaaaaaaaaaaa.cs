using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0b463e61-be70-4386-8cac-86860e1d4916", "a1d46b38-282f-4996-8489-8d6192deab17" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b463e61-be70-4386-8cac-86860e1d4916");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1d46b38-282f-4996-8489-8d6192deab17");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "392a3a73-8728-4de6-a185-5eb7c71976b9", null, "admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "392a3a73-8728-4de6-a185-5eb7c71976b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b463e61-be70-4386-8cac-86860e1d4916", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackOfficeId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FrontOfficeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParticuliereHuurderId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZakelijkeHuurderId" },
                values: new object[] { "a1d46b38-282f-4996-8489-8d6192deab17", 0, null, "50f13eed-f7c0-455f-a06d-8e8545ca46f3", "admin@admin.com", true, null, false, null, "ADMIN@ADMIN.COM", "ADMIN", null, "AQAAAAIAAYagAAAAEPIhXVL5igU8vnYKZ1IV1+bZqayZkl6ZnE/5WwBiwSdBXpvyXLDoGgDD1V75eLiSgQ==", null, false, "8ddf1106-0795-40a0-b55c-91d63e840c34", false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0b463e61-be70-4386-8cac-86860e1d4916", "a1d46b38-282f-4996-8489-8d6192deab17" });
        }
    }
}
