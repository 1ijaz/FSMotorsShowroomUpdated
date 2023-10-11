using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakeCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakeYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfCylinders = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoresPower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransmissionMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TankCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doors = table.Column<int>(type: "int", nullable: false),
                    PassangerCapacity = table.Column<int>(type: "int", nullable: false),
                    FuelMilage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteriorImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Showroom",
                columns: table => new
                {
                    ShowroomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowroomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowroomAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showroom", x => x.ShowroomId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvestmentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvestmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvestmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnAllocatedAmout = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "userTypes",
                columns: table => new
                {
                    UserType_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTypes", x => x.UserType_Id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelMilage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyingPrice = table.Column<int>(type: "int", nullable: false),
                    SellingPrice = table.Column<int>(type: "int", nullable: true),
                    MaintananceCost = table.Column<int>(type: "int", nullable: true),
                    ShowroomCost = table.Column<int>(type: "int", nullable: true),
                    SalesTax = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvestorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cars_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cars_users_InvestorId",
                        column: x => x.InvestorId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyerContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxRate = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Profit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestorUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_users_InvestorUserId",
                        column: x => x.InvestorUserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_CategoryId",
                table: "cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_InvestorId",
                table: "cars",
                column: "InvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_InvestorUserId",
                table: "transactions",
                column: "InvestorUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "Showroom");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "userTypes");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
