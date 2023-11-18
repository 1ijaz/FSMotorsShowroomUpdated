using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class _1811 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af1f29cc-4fc4-4b57-81e5-21910eb6ef17");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2551ecf4-210a-44a1-b1ef-19b939883135", 0, null, "874de4c9-1e1b-4c29-a572-5ada6858b75c", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEFbzvyHOxA6tXajGH9xqKUZQ7OVkYQga4TCjZZ56i9to9VX/nDb143Kre6VMLIGgXw==", null, false, "Admin", "52a44368-fa87-40d8-8999-a0539c68cb59", false, "Admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2551ecf4-210a-44a1-b1ef-19b939883135");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "af1f29cc-4fc4-4b57-81e5-21910eb6ef17", 0, null, "361b3e48-d9d2-4bde-9c98-79d407b9db00", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEOtJ3sZo1MeA3U6EaVU5EHx8AvRpPvOe9cCFC6ZTJ34ZT7epOiEsve+psS+1DmU9sg==", null, false, "Admin", "bfc6c294-7234-44cb-9cd1-f2f372e7c6f7", false, "Admin@gmail.com" });
        }
    }
}
