using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class appuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c89311e5-e6ad-48e4-a4fb-679d9ad01b7e", "AQAAAAIAAYagAAAAEENwf1j0Oiy0l6PxmKjJwo8wP6WCv8BRlMl/gBrhPGC5GYg9r378IpqwEvq4+kQ4WA==", "12ecbb28-e1bf-4403-bbee-34eca7d337f4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4f31b45-bf1d-4765-9ca8-7f9f702a2486", "AQAAAAIAAYagAAAAEL0VXh2xrWeiR95m5oy6vkwklP5HqlKZqWFf1jbRdqEHt7rSOT/BXsbdN2T7gccF6Q==", "15d4ffa2-43f8-41b8-9afc-afd49ca284f9" });
        }
    }
}
