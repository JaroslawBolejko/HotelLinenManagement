using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class AddAtributeStoreroomIdInHotelLinen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Storerooms_StoreroomId",
                table: "HotelLinens");

            migrationBuilder.AlterColumn<int>(
                name: "StoreroomId",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Storerooms_StoreroomId",
                table: "HotelLinens",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Storerooms_StoreroomId",
                table: "HotelLinens");

            migrationBuilder.AlterColumn<int>(
                name: "StoreroomId",
                table: "HotelLinens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Storerooms_StoreroomId",
                table: "HotelLinens",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
