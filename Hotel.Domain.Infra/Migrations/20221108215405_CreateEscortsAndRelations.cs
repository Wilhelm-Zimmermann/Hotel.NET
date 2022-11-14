using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Domain.Infra.Migrations
{
    public partial class CreateEscortsAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "escorts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Relationship = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HotelGuestId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_escorts_hotel_guests_HotelGuestId",
                        column: x => x.HotelGuestId,
                        principalTable: "hotel_guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_escorts_HotelGuestId",
                table: "escorts",
                column: "HotelGuestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "escorts");
        }
    }
}
