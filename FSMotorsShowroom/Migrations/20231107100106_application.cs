using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class application : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8bc66ce1-5de1-4694-905e-51a8b9e841d8");

            migrationBuilder.DropColumn(
                name: "BuyerAddress",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "BuyerContact",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "Profit",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "transactions",
                newName: "Amount");

            migrationBuilder.AddColumn<decimal>(
                name: "InvestUnallocatedAmount",
                table: "investors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalInvestAmount",
                table: "investors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    higEducation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    careerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.id);
                    table.ForeignKey(
                        name: "FK_applications_careers_careerId",
                        column: x => x.careerId,
                        principalTable: "careers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dba8dbff-49fc-4c47-a6d7-21baf4722730", 0, null, "460b3c14-b8e2-4bfb-b1c4-05af4165cea2", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAECr0aI7zOCFkGhuXbeXipG2D+MnHFQf5ED1z9cJr5qi4sbxIbe/rLUGzEmtdyb1Sbw==", null, false, "Admin", "8803283d-659f-43e3-a759-387c580d8526", false, "Admin@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_applications_careerId",
                table: "applications",
                column: "careerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dba8dbff-49fc-4c47-a6d7-21baf4722730");

            migrationBuilder.DropColumn(
                name: "InvestUnallocatedAmount",
                table: "investors");

            migrationBuilder.DropColumn(
                name: "TotalInvestAmount",
                table: "investors");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "transactions",
                newName: "CarId");

            migrationBuilder.AddColumn<string>(
                name: "BuyerAddress",
                table: "transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuyerContact",
                table: "transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuyerName",
                table: "transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Profit",
                table: "transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TaxRate",
                table: "transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "transactions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8bc66ce1-5de1-4694-905e-51a8b9e841d8", 0, null, "35c8d4b5-1953-4840-9291-437e42a16971", "ApplicationUser", "Admin@gmail.com", true, "Hamza", "Khan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENs3j26RLoiTQwEqjHHW1mVFcIklOxW/rnpnKHOWYfIkjSEHQN3S9InxxI38aqWxvw==", null, false, "Admin", "c5064caa-9eca-417e-b7e9-a1d461100d08", false, "Admin@gmail.com" });
        }
    }
}
