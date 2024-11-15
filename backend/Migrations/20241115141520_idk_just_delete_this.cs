using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class idk_just_delete_this : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "47850829-1841-43b9-b489-8e7dcbeed05b", "793e1513-20a7-4ff8-ae69-3c149e75cf6a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47850829-1841-43b9-b489-8e7dcbeed05b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "793e1513-20a7-4ff8-ae69-3c149e75cf6a");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "47850829-1841-43b9-b489-8e7dcbeed05b", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackOfficeId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FrontOfficeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParticuliereHuurderId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZakelijkeHuurderId" },
                values: new object[] { "793e1513-20a7-4ff8-ae69-3c149e75cf6a", 0, null, "27c0f839-2786-4783-b7c6-fbf8156a1fc7", "admin@example.com", true, null, false, null, "ADMIN@ADMIN.COM", "ADMIN", null, "AQAAAAIAAYagAAAAEP5n1EbqH078hdOsGc9xZM4kcOCNOgxWQ4GggyEBDABr1DUVSlZSCqGj8VmbCuYcEw==", null, false, "59ed1cfe-3ac2-44d6-8c84-3b65d6baa8e2", false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "47850829-1841-43b9-b489-8e7dcbeed05b", "793e1513-20a7-4ff8-ae69-3c149e75cf6a" });
        }
    }
}
