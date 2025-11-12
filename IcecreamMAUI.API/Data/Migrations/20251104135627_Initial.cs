using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IcecreamMAUI.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Icecreams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icecreams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrederAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    CustomerEmail = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    CustomerAddress = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IcecreamOptions",
                columns: table => new
                {
                    IcecreamId = table.Column<int>(type: "int", nullable: false),
                    Flavor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Topping = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecreamOptions", x => new { x.IcecreamId, x.Flavor, x.Topping });
                    table.ForeignKey(
                        name: "FK_IcecreamOptions_Icecreams_IcecreamId",
                        column: x => x.IcecreamId,
                        principalTable: "Icecreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    IcecreamId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Flavor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Topping = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Totalprice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Icecreams",
                columns: new[] { "Id", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "vanilla.png", "Vanilla Dream", 5.0 },
                    { 2, "chocolate.png", "Chocolate Bliss", 7.9000000000000004 },
                    { 3, "strawberry.png", "Strawberry Swirl", 8.6999999999999993 },
                    { 4, "mango.png", "Mango Magic", 3.6400000000000001 },
                    { 5, "blue_berry.png", "Blueberry Burst", 9.7799999999999994 }
                });

            migrationBuilder.InsertData(
                table: "IcecreamOptions",
                columns: new[] { "Flavor", "IcecreamId", "Topping" },
                values: new object[,]
                {
                    { "Classic Vanilla", 1, "Choco Chips" },
                    { "Dark Chocolate", 2, "Brownie Bits" },
                    { "Fresh Strawberry", 3, "Whipped Cream" },
                    { "Alphonso Mango", 4, "Honey Drizzle" },
                    { "Wild Blueberry", 5, "Sprinkles" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcecreamOptions");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Icecreams");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
