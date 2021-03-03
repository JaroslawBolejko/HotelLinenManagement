using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class AddLaundryAndInvoiceTypoCorection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_HotelLinens_HotelLinenId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Hotels_HotelId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Storerooms_StoreroomId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "LinenType",
                table: "HotelLinens");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoices");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                newName: "IX_Invices_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_StoreroomId",
                table: "Invoices",
                newName: "IX_Invices_StoreroomId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_HotelLinenId",
                table: "Invoices",
                newName: "IX_Invices_HotelLinenId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_HotelId",
                table: "Invoices",
                newName: "IX_Invices_HotelId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Workplace",
                table: "Users",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Storerooms",
                type: "nvarchar(250)",
                maxLength: 250,
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
                name: "LaundryId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Storerooms_UserId",
                table: "Storerooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_LaundryId",
                table: "HotelLinens",
                column: "LaundryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Storerooms_LaundryId",
                table: "HotelLinens",
                column: "LaundryId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invices_HotelLinens_HotelLinenId",
                table: "Invoices",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invices_Hotels_HotelId",
                table: "Invoices",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invices_Storerooms_StoreroomId",
                table: "Invoices",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invices_Users_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "Users",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Storerooms_LaundryId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_Invices_HotelLinens_HotelLinenId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invices_Hotels_HotelId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invices_Storerooms_StoreroomId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invices_Users_UserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Storerooms_Users_UserId",
                table: "Storerooms");

            migrationBuilder.DropIndex(
                name: "IX_Storerooms_UserId",
                table: "Storerooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_LaundryId",
                table: "HotelLinens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invices",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Workplace",
                table: "Users");

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
                name: "LaundryId",
                table: "HotelLinens");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoices");

            migrationBuilder.RenameIndex(
                name: "IX_Invices_UserId",
                table: "Invoices",
                newName: "IX_Invoices_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invices_StoreroomId",
                table: "Invoices",
                newName: "IX_Invoices_StoreroomId");

            migrationBuilder.RenameIndex(
                name: "IX_Invices_HotelLinenId",
                table: "Invoices",
                newName: "IX_Invoices_HotelLinenId");

            migrationBuilder.RenameIndex(
                name: "IX_Invices_HotelId",
                table: "Invoices",
                newName: "IX_Invoices_HotelId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "LinenType",
                table: "HotelLinens",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_HotelLinens_HotelLinenId",
                table: "Invoices",
                column: "HotelLinenId",
                principalTable: "HotelLinens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Hotels_HotelId",
                table: "Invoices",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Storerooms_StoreroomId",
                table: "Invoices",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
