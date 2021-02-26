using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class ReversePreviousUdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_HotelId",
                table: "HotelLinens",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Hotels_HotelId",
                table: "HotelLinens",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Hotels_HotelId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_HotelId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelLinens");
        }
    }
}
