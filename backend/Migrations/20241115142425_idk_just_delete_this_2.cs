using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class idk_just_delete_this_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2af1f800-cc31-4188-8f3c-0bcc46f9d48a", "679b89c6-e409-4a53-9cd8-ac554c2be6d9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2af1f800-cc31-4188-8f3c-0bcc46f9d48a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "679b89c6-e409-4a53-9cd8-ac554c2be6d9");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2af1f800-cc31-4188-8f3c-0bcc46f9d48a", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackOfficeId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FrontOfficeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParticuliereHuurderId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZakelijkeHuurderId" },
                values: new object[] { "679b89c6-e409-4a53-9cd8-ac554c2be6d9", 0, null, "0a99f706-ddef-42e0-a893-5260ce78940c", "admin@admin.com", true, null, false, null, "ADMIN@ADMIN.COM", "ADMIN", null, "AQAAAAIAAYagAAAAEGj3jNTzeY/OIR1OC7mIqsnXwlRXevfMTPauFj/wZO1VcyhopxTjW3BC5BOVpguUEw==", null, false, "c3980fa8-95a1-4cb8-b364-440ffb2213b1", false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2af1f800-cc31-4188-8f3c-0bcc46f9d48a", "679b89c6-e409-4a53-9cd8-ac554c2be6d9" });
        }
    }
}
