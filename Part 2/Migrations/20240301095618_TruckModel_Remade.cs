using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_part2.Migrations
{
    /// <inheritdoc />
    public partial class TruckModel_Remade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "offLoad",
                table: "Truck");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "offLoad",
                table: "Truck",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
