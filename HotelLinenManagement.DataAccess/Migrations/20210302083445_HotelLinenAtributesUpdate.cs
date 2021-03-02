using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class HotelLinenAtributesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "HotelLinens",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HotelLinens",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "HotelLinens",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "HotelLinens");
        }
    }
}
