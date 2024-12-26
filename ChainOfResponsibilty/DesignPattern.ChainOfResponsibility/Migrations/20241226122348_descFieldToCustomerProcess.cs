using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignPattern.ChainOfResponsibility.Migrations
{
    /// <inheritdoc />
    public partial class descFieldToCustomerProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomerProcesses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerProcesses");
        }
    }
}
