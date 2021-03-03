using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class DeleteLaundryservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsIssuedNotes_Storerooms_LaundryServiceId",
                table: "GoodsIssuedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceivedNotes_Storerooms_LaundryServiceId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Storerooms_LaundryServiceId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Storerooms_LaundryServiceId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidationDocuments_Storerooms_LaundryServiceId",
                table: "LiquidationDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Storerooms_Users_UserId",
                table: "Storerooms");

            migrationBuilder.DropIndex(
                name: "IX_Storerooms_UserId",
                table: "Storerooms");

            migrationBuilder.DropIndex(
                name: "IX_LiquidationDocuments_LaundryServiceId",
                table: "LiquidationDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_LaundryServiceId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_LaundryServiceId",
                table: "HotelLinens");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceivedNotes_LaundryServiceId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssuedNotes_LaundryServiceId",
                table: "GoodsIssuedNotes");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Storerooms");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Storerooms");

            migrationBuilder.DropColumn(
                name: "TaxNumber",
                table: "Storerooms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Storerooms");

            migrationBuilder.DropColumn(
                name: "LaundryServiceId",
                table: "LiquidationDocuments");

            migrationBuilder.DropColumn(
                name: "LaundryServiceId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "LaundryServiceId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "LaundryServiceId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropColumn(
                name: "LaundryServiceId",
                table: "GoodsIssuedNotes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Storerooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Storerooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxNumber",
                table: "Storerooms",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Storerooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaundryServiceId",
                table: "LiquidationDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaundryServiceId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaundryServiceId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaundryServiceId",
                table: "GoodsReceivedNotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaundryServiceId",
                table: "GoodsIssuedNotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Storerooms_UserId",
                table: "Storerooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidationDocuments_LaundryServiceId",
                table: "LiquidationDocuments",
                column: "LaundryServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_LaundryServiceId",
                table: "Invoices",
                column: "LaundryServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_LaundryServiceId",
                table: "HotelLinens",
                column: "LaundryServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_LaundryServiceId",
                table: "GoodsReceivedNotes",
                column: "LaundryServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedNotes_LaundryServiceId",
                table: "GoodsIssuedNotes",
                column: "LaundryServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsIssuedNotes_Storerooms_LaundryServiceId",
                table: "GoodsIssuedNotes",
                column: "LaundryServiceId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceivedNotes_Storerooms_LaundryServiceId",
                table: "GoodsReceivedNotes",
                column: "LaundryServiceId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Storerooms_LaundryServiceId",
                table: "HotelLinens",
                column: "LaundryServiceId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Storerooms_LaundryServiceId",
                table: "Invoices",
                column: "LaundryServiceId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidationDocuments_Storerooms_LaundryServiceId",
                table: "LiquidationDocuments",
                column: "LaundryServiceId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Storerooms_Users_UserId",
                table: "Storerooms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
