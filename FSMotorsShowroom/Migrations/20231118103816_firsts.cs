using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class firsts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdb203aa-8382-4920-9f35-e907da96c49c");

            migrationBuilder.AddColumn<string>(
                name: "TransactionName",
                table: "transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2e35a59d-3f2e-4ceb-96fd-bf3ba64fe9fb", 0, null, "f854aa96-144b-4376-9dc8-14cdf269409b", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBUqtm5d67/vI+TJ1QE2jsGKvO4AqOEprjRo5wGT2PxSn/XrlM9RVKe2cDb8hi/Pag==", null, false, "Admin", "e92df0c8-17fb-4718-8907-868755b8255d", false, "Admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e35a59d-3f2e-4ceb-96fd-bf3ba64fe9fb");

            migrationBuilder.DropColumn(
                name: "TransactionName",
                table: "transactions");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bdb203aa-8382-4920-9f35-e907da96c49c", 0, null, "1a9635dc-42e3-4efc-ae48-6f83bee9fb8e", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEAhy02x4vhJIvif6O9+J5rRD3GQ0+sP5CWzrz/LtTn7wa7RobI1HgyQCPBdpkKjc/g==", null, false, "Admin", "7cd0224b-baa7-47aa-a2ac-eebbbbd7a5b1", false, "Admin@gmail.com" });
        }
    }
}
