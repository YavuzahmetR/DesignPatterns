using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignPattern.Mediator.Migrations
{
    /// <inheritdoc />
    public partial class stockType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StockType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockType",
                table: "Products");
        }
    }
}
