using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesOrderAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompleteName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "SalesItems",
                columns: table => new
                {
                    SalesItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesItems", x => x.SalesItemId);
                });

            migrationBuilder.CreateTable(
                name: "UoMs",
                columns: table => new
                {
                    UoMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UoMs", x => x.UoMId);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    SalesOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderDocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.SalesOrderId);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesItemPrices",
                columns: table => new
                {
                    SalesItemPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SalesItemId = table.Column<int>(type: "int", nullable: true),
                    UoMId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesItemPrices", x => x.SalesItemPriceId);
                    table.ForeignKey(
                        name: "FK_SalesItemPrices_SalesItems_SalesItemId",
                        column: x => x.SalesItemId,
                        principalTable: "SalesItems",
                        principalColumn: "SalesItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesItemPrices_UoMs_UoMId",
                        column: x => x.UoMId,
                        principalTable: "UoMs",
                        principalColumn: "UoMId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderLines",
                columns: table => new
                {
                    SalesOrderLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceAmount = table.Column<double>(type: "float", nullable: false),
                    SalesOrderId = table.Column<int>(type: "int", nullable: true),
                    SalesItemPriceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderLines", x => x.SalesOrderLineId);
                    table.ForeignKey(
                        name: "FK_SalesOrderLines_SalesItemPrices_SalesItemPriceId",
                        column: x => x.SalesItemPriceId,
                        principalTable: "SalesItemPrices",
                        principalColumn: "SalesItemPriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderLines_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesItemPrices_SalesItemId",
                table: "SalesItemPrices",
                column: "SalesItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItemPrices_UoMId",
                table: "SalesItemPrices",
                column: "UoMId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLines_SalesItemPriceId",
                table: "SalesOrderLines",
                column: "SalesItemPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLines_SalesOrderId",
                table: "SalesOrderLines",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustomerId",
                table: "SalesOrders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesOrderLines");

            migrationBuilder.DropTable(
                name: "SalesItemPrices");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "SalesItems");

            migrationBuilder.DropTable(
                name: "UoMs");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
