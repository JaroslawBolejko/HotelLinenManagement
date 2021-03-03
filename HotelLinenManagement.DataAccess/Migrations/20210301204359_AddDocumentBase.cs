using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class AddDocumentBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invices_HotelLinens_HotelLinenId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invices_HotelLinenId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "HotelLinenId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "InvoiceNumber",
                table: "Invoices",
                newName: "DocumentNumber");

            migrationBuilder.RenameColumn(
                name: "InviceDate",
                table: "Invoices",
                newName: "DocumentDate");

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinenInvoice_InvicesId",
                table: "HotelLinenInvoice",
                column: "InvicesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelLinenInvoice");

            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "DocumentNumber",
                table: "Invoices",
                newName: "InvoiceNumber");

            migrationBuilder.RenameColumn(
                name: "DocumentDate",
                table: "Invoices",
                newName: "InviceDate");

            migrationBuilder.AddColumn<int>(
                name: "HotelLinenId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invices_HotelLinenId",
                table: "Invoices",
                column: "HotelLinenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invices_HotelLinens_HotelLinenId",
                table: "Invoices",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
