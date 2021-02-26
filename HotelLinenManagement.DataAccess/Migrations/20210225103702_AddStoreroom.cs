using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class AddStoreroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Hotels",
                newName: "HotelName");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "HotelLinens",
                newName: "LinenType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "HotelLinens",
                newName: "LinenName");

            migrationBuilder.AddColumn<int>(
                name: "StoreroomId",
                table: "HotelLinens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Storerooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    StoreRoomName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinenType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinenAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storerooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storerooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_StoreroomId",
                table: "HotelLinens",
                column: "StoreroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Storerooms_HotelId",
                table: "Storerooms",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelLinens_Storerooms_StoreroomId",
                table: "HotelLinens",
                column: "StoreroomId",
                principalTable: "Storerooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelLinens_Storerooms_StoreroomId",
                table: "HotelLinens");

            migrationBuilder.DropTable(
                name: "Storerooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelLinens_StoreroomId",
                table: "HotelLinens");

            migrationBuilder.DropColumn(
                name: "StoreroomId",
                table: "HotelLinens");

            migrationBuilder.RenameColumn(
                name: "HotelName",
                table: "Hotels",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LinenType",
                table: "HotelLinens",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "LinenName",
                table: "HotelLinens",
                newName: "Name");
        }
    }
}
