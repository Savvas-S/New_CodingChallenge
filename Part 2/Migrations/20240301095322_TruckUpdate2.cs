using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_part2.Migrations
{
    /// <inheritdoc />
    public partial class TruckUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "offLoad",
                table: "Ship");

            migrationBuilder.AddColumn<int>(
                name: "offLoad",
                table: "Truck",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "offLoad",
                table: "Truck");

            migrationBuilder.AddColumn<int>(
                name: "offLoad",
                table: "Ship",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
