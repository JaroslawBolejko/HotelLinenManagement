using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelLinenManagement.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laundries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ReciptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laundries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Workplace = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storerooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    StoreroomName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaundryId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceTotal = table.Column<double>(type: "float", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DocumentNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Laundries_LaundryId",
                        column: x => x.LaundryId,
                        principalTable: "Laundries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsIssuedNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaundryId = table.Column<int>(type: "int", nullable: true),
                    StoreroomId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsIssuedNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsIssuedNotes_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsIssuedNotes_Laundries_LaundryId",
                        column: x => x.LaundryId,
                        principalTable: "Laundries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsIssuedNotes_Storerooms_StoreroomId",
                        column: x => x.StoreroomId,
                        principalTable: "Storerooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsIssuedNotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceivedNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaundryId = table.Column<int>(type: "int", nullable: true),
                    StoreroomId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceivedNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsReceivedNotes_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceivedNotes_Laundries_LaundryId",
                        column: x => x.LaundryId,
                        principalTable: "Laundries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceivedNotes_Storerooms_StoreroomId",
                        column: x => x.StoreroomId,
                        principalTable: "Storerooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceivedNotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelLinens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    StoreroomId = table.Column<int>(type: "int", nullable: false),
                    LinenName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LinenAmount = table.Column<int>(type: "int", nullable: false),
                    LinenTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinienWeight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelLinens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelLinens_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelLinens_Storerooms_StoreroomId",
                        column: x => x.StoreroomId,
                        principalTable: "Storerooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiquidationDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreroomId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentNumber = table.Column<int>(type: "int", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidationDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiquidationDocuments_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LiquidationDocuments_Storerooms_StoreroomId",
                        column: x => x.StoreroomId,
                        principalTable: "Storerooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LiquidationDocuments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "LinenTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelLinenId = table.Column<int>(type: "int", nullable: true),
                    LinenTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    StoreroomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinenTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinenTypes_HotelLinens_HotelLinenId",
                        column: x => x.HotelLinenId,
                        principalTable: "HotelLinens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinenTypes_Storerooms_StoreroomId",
                        column: x => x.StoreroomId,
                        principalTable: "Storerooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedNotes_HotelId",
                table: "GoodsIssuedNotes",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedNotes_LaundryId",
                table: "GoodsIssuedNotes",
                column: "LaundryId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedNotes_StoreroomId",
                table: "GoodsIssuedNotes",
                column: "StoreroomId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedNotes_UserId",
                table: "GoodsIssuedNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_HotelId",
                table: "GoodsReceivedNotes",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_LaundryId",
                table: "GoodsReceivedNotes",
                column: "LaundryId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_StoreroomId",
                table: "GoodsReceivedNotes",
                column: "StoreroomId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNotes_UserId",
                table: "GoodsReceivedNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinenLaundry_LaundriesId",
                table: "HotelLinenLaundry",
                column: "LaundriesId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_HotelId",
                table: "HotelLinens",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelLinens_StoreroomId",
                table: "HotelLinens",
                column: "StoreroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_HotelId",
                table: "Invoices",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_LaundryId",
                table: "Invoices",
                column: "LaundryId");

            migrationBuilder.CreateIndex(
                name: "IX_LinenTypes_HotelLinenId",
                table: "LinenTypes",
                column: "HotelLinenId");

            migrationBuilder.CreateIndex(
                name: "IX_LinenTypes_StoreroomId",
                table: "LinenTypes",
                column: "StoreroomId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidationDocuments_HotelId",
                table: "LiquidationDocuments",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidationDocuments_StoreroomId",
                table: "LiquidationDocuments",
                column: "StoreroomId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidationDocuments_UserId",
                table: "LiquidationDocuments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Storerooms_HotelId",
                table: "Storerooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreroomUser_UsersId",
                table: "StoreroomUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsIssuedNotes");

            migrationBuilder.DropTable(
                name: "GoodsReceivedNotes");

            migrationBuilder.DropTable(
                name: "HotelLinenLaundry");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "LinenTypes");

            migrationBuilder.DropTable(
                name: "LiquidationDocuments");

            migrationBuilder.DropTable(
                name: "StoreroomUser");

            migrationBuilder.DropTable(
                name: "Laundries");

            migrationBuilder.DropTable(
                name: "HotelLinens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Storerooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
