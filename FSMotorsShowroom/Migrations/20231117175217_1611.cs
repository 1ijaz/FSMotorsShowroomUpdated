using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class _1611 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd5c6816-3454-4682-9a9f-97d8a4861e38");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "af1f29cc-4fc4-4b57-81e5-21910eb6ef17", 0, null, "361b3e48-d9d2-4bde-9c98-79d407b9db00", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEOtJ3sZo1MeA3U6EaVU5EHx8AvRpPvOe9cCFC6ZTJ34ZT7epOiEsve+psS+1DmU9sg==", null, false, "Admin", "bfc6c294-7234-44cb-9cd1-f2f372e7c6f7", false, "Admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af1f29cc-4fc4-4b57-81e5-21910eb6ef17");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bd5c6816-3454-4682-9a9f-97d8a4861e38", 0, null, "1375d9de-a16d-4a0b-8916-0956bcbc667a", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEOLEtmiEODBmEM+GL80LbHcKiaoCNrPTgOmFGDQOyT3+8MmKXKjBeeabLncWIF57UA==", null, false, "Admin", "a2bc500f-494b-4000-bf63-945317c80fc3", false, "Admin@gmail.com" });
        }
    }
}
