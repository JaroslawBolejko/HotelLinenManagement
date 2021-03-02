using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class AddRelationInStoreroomUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreroomId",
                table: "LiquidationDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreroomId",
                table: "LinenTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreroomId",
                table: "Invices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreroomId",
                table: "GoodsReceivedNotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreroomId",
                table: "GoodsIssuedNotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiquidationDocuments_StoreroomId",
                table: "LiquidationDocuments",
                column: "StoreroomId");

            migrationBuilder.CreateIndex(
                name: "IX_LinienTypes_StoreroomId",
                table: "LinenTypes",
                column: "StoreroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Invices_StoreroomId",
                table: "Invices",
                column: "StoreroomId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_StoreroomId",
                table: "GoodsReceivedNotes",
                column: "StoreroomId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedNotes_StoreroomId",
                table: "GoodsIssuedNotes",
                column: "StoreroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsIssuedNotes_Storerooms_StoreroomId",
                table: "GoodsIssuedNotes",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceivedNotes_Storerooms_StoreroomId",
                table: "GoodsReceivedNotes",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invices_Storerooms_StoreroomId",
                table: "Invices",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LinienTypes_Storerooms_StoreroomId",
                table: "LinenTypes",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidationDocuments_Storerooms_StoreroomId",
                table: "LiquidationDocuments",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsIssuedNotes_Storerooms_StoreroomId",
                table: "GoodsIssuedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceivedNotes_Storerooms_StoreroomId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Invices_Storerooms_StoreroomId",
                table: "Invices");

            migrationBuilder.DropForeignKey(
                name: "FK_LinienTypes_Storerooms_StoreroomId",
                table: "LinenTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidationDocuments_Storerooms_StoreroomId",
                table: "LiquidationDocuments");

            migrationBuilder.DropIndex(
                name: "IX_LiquidationDocuments_StoreroomId",
                table: "LiquidationDocuments");

            migrationBuilder.DropIndex(
                name: "IX_LinienTypes_StoreroomId",
                table: "LinenTypes");

            migrationBuilder.DropIndex(
                name: "IX_Invices_StoreroomId",
                table: "Invices");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceivedNotes_StoreroomId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssuedNotes_StoreroomId",
                table: "GoodsIssuedNotes");

            migrationBuilder.DropColumn(
                name: "StoreroomId",
                table: "LiquidationDocuments");

            migrationBuilder.DropColumn(
                name: "StoreroomId",
                table: "LinenTypes");

            migrationBuilder.DropColumn(
                name: "StoreroomId",
                table: "Invices");

            migrationBuilder.DropColumn(
                name: "StoreroomId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropColumn(
                name: "StoreroomId",
                table: "GoodsIssuedNotes");
        }
    }
}
