using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class LaundryServiceInheitanceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Storerooms_LaundryId",
                table: "HotelLinens");

            migrationBuilder.DropForeignKey(
                name: "FK_Storerooms_Users_UserId",
                table: "Storerooms");

            migrationBuilder.DropTable(
                name: "LaundryServices");

            migrationBuilder.DropIndex(
                name: "IX_Storerooms_UserId",
                table: "Storerooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_LaundryId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Storerooms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Storerooms");

            migrationBuilder.DropColumn(
                name: "LaundryId",
                table: "HotelLinens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
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

            migrationBuilder.CreateTable(
                name: "LaundryServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaundryServices", x => x.Id);
                });

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
                name: "FK_Storerooms_Users_UserId",
                table: "Storerooms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
