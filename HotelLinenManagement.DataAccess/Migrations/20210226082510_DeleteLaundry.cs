using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class DeleteLaundry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "LinenAmount",
                table: "Storerooms");

            migrationBuilder.DropColumn(
                name: "LinenType",
                table: "Storerooms");

            migrationBuilder.DropColumn(
                name: "LaundryId",
                table: "HotelLinens");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Storerooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReciptDate",
                table: "Storerooms",
                type: "datetime2",
                maxLength: 250,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "LinienWeight",
                table: "HotelLinens",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Storerooms");

            migrationBuilder.DropColumn(
                name: "ReciptDate",
                table: "Storerooms");

            migrationBuilder.DropColumn(
                name: "LinienWeight",
                table: "HotelLinens");

            migrationBuilder.AddColumn<int>(
                name: "LaundryId",
                table: "Storerooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LinenAmount",
                table: "Storerooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LinenType",
                table: "Storerooms",
                type: "nvarchar(250)",
                maxLength: 250,
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
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LaundryLinienAmount = table.Column<int>(type: "int", nullable: false),
                    LaundryLinienType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ReciptDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
    }
}
