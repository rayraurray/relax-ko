using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RelaxingKoala.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddKitchen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kitchens",
                columns: table => new
                {
                    KitchenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsPrepared = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitchens", x => x.KitchenId);
                    table.ForeignKey(
                        name: "FK_Kitchens_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kitchens",
                columns: new[] { "KitchenId", "IsPrepared", "MenuItemId", "OrderTime" },
                values: new object[,]
                {
                    { 1, false, 1, new DateTime(2024, 11, 11, 17, 17, 42, 294, DateTimeKind.Local).AddTicks(4980) },
                    { 2, false, 2, new DateTime(2024, 11, 11, 16, 17, 42, 294, DateTimeKind.Local).AddTicks(4996) },
                    { 3, true, 3, new DateTime(2024, 11, 11, 15, 17, 42, 294, DateTimeKind.Local).AddTicks(4997) },
                    { 4, true, 4, new DateTime(2024, 11, 11, 16, 47, 42, 294, DateTimeKind.Local).AddTicks(4998) },
                    { 5, false, 5, new DateTime(2024, 11, 11, 17, 32, 42, 294, DateTimeKind.Local).AddTicks(4999) },
                    { 6, true, 6, new DateTime(2024, 11, 11, 15, 47, 42, 294, DateTimeKind.Local).AddTicks(5000) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_MenuItemId",
                table: "Kitchens",
                column: "MenuItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kitchens");
        }
    }
}
