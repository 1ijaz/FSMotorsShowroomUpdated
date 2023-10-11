using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class updatetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_categories_CategoryId",
                table: "cars");

            migrationBuilder.DropForeignKey(
                name: "FK_cars_users_InvestorId",
                table: "cars");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_users_InvestorUserId",
                table: "transactions");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropIndex(
                name: "IX_transactions_InvestorUserId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_cars_CategoryId",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_InvestorId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "userTypes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "users");

            migrationBuilder.DropColumn(
                name: "InvestmentAmount",
                table: "users");

            migrationBuilder.DropColumn(
                name: "InvestmentDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "InvestmentStatus",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TotalProfit",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UnAllocatedAmout",
                table: "users");

            migrationBuilder.DropColumn(
                name: "InvestorUserId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "cars");

            migrationBuilder.RenameColumn(
                name: "UserType_Id",
                table: "userTypes",
                newName: "UserTypeId");

            migrationBuilder.RenameColumn(
                name: "InvestorId",
                table: "cars",
                newName: "PassangerCapacity");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "cars",
                newName: "Doors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cars",
                newName: "CarId");

            migrationBuilder.AlterColumn<decimal>(
                name: "ShowroomCost",
                table: "cars",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SellingPrice",
                table: "cars",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SalesTax",
                table: "cars",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaintananceCost",
                table: "cars",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BuyingPrice",
                table: "cars",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BackImage",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyImage",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarModelId",
                table: "cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarStatus",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineImage",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontImage",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoresPower",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InteriorImage",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MakeCompany",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MakeYear",
                table: "cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NoOfCylinders",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TankCapacity",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransmissionMode",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "carModels",
                columns: table => new
                {
                    CarModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carModels", x => x.CarModelId);
                });

            migrationBuilder.CreateTable(
                name: "investors",
                columns: table => new
                {
                    InvestorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestorEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestorContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_investors", x => x.InvestorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_CarModelId",
                table: "cars",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_carModels_CarModelId",
                table: "cars",
                column: "CarModelId",
                principalTable: "carModels",
                principalColumn: "CarModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_carModels_CarModelId",
                table: "cars");

            migrationBuilder.DropTable(
                name: "carModels");

            migrationBuilder.DropTable(
                name: "investors");

            migrationBuilder.DropIndex(
                name: "IX_cars_CarModelId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "BackImage",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "BodyImage",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "CarStatus",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "EngineImage",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "FrontImage",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "HoresPower",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "InteriorImage",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "MakeCompany",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "MakeYear",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "NoOfCylinders",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "TankCapacity",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "TransmissionMode",
                table: "cars");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "userTypes",
                newName: "UserType_Id");

            migrationBuilder.RenameColumn(
                name: "PassangerCapacity",
                table: "cars",
                newName: "InvestorId");

            migrationBuilder.RenameColumn(
                name: "Doors",
                table: "cars",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "cars",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "userTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "InvestmentAmount",
                table: "users",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InvestmentDate",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvestmentStatus",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalProfit",
                table: "users",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnAllocatedAmout",
                table: "users",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvestorUserId",
                table: "transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShowroomCost",
                table: "cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SellingPrice",
                table: "cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalesTax",
                table: "cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaintananceCost",
                table: "cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuyingPrice",
                table: "cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doors = table.Column<int>(type: "int", nullable: false),
                    EngineImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelMilage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoresPower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteriorImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakeCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakeYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfCylinders = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassangerCapacity = table.Column<int>(type: "int", nullable: false),
                    TankCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransmissionMode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_InvestorUserId",
                table: "transactions",
                column: "InvestorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_CategoryId",
                table: "cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_InvestorId",
                table: "cars",
                column: "InvestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_categories_CategoryId",
                table: "cars",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_users_InvestorId",
                table: "cars",
                column: "InvestorId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_users_InvestorUserId",
                table: "transactions",
                column: "InvestorUserId",
                principalTable: "users",
                principalColumn: "UserId");
        }
    }
}
