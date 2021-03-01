using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class AddGoodsIssuedAndLiquidationDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoodsIssuedNoteId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LiquidationDocumentId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GoodsIssuedNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsIssuedNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsIssuedNotes_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LiquidationDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidationDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiquidationDocuments_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_GoodsIssuedNoteId",
                table: "HotelLinens",
                column: "GoodsIssuedNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_LiquidationDocumentId",
                table: "HotelLinens",
                column: "LiquidationDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedNotes_HotelId",
                table: "GoodsIssuedNotes",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidationDocuments_HotelId",
                table: "LiquidationDocuments",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_GoodsIssuedNotes_GoodsIssuedNoteId",
                table: "HotelLinens",
                column: "GoodsIssuedNoteId",
                principalTable: "GoodsIssuedNotes",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_GoodsIssuedNotes_GoodsIssuedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_LiquidationDocuments_LiquidationDocumentId",
                table: "HotelLinens");

            migrationBuilder.DropTable(
                name: "GoodsIssuedNotes");

            migrationBuilder.DropTable(
                name: "LiquidationDocuments");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_GoodsIssuedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_LiquidationDocumentId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "GoodsIssuedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "LiquidationDocumentId",
                table: "HotelLinens");
        }
    }
}
