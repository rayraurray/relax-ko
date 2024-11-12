using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RelaxingKoala.Data.Migrations
{
    /// <inheritdoc />
    public partial class TheRest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ContactInfo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeliveryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTables",
                columns: table => new
                {
                    RestaurantTableId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTables", x => x.RestaurantTableId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservationTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    CustomersCustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdersOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => new { x.CustomersCustomerId, x.OrdersOrderId });
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ContactNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryId);
                    table.ForeignKey(
                        name: "FK_Deliveries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemOrder",
                columns: table => new
                {
                    MenuItemsMenuItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdersOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemOrder", x => new { x.MenuItemsMenuItemId, x.OrdersOrderId });
                    table.ForeignKey(
                        name: "FK_MenuItemOrder_MenuItems_MenuItemsMenuItemId",
                        column: x => x.MenuItemsMenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemOrder_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaymentTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentType = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<float>(type: "REAL", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationRestaurantTable",
                columns: table => new
                {
                    ReservationsReservationId = table.Column<int>(type: "INTEGER", nullable: false),
                    TablesRestaurantTableId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationRestaurantTable", x => new { x.ReservationsReservationId, x.TablesRestaurantTableId });
                    table.ForeignKey(
                        name: "FK_ReservationRestaurantTable_Reservations_ReservationsReservationId",
                        column: x => x.ReservationsReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationRestaurantTable_RestaurantTables_TablesRestaurantTableId",
                        column: x => x.TablesRestaurantTableId,
                        principalTable: "RestaurantTables",
                        principalColumn: "RestaurantTableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPayment",
                columns: table => new
                {
                    CustomersCustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentsPaymentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPayment", x => new { x.CustomersCustomerId, x.PaymentsPaymentId });
                    table.ForeignKey(
                        name: "FK_CustomerPayment_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPayment_Payments_PaymentsPaymentId",
                        column: x => x.PaymentsPaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "ContactInfo", "Name" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John Doe" },
                    { 2, "jane@example.com", "Jane Smith" },
                    { 3, "alice@example.com", "Alice Johnson" }
                });

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 1,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 22, 50, 18, 770, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 2,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 21, 50, 18, 770, DateTimeKind.Local).AddTicks(5805));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 3,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 20, 50, 18, 770, DateTimeKind.Local).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 4,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 22, 20, 18, 770, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 5,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 23, 5, 18, 770, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "Kitchens",
                keyColumn: "KitchenId",
                keyValue: 6,
                column: "OrderTime",
                value: new DateTime(2024, 11, 11, 21, 20, 18, 770, DateTimeKind.Local).AddTicks(5809));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "DeliveryId", "OrderTime", "PaymentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 11, 19, 50, 18, 770, DateTimeKind.Local).AddTicks(5933), 1 },
                    { 2, null, new DateTime(2024, 11, 11, 21, 50, 18, 770, DateTimeKind.Local).AddTicks(5935), 2 }
                });

            migrationBuilder.InsertData(
                table: "RestaurantTables",
                columns: new[] { "RestaurantTableId", "Name" },
                values: new object[,]
                {
                    { 1, "Table A" },
                    { 2, "Table B" }
                });

            migrationBuilder.InsertData(
                table: "CustomerOrder",
                columns: new[] { "CustomersCustomerId", "OrdersOrderId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "DeliveryId", "ContactNumber", "DeliveryAddress", "DeliveryTime", "OrderId" },
                values: new object[] { 1, "123-456-7890", "123 Main St", new DateTime(2024, 11, 12, 0, 50, 18, 770, DateTimeKind.Local).AddTicks(5916), 1 });

            migrationBuilder.InsertData(
                table: "MenuItemOrder",
                columns: new[] { "MenuItemsMenuItemId", "OrdersOrderId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "OrderId", "PaymentStatus", "PaymentTime", "PaymentType" },
                values: new object[,]
                {
                    { 1, 450f, 1, true, new DateTime(2024, 11, 11, 20, 50, 18, 770, DateTimeKind.Local).AddTicks(5951), 1 },
                    { 2, 300f, 2, false, new DateTime(2024, 11, 11, 22, 50, 18, 770, DateTimeKind.Local).AddTicks(5953), 2 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "ReservationTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 12, 23, 50, 18, 770, DateTimeKind.Local).AddTicks(5968) },
                    { 2, 2, new DateTime(2024, 11, 13, 23, 50, 18, 770, DateTimeKind.Local).AddTicks(5970) }
                });

            migrationBuilder.InsertData(
                table: "CustomerPayment",
                columns: new[] { "CustomersCustomerId", "PaymentsPaymentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ReservationRestaurantTable",
                columns: new[] { "ReservationsReservationId", "TablesRestaurantTableId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_OrdersOrderId",
                table: "CustomerOrder",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayment_PaymentsPaymentId",
                table: "CustomerPayment",
                column: "PaymentsPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_OrderId",
                table: "Deliveries",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemOrder_OrdersOrderId",
                table: "MenuItemOrder",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRestaurantTable_TablesRestaurantTableId",
                table: "ReservationRestaurantTable",
                column: "TablesRestaurantTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.DropTable(
                name: "CustomerPayment");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "MenuItemOrder");

            migrationBuilder.DropTable(
                name: "ReservationRestaurantTable");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "RestaurantTables");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

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
        }
    }
}
