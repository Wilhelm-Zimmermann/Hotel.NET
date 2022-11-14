using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Domain.Infra.Migrations
{
    public partial class DeleteOnCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_escorts_hotel_guests_HotelGuestId",
                table: "escorts");

            migrationBuilder.AddForeignKey(
                name: "FK_escorts_hotel_guests_HotelGuestId",
                table: "escorts",
                column: "HotelGuestId",
                principalTable: "hotel_guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_escorts_hotel_guests_HotelGuestId",
                table: "escorts");

            migrationBuilder.AddForeignKey(
                name: "FK_escorts_hotel_guests_HotelGuestId",
                table: "escorts",
                column: "HotelGuestId",
                principalTable: "hotel_guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
