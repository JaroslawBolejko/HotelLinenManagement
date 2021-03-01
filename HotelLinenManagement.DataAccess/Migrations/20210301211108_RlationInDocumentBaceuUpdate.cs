using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class RlationInDocumentBaceuUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_GoodsIssuedNotes_GoodsIssuedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_GoodsReceivedNotes_GoodsReceivedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_LiquidationDocuments_LiquidationDocumentId",
                table: "HotelLinens");

            migrationBuilder.DropTable(
                name: "HotelLinenInvoice");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_GoodsIssuedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_GoodsReceivedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_LiquidationDocumentId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "GoodsIssuedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "GoodsReceivedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "LiquidationDocumentId",
                table: "HotelLinens");

            migrationBuilder.AddColumn<int>(
                name: "HotelLinenId",
                table: "LiquidationDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelLinenId",
                table: "Invices",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_LiquidationDocuments_HotelLinenId",
                table: "LiquidationDocuments",
                column: "HotelLinenId");

            migrationBuilder.CreateIndex(
                name: "IX_Invices_HotelLinenId",
                table: "Invices",
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
                name: "FK_Invices_HotelLinens_HotelLinenId",
                table: "Invices",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsIssuedNotes_HotelLinens_HotelLinenId",
                table: "GoodsIssuedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceivedNotes_HotelLinens_HotelLinenId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Invices_HotelLinens_HotelLinenId",
                table: "Invices");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidationDocuments_HotelLinens_HotelLinenId",
                table: "LiquidationDocuments");

            migrationBuilder.DropIndex(
                name: "IX_LiquidationDocuments_HotelLinenId",
                table: "LiquidationDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Invices_HotelLinenId",
                table: "Invices");

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
                table: "Invices");

            migrationBuilder.DropColumn(
                name: "HotelLinenId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropColumn(
                name: "HotelLinenId",
                table: "GoodsIssuedNotes");

            migrationBuilder.AddColumn<int>(
                name: "GoodsIssuedNoteId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoodsReceivedNoteId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LiquidationDocumentId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HotelLinenInvoice",
                columns: table => new
                {
                    HotelLinenId = table.Column<int>(type: "int", nullable: false),
                    InvicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelLinenInvoice", x => new { x.HotelLinenId, x.InvicesId });
                    table.ForeignKey(
                        name: "FK_HotelLinenInvoice_HotelLinens_HotelLinenId",
                        column: x => x.HotelLinenId,
                        principalTable: "HotelLinens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelLinenInvoice_Invices_InvicesId",
                        column: x => x.InvicesId,
                        principalTable: "Invices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_GoodsIssuedNoteId",
                table: "HotelLinens",
                column: "GoodsIssuedNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_GoodsReceivedNoteId",
                table: "HotelLinens",
                column: "GoodsReceivedNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_LiquidationDocumentId",
                table: "HotelLinens",
                column: "LiquidationDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinenInvoice_InvicesId",
                table: "HotelLinenInvoice",
                column: "InvicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_GoodsIssuedNotes_GoodsIssuedNoteId",
                table: "HotelLinens",
                column: "GoodsIssuedNoteId",
                principalTable: "GoodsIssuedNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_GoodsReceivedNotes_GoodsReceivedNoteId",
                table: "HotelLinens",
                column: "GoodsReceivedNoteId",
                principalTable: "GoodsReceivedNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_LiquidationDocuments_LiquidationDocumentId",
                table: "HotelLinens",
                column: "LiquidationDocumentId",
                principalTable: "LiquidationDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
