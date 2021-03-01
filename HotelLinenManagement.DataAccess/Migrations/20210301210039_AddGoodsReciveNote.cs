using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class AddGoodsReciveNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Invices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoodsReceivedNoteId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GoodsReceivedNotes",
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
                    table.PrimaryKey("PK_GoodsReceivedNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsReceivedNotes_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invices_HotelId",
                table: "Invices",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_GoodsReceivedNoteId",
                table: "HotelLinens",
                column: "GoodsReceivedNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_HotelId",
                table: "HotelLinens",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_HotelId",
                table: "GoodsReceivedNotes",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_GoodsReceivedNotes_GoodsReceivedNoteId",
                table: "HotelLinens",
                column: "GoodsReceivedNoteId",
                principalTable: "GoodsReceivedNotes",
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
                name: "FK_Invices_Hotels_HotelId",
                table: "Invices",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_GoodsReceivedNotes_GoodsReceivedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Hotels_HotelId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_Invices_Hotels_HotelId",
                table: "Invices");

            migrationBuilder.DropTable(
                name: "GoodsReceivedNotes");

            migrationBuilder.DropIndex(
                name: "IX_Invices_HotelId",
                table: "Invices");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_GoodsReceivedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_HotelId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Invices");

            migrationBuilder.DropColumn(
                name: "GoodsReceivedNoteId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelLinens");
        }
    }
}
