using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class idk_just_delete_this_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6dbece94-a05b-47a8-95af-8eec3ba0b77f", "935b949c-c866-4f81-939d-7638ddd6b336" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dbece94-a05b-47a8-95af-8eec3ba0b77f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "935b949c-c866-4f81-939d-7638ddd6b336");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "6dbece94-a05b-47a8-95af-8eec3ba0b77f", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackOfficeId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FrontOfficeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParticuliereHuurderId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZakelijkeHuurderId" },
                values: new object[] { "935b949c-c866-4f81-939d-7638ddd6b336", 0, null, "e5726f9b-0ade-485f-ad70-f938f1767011", "admin@admin.com", true, null, false, null, "ADMIN@ADMIN.COM", "ADMIN", null, "AQAAAAIAAYagAAAAEBiFT0ne7FPvN+zBGbgJb9jTN2KEbhGByR4EmQNdOo+RaheTve4LaFelHllB3Z+0aw==", null, false, "07c678b9-42ac-4756-9c2b-a97bf59f370d", false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6dbece94-a05b-47a8-95af-8eec3ba0b77f", "935b949c-c866-4f81-939d-7638ddd6b336" });
        }
    }
}
