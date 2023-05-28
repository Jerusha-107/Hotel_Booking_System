using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Booking_System.Migrations.HR
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarRating = table.Column<int>(type: "int", nullable: false),
                    HPrice = table.Column<int>(type: "int", nullable: false),
                    HEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAvailability = table.Column<bool>(type: "bit", nullable: false),
                    RPrice = table.Column<int>(type: "int", nullable: false),
                    RCapacity = table.Column<int>(type: "int", nullable: false),
                    RView = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasWifi = table.Column<bool>(type: "bit", nullable: false),
                    HId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RId);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HId",
                        column: x => x.HId,
                        principalTable: "Hotels",
                        principalColumn: "HId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HId",
                table: "Rooms",
                column: "HId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
