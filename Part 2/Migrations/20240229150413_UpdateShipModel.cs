using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_part2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShipModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "maxLoad",
                table: "Ship",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maxLoad",
                table: "Ship");
        }
    }
}
