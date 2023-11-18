using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class fr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e35a59d-3f2e-4ceb-96fd-bf3ba64fe9fb");

            migrationBuilder.AddColumn<decimal>(
                name: "ProfitPriceOfCarCost",
                table: "cars",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "743ec831-b35c-469f-90e7-41186f715b5e", 0, null, "16b17105-d121-4382-a527-331b86d62d15", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEPFKRWRTxeWCtzflecyM3yRI7H3KkvErfzFJ3EPrL1Jpn9yiKmVAtC2wa7CtW8eWww==", null, false, "Admin", "7faea65a-f7ca-4cea-af19-1dab7a235e32", false, "Admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "743ec831-b35c-469f-90e7-41186f715b5e");

            migrationBuilder.DropColumn(
                name: "ProfitPriceOfCarCost",
                table: "cars");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2e35a59d-3f2e-4ceb-96fd-bf3ba64fe9fb", 0, null, "f854aa96-144b-4376-9dc8-14cdf269409b", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBUqtm5d67/vI+TJ1QE2jsGKvO4AqOEprjRo5wGT2PxSn/XrlM9RVKe2cDb8hi/Pag==", null, false, "Admin", "e92df0c8-17fb-4718-8907-868755b8255d", false, "Admin@gmail.com" });
        }
    }
}
