using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    /// <inheritdoc />
    public partial class addworkshops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkShop",
                table: "WorkShop");

            migrationBuilder.RenameTable(
                name: "WorkShop",
                newName: "workShops");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workShops",
                table: "workShops",
                column: "WorkShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_workShops",
                table: "workShops");

            migrationBuilder.RenameTable(
                name: "workShops",
                newName: "WorkShop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkShop",
                table: "WorkShop",
                column: "WorkShopId");
        }
    }
}
