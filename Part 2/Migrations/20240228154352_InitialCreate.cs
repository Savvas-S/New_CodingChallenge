using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_part2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ship",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ship", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    Shipid = table.Column<int>(type: "INTEGER", nullable: true),
                    Truckid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.id);
                    table.ForeignKey(
                        name: "FK_Container_Ship_Shipid",
                        column: x => x.Shipid,
                        principalTable: "Ship",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Container_Truck_Truckid",
                        column: x => x.Truckid,
                        principalTable: "Truck",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Container_Shipid",
                table: "Container",
                column: "Shipid");

            migrationBuilder.CreateIndex(
                name: "IX_Container_Truckid",
                table: "Container",
                column: "Truckid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "Ship");

            migrationBuilder.DropTable(
                name: "Truck");
        }
    }
}
