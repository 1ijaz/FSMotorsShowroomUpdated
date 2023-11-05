using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "159066c2-91f5-492d-aa7a-c8733dfc558e");

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4a2d7490-e348-49ff-b987-fa9c6c26f222", 0, null, "1df52778-b804-4e46-a37e-428cf711d079", "ApplicationUser", "Admin@gmail.com", false, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEJnmMaGqtrch986CUF5aZB15qXQUX5mdNAAAVcsnczxxt9RCBdCh1CVF8W8YtkV5Nw==", null, false, "Admin", "fd235c26-4e9e-4bef-bd94-68d6fcc39a03", false, "Admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2d7490-e348-49ff-b987-fa9c6c26f222");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "159066c2-91f5-492d-aa7a-c8733dfc558e", 0, null, "13dc8662-6452-4b8c-8d5f-ffa5da5c0bab", "ApplicationUser", "Admin@gmail.com", false, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEEYT2AXdtin8Ty9m28r564oEunn1x396LQyjOZiCUEr0Y0iI66up3sxjisRZF3Y16w==", null, false, "Admin", "c3c7656f-9cea-4076-9ba3-979beeba9026", false, "Admin@gmail.com" });
        }
    }
}
