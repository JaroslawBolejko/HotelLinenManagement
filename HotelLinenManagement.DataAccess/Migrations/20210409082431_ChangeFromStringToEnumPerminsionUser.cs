using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class ChangeFromStringToEnumPerminsionUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Permission",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Permission",
                table: "Users",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
