using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class addinvestmenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "investments",
                columns: table => new
                {
                    InvestmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaintananceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShowroomCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoldDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    InvestorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_investments", x => x.InvestmentId);
                    table.ForeignKey(
                        name: "FK_investments_cars_CarId",
                        column: x => x.CarId,
                        principalTable: "cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_investments_investors_InvestorId",
                        column: x => x.InvestorId,
                        principalTable: "investors",
                        principalColumn: "InvestorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_investments_CarId",
                table: "investments",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_investments_InvestorId",
                table: "investments",
                column: "InvestorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "investments");
        }
    }
}
