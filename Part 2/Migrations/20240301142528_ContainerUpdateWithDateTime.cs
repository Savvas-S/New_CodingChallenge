using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_part2.Migrations
{
    /// <inheritdoc />
    public partial class ContainerUpdateWithDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "imported_Date_Time",
                table: "Container",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imported_Date_Time",
                table: "Container");
        }
    }
}
