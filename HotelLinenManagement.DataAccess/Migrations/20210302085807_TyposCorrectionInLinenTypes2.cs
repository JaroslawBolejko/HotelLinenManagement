using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class TyposCorrectionInLinenTypes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinienTypes_HotelLinens_HotelLinenId",
                table: "LinenTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_LinienTypes_Storerooms_StoreroomId",
                table: "LinenTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinienTypes",
                table: "LinenTypes");

            migrationBuilder.RenameTable(
                name: "LinenTypes",
                newName: "LinenTypes");

            migrationBuilder.RenameIndex(
                name: "IX_LinienTypes_StoreroomId",
                table: "LinenTypes",
                newName: "IX_LinenTypes_StoreroomId");

            migrationBuilder.RenameIndex(
                name: "IX_LinienTypes_HotelLinenId",
                table: "LinenTypes",
                newName: "IX_LinenTypes_HotelLinenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinenTypes",
                table: "LinenTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinenTypes_HotelLinens_HotelLinenId",
                table: "LinenTypes",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LinenTypes_Storerooms_StoreroomId",
                table: "LinenTypes",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinenTypes_HotelLinens_HotelLinenId",
                table: "LinenTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_LinenTypes_Storerooms_StoreroomId",
                table: "LinenTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinenTypes",
                table: "LinenTypes");

            migrationBuilder.RenameTable(
                name: "LinenTypes",
                newName: "LinenTypes");

            migrationBuilder.RenameIndex(
                name: "IX_LinenTypes_StoreroomId",
                table: "LinenTypes",
                newName: "IX_LinienTypes_StoreroomId");

            migrationBuilder.RenameIndex(
                name: "IX_LinenTypes_HotelLinenId",
                table: "LinenTypes",
                newName: "IX_LinienTypes_HotelLinenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinienTypes",
                table: "LinenTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinienTypes_HotelLinens_HotelLinenId",
                table: "LinenTypes",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LinienTypes_Storerooms_StoreroomId",
                table: "LinenTypes",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
