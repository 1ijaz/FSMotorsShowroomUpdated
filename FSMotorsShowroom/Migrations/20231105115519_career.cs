using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class career : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f06ff69-183c-4e4e-8724-e21be0c88f59");

            migrationBuilder.CreateTable(
                name: "careers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_careers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "159066c2-91f5-492d-aa7a-c8733dfc558e", 0, null, "13dc8662-6452-4b8c-8d5f-ffa5da5c0bab", "ApplicationUser", "Admin@gmail.com", false, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEEYT2AXdtin8Ty9m28r564oEunn1x396LQyjOZiCUEr0Y0iI66up3sxjisRZF3Y16w==", null, false, "Admin", "c3c7656f-9cea-4076-9ba3-979beeba9026", false, "Admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "careers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "159066c2-91f5-492d-aa7a-c8733dfc558e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0f06ff69-183c-4e4e-8724-e21be0c88f59", 0, null, "3c01d753-2d7f-4e93-8e62-fc725be7b312", "ApplicationUser", "Admin@gmail.com", false, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKY73KYTKQ80TjEV1yaLMfTSTOCmXwO3Uh5yXeIzLLnN5GVgtHVgpMpyz18GS61xmQ==", null, false, "Admin", "cc941625-c3a5-44d2-bb10-285bdc6f2c35", false, "Admin@gmail.com" });
        }
    }
}
