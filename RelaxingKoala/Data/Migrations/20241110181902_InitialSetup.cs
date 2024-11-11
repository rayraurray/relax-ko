using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RelaxingKoala.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "UserId", "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "MenuMenuItem",
                columns: table => new
                {
                    ItemsMenuItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenusMenuId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMenuItem", x => new { x.ItemsMenuItemId, x.MenusMenuId });
                    table.ForeignKey(
                        name: "FK_MenuMenuItem_MenuItems_ItemsMenuItemId",
                        column: x => x.ItemsMenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuMenuItem_Menus_MenusMenuId",
                        column: x => x.MenusMenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Classic Italian pasta dish with eggs, cheese, pancetta, and pepper.", "Spaghetti Carbonara", 12.99f },
                    { 2, "Traditional pizza with fresh tomatoes, mozzarella cheese, and basil.", "Margherita Pizza", 10.5f },
                    { 3, "Rich and creamy lobster soup with a hint of sherry.", "Lobster Bisque", 15.75f },
                    { 4, "Fresh Atlantic salmon grilled to perfection with lemon butter sauce.", "Grilled Salmon", 18f },
                    { 5, "Healthy vegan salad with quinoa, avocado, cherry tomatoes, and a light vinaigrette.", "Quinoa Salad", 9.5f },
                    { 6, "Plant-based burger with lettuce, tomato, vegan cheese, and a special sauce.", "Vegan Burger", 11.25f }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Delicious Meals from the Northern Parts of Italy", "Italian Menu" },
                    { 2, "Scrumptiousness By the Ocean", "Seafood Menu" },
                    { 3, "Absolute Healthiness lol", "Vegan Menu" }
                });

            migrationBuilder.InsertData(
                table: "MenuMenuItem",
                columns: new[] { "ItemsMenuItemId", "MenusMenuId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 3 },
                    { 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuMenuItem_MenusMenuId",
                table: "MenuMenuItem",
                column: "MenusMenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuMenuItem");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");
        }
    }
}
