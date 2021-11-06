using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Texi_Booking.Migrations
{
    public partial class taxi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    taxiid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Taxi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taxiname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Taxinumer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentPerKm = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxi", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Taxi");
        }
    }
}
