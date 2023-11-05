using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class finals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2d7490-e348-49ff-b987-fa9c6c26f222");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8bc66ce1-5de1-4694-905e-51a8b9e841d8", 0, null, "35c8d4b5-1953-4840-9291-437e42a16971", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENs3j26RLoiTQwEqjHHW1mVFcIklOxW/rnpnKHOWYfIkjSEHQN3S9InxxI38aqWxvw==", null, false, "Admin", "c5064caa-9eca-417e-b7e9-a1d461100d08", false, "Admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8bc66ce1-5de1-4694-905e-51a8b9e841d8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4a2d7490-e348-49ff-b987-fa9c6c26f222", 0, null, "1df52778-b804-4e46-a37e-428cf711d079", "ApplicationUser", "Admin@gmail.com", false, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEJnmMaGqtrch986CUF5aZB15qXQUX5mdNAAAVcsnczxxt9RCBdCh1CVF8W8YtkV5Nw==", null, false, "Admin", "fd235c26-4e9e-4bef-bd94-68d6fcc39a03", false, "Admin@gmail.com" });
        }
    }
}
