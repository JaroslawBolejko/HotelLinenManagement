using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class AddLaundry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaundryId",
                table: "Storerooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaundryId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Laundries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReciptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LaundryLinienType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LaundryLinienAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laundries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Storerooms_LaundryId",
                table: "Storerooms",
                column: "LaundryId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_LaundryId",
                table: "HotelLinens",
                column: "LaundryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Laundries_LaundryId",
                table: "HotelLinens",
                column: "LaundryId",
                principalTable: "Laundries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Storerooms_Laundries_LaundryId",
                table: "Storerooms",
                column: "LaundryId",
                principalTable: "Laundries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Laundries_LaundryId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_Storerooms_Laundries_LaundryId",
                table: "Storerooms");

            migrationBuilder.DropTable(
                name: "Laundries");

            migrationBuilder.DropIndex(
                name: "IX_Storerooms_LaundryId",
                table: "Storerooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_LaundryId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "LaundryId",
                table: "Storerooms");

            migrationBuilder.DropColumn(
                name: "LaundryId",
                table: "HotelLinens");
        }
    }
}
