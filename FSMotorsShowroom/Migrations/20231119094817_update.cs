using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b393f32-7a95-46a3-b010-3d0cd8c3c12f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "de3facc2-a281-40ad-bc90-6d53cd89b4fe", 0, null, "d98016c3-155c-451b-be6c-2dd5957e1d6c", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEK/SHtXqTNRB63txXVGKNkhUXiXYjH6YPBTrLJjyGea4IBeyh83s8LwSoPLG1gOuHA==", null, false, "Admin", "abb24f10-e1b3-4f8e-af54-fddba397f811", false, "Admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de3facc2-a281-40ad-bc90-6d53cd89b4fe");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4b393f32-7a95-46a3-b010-3d0cd8c3c12f", 0, null, "eaa18fa5-5563-4be8-9f7c-705679b2091a", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAELxKlpNPiUqRJO0g1pqI7vBz1OqTEOxpQ+cYloQb2CopFVqbLLQKzBFZIOXQQmdEVg==", null, false, "Admin", "59369b44-090f-4113-8b62-406b027f98ba", false, "Admin@gmail.com" });
        }
    }
}
