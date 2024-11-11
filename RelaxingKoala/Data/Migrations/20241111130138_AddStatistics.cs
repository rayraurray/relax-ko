using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RelaxingKoala.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStatistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    StatisticsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfOrders = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageOrderTime = table.Column<int>(type: "INTEGER", nullable: false),
                    RecordedDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticsId);
                    table.ForeignKey(
                        name: "FK_Statistics_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 1,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 19, 1, 37, 656, DateTimeKind.Local).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 2,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 18, 1, 37, 656, DateTimeKind.Local).AddTicks(8011));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 3,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 17, 1, 37, 656, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 4,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 18, 31, 37, 656, DateTimeKind.Local).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 5,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 19, 16, 37, 656, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 6,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 17, 31, 37, 656, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "AverageOrderTime", "MenuItemId", "NumberOfOrders", "RecordedDate" },
                values: new object[,]
                {
                    { 1, 20, 1, 150, new DateOnly(2024, 11, 10) },
                    { 2, 18, 2, 120, new DateOnly(2024, 11, 8) },
                    { 3, 22, 3, 100, new DateOnly(2024, 11, 9) },
                    { 4, 25, 4, 80, new DateOnly(2024, 10, 20) },
                    { 5, 15, 5, 60, new DateOnly(2024, 10, 29) },
                    { 6, 20, 6, 90, new DateOnly(2024, 10, 12) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_MenuItemId",
                table: "Statistics",
                column: "MenuItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 1,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 17, 17, 42, 294, DateTimeKind.Local).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 2,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 16, 17, 42, 294, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 3,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 15, 17, 42, 294, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 4,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 16, 47, 42, 294, DateTimeKind.Local).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 5,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 17, 32, 42, 294, DateTimeKind.Local).AddTicks(4999));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 6,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 15, 47, 42, 294, DateTimeKind.Local).AddTicks(5000));
        }
    }
}
