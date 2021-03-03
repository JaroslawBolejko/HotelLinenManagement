using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class AddLaundryIThinkForTheLastTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaundryId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaundryId",
                table: "GoodsReceivedNotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaundryId",
                table: "GoodsIssuedNotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Laundries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laundries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelLinenLaundry",
                columns: table => new
                {
                    HotelLinensId = table.Column<int>(type: "int", nullable: false),
                    LaundriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelLinenLaundry", x => new { x.HotelLinensId, x.LaundriesId });
                    table.ForeignKey(
                        name: "FK_HotelLinenLaundry_HotelLinens_HotelLinensId",
                        column: x => x.HotelLinensId,
                        principalTable: "HotelLinens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelLinenLaundry_Laundries_LaundriesId",
                        column: x => x.LaundriesId,
                        principalTable: "Laundries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_LaundryId",
                table: "Invoices",
                column: "LaundryId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_LaundryId",
                table: "GoodsReceivedNotes",
                column: "LaundryId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedNotes_LaundryId",
                table: "GoodsIssuedNotes",
                column: "LaundryId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinenLaundry_LaundriesId",
                table: "HotelLinenLaundry",
                column: "LaundriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsIssuedNotes_Laundries_LaundryId",
                table: "GoodsIssuedNotes",
                column: "LaundryId",
                principalTable: "Laundries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceivedNotes_Laundries_LaundryId",
                table: "GoodsReceivedNotes",
                column: "LaundryId",
                principalTable: "Laundries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Laundries_LaundryId",
                table: "Invoices",
                column: "LaundryId",
                principalTable: "Laundries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsIssuedNotes_Laundries_LaundryId",
                table: "GoodsIssuedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceivedNotes_Laundries_LaundryId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Laundries_LaundryId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "HotelLinenLaundry");

            migrationBuilder.DropTable(
                name: "Laundries");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_LaundryId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceivedNotes_LaundryId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssuedNotes_LaundryId",
                table: "GoodsIssuedNotes");

            migrationBuilder.DropColumn(
                name: "LaundryId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "LaundryId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropColumn(
                name: "LaundryId",
                table: "GoodsIssuedNotes");
        }
    }
}
