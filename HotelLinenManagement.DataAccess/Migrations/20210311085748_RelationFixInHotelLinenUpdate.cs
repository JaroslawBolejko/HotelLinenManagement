using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class RelationFixInHotelLinenUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsIssuedNotes_HotelLinens_HotelLinenId",
                table: "GoodsIssuedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceivedNotes_HotelLinens_HotelLinenId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Hotels_HotelId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidationDocuments_HotelLinens_HotelLinenId",
                table: "LiquidationDocuments");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_LiquidationDocuments_HotelLinenId",
                table: "LiquidationDocuments");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceivedNotes_HotelLinenId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssuedNotes_HotelLinenId",
                table: "GoodsIssuedNotes");

            migrationBuilder.DropColumn(
                name: "HotelLinenId",
                table: "LiquidationDocuments");

            migrationBuilder.DropColumn(
                name: "HotelLinenId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropColumn(
                name: "HotelLinenId",
                table: "GoodsIssuedNotes");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "HotelLinens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "HotelLinenId",
                table: "LiquidationDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "HotelLinens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HotelLinenId",
                table: "GoodsReceivedNotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelLinenId",
                table: "GoodsIssuedNotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiquidationDocuments_HotelLinenId",
                table: "LiquidationDocuments",
                column: "HotelLinenId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_HotelLinenId",
                table: "GoodsReceivedNotes",
                column: "HotelLinenId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedNotes_HotelLinenId",
                table: "GoodsIssuedNotes",
                column: "HotelLinenId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsIssuedNotes_HotelLinens_HotelLinenId",
                table: "GoodsIssuedNotes",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceivedNotes_HotelLinens_HotelLinenId",
                table: "GoodsReceivedNotes",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Hotels_HotelId",
                table: "HotelLinens",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidationDocuments_HotelLinens_HotelLinenId",
                table: "LiquidationDocuments",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
