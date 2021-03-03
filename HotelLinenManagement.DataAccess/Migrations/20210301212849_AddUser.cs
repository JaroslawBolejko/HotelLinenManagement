using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "LiquidationDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GoodsReceivedNotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GoodsIssuedNotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreroomUser",
                columns: table => new
                {
                    StoreroomsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreroomUser", x => new { x.StoreroomsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_StoreroomUser_Storerooms_StoreroomsId",
                        column: x => x.StoreroomsId,
                        principalTable: "Storerooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreroomUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiquidationDocuments_UserId",
                table: "LiquidationDocuments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_UserId",
                table: "GoodsReceivedNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedNotes_UserId",
                table: "GoodsIssuedNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreroomUser_UsersId",
                table: "StoreroomUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsIssuedNotes_Users_UserId",
                table: "GoodsIssuedNotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceivedNotes_Users_UserId",
                table: "GoodsReceivedNotes",
                column: "UserId",
                principalTable: "Users",
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
                name: "FK_LiquidationDocuments_Users_UserId",
                table: "LiquidationDocuments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsIssuedNotes_Users_UserId",
                table: "GoodsIssuedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceivedNotes_Users_UserId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Invices_Users_UserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidationDocuments_Users_UserId",
                table: "LiquidationDocuments");

            migrationBuilder.DropTable(
                name: "StoreroomUser");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_LiquidationDocuments_UserId",
                table: "LiquidationDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Invices_UserId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceivedNotes_UserId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssuedNotes_UserId",
                table: "GoodsIssuedNotes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LiquidationDocuments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GoodsReceivedNotes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GoodsIssuedNotes");
        }
    }
}
