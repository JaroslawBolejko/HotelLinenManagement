﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class InvoiceHotelLinenRelationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelLinenInvoice");

            migrationBuilder.AddColumn<int>(
                name: "HotelLinenId",
                table: "Invices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invices_HotelLinenId",
                table: "Invices",
                column: "HotelLinenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invices_HotelLinens_HotelLinenId",
                table: "Invices",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invices_HotelLinens_HotelLinenId",
                table: "Invices");

            migrationBuilder.DropIndex(
                name: "IX_Invices_HotelLinenId",
                table: "Invices");

            migrationBuilder.DropColumn(
                name: "HotelLinenId",
                table: "Invices");

            migrationBuilder.CreateTable(
                name: "HotelLinenInvoice",
                columns: table => new
                {
                    HotelLinensId = table.Column<int>(type: "int", nullable: false),
                    InvicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelLinenInvoice", x => new { x.HotelLinensId, x.InvicesId });
                    table.ForeignKey(
                        name: "FK_HotelLinenInvoice_HotelLinens_HotelLinensId",
                        column: x => x.HotelLinensId,
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
                name: "IX_HotelLinenInvoice_InvicesId",
                table: "HotelLinenInvoice",
                column: "InvicesId");
        }
    }
}
