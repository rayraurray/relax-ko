using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Models;

namespace RelaxingKoala.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
		public DbSet<Statistics> Statistics { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<RestaurantTable> RestaurantTables { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Delivery> Deliveries { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUserLogin<string>>()
                .HasKey(login => new { login.UserId, login.LoginProvider, login.ProviderKey });

            var m1 = new Menu { MenuId = 1, Name = "Italian Menu", Description = "Delicious Meals from the Northern Parts of Italy" };
            var m2 = new Menu { MenuId = 2, Name = "Seafood Menu", Description = "Scrumptiousness By the Ocean" };
            var m3 = new Menu { MenuId = 3, Name = "Vegan Menu", Description = "Absolute Healthiness lol" };

            builder.Entity<Menu>().HasData(
                m1,
                m2,
                m3
            );

            var mi1 = new MenuItem { MenuItemId = 1, Name = "Spaghetti Carbonara", Description = "Classic Italian pasta dish with eggs, cheese, pancetta, and pepper.", Price = 12.99f };
            var mi2 = new MenuItem { MenuItemId = 2, Name = "Margherita Pizza", Description = "Traditional pizza with fresh tomatoes, mozzarella cheese, and basil.", Price = 10.50f };
            var mi3 = new MenuItem { MenuItemId = 3, Name = "Lobster Bisque", Description = "Rich and creamy lobster soup with a hint of sherry.", Price = 15.75f };
            var mi4 = new MenuItem { MenuItemId = 4, Name = "Grilled Salmon", Description = "Fresh Atlantic salmon grilled to perfection with lemon butter sauce.", Price = 18.00f };
            var mi5 = new MenuItem { MenuItemId = 5, Name = "Quinoa Salad", Description = "Healthy vegan salad with quinoa, avocado, cherry tomatoes, and a light vinaigrette.", Price = 9.50f };
            var mi6 = new MenuItem { MenuItemId = 6, Name = "Vegan Burger", Description = "Plant-based burger with lettuce, tomato, vegan cheese, and a special sauce.", Price = 11.25f }; 

            builder.Entity<MenuItem>().HasData(
                mi1,
                mi2,
                mi3,
                mi4,
                mi5,
                mi6
            );

			// Many-to-Many: Menu <-> MenuItem
			builder.Entity<Menu>().HasMany(m => m.Items).WithMany(i => i.Menus).UsingEntity(mi => mi.HasData(
                new { MenusMenuId = 1, ItemsMenuItemId = 1 },
                new { MenusMenuId = 1, ItemsMenuItemId = 2 },
                new { MenusMenuId = 2, ItemsMenuItemId = 3 },
                new { MenusMenuId = 2, ItemsMenuItemId = 4 },
                new { MenusMenuId = 3, ItemsMenuItemId = 5 },
                new { MenusMenuId = 3, ItemsMenuItemId = 6 }
            ));

            var k1 = new Kitchen { KitchenId = 1, MenuItemId = 1, OrderTime = DateTime.Now.AddHours(-1), IsPrepared = false};
            var k2 = new Kitchen { KitchenId = 2, MenuItemId = 2, OrderTime = DateTime.Now.AddHours(-2), IsPrepared = false};
            var k3 = new Kitchen { KitchenId = 3, MenuItemId = 3, OrderTime = DateTime.Now.AddHours(-3), IsPrepared = true};
            var k4 = new Kitchen { KitchenId = 4, MenuItemId = 4, OrderTime = DateTime.Now.AddHours(-1.5), IsPrepared = true};
            var k5 = new Kitchen { KitchenId = 5, MenuItemId = 5, OrderTime = DateTime.Now.AddMinutes(-45), IsPrepared = false};
            var k6 = new Kitchen { KitchenId = 6, MenuItemId = 6, OrderTime = DateTime.Now.AddHours(-2.5), IsPrepared = true};

            builder.Entity<Kitchen>().HasData(
                k1,
                k2, 
                k3, 
                k4, 
                k5, 
                k6
            );

			var stat1 = new Statistics { StatisticsId = 1, MenuItemId = 1, NumberOfOrders = 150, AverageOrderTime = 20, RecordedDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)) };
			var stat2 = new Statistics { StatisticsId = 2, MenuItemId = 2, NumberOfOrders = 120, AverageOrderTime = 18, RecordedDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)) };
			var stat3 = new Statistics { StatisticsId = 3, MenuItemId = 3, NumberOfOrders = 100, AverageOrderTime = 22, RecordedDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)) };
			var stat4 = new Statistics { StatisticsId = 4, MenuItemId = 4, NumberOfOrders = 80, AverageOrderTime = 25, RecordedDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-22)) };
			var stat5 = new Statistics { StatisticsId = 5, MenuItemId = 5, NumberOfOrders = 60, AverageOrderTime = 15, RecordedDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-13)) };
			var stat6 = new Statistics { StatisticsId = 6, MenuItemId = 6, NumberOfOrders = 90, AverageOrderTime = 20, RecordedDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-30)) };

			builder.Entity<Statistics>().HasData(
				stat1,
				stat2,
				stat3,
				stat4,
				stat5,
				stat6
			);

			var c1 = new Customer { CustomerId = 1, Name = "John Doe", ContactInfo = "john@example.com" };
			var c2 = new Customer { CustomerId = 2, Name = "Jane Smith", ContactInfo = "jane@example.com" };
			var c3 = new Customer { CustomerId = 3, Name = "Alice Johnson", ContactInfo = "alice@example.com" };

			builder.Entity<Customer>().HasData(
                c1, 
                c2, 
                c3
            );

			var d1 = new Delivery { DeliveryId = 1, OrderId = 1, DeliveryAddress = "123 Main St", DeliveryTime = DateTime.Now.AddHours(1), ContactNumber = "123-456-7890" };

			builder.Entity<Delivery>().HasData(
                d1
            );

			var o1 = new Order { OrderId = 1, OrderTime = DateTime.Now.AddHours(-4), PaymentId = 1, DeliveryId = 1 };
			var o2 = new Order { OrderId = 2, OrderTime = DateTime.Now.AddHours(-2), PaymentId = 2 };
			
            builder.Entity<Order>().HasData(
                o1, 
                o2
            );

			var p1 = new Payment { PaymentId = 1, PaymentTime = DateTime.Now.AddHours(-3), OrderId = 1, PaymentType = 1, Amount = 450.00f, PaymentStatus = true };
			var p2 = new Payment { PaymentId = 2, PaymentTime = DateTime.Now.AddHours(-1), OrderId = 2, PaymentType = 2, Amount = 300.00f, PaymentStatus = false };
			
            builder.Entity<Payment>().HasData(
                p1,
                p2
            );

			var r1 = new Reservation { ReservationId = 1, CustomerId = 1, ReservationTime = DateTime.Now.AddDays(1) };
			var r2 = new Reservation { ReservationId = 2, CustomerId = 2, ReservationTime = DateTime.Now.AddDays(2) };

			builder.Entity<Reservation>().HasData(
                r1, 
                r2
            );

			var t1 = new RestaurantTable { RestaurantTableId = 1, Name = "Table A" };
			var t2 = new RestaurantTable { RestaurantTableId = 2, Name = "Table B" };

			builder.Entity<RestaurantTable>().HasData(
                t1, 
                t2
            );

			// Many-to-Many: Customer <-> Payments
			builder.Entity<Customer>().HasMany(c => c.Payments).WithMany(p => p.Customers).UsingEntity(cp => cp.HasData(
				new { CustomersCustomerId = 1, PaymentsPaymentId = 1},
				new { CustomersCustomerId = 2, PaymentsPaymentId = 2}
			));

            // Many-to-Many: Reservation <-> Tables
            builder.Entity<Reservation>().HasMany(r => r.Tables).WithMany(t => t.Reservations).UsingEntity(tr  => tr.HasData(
				new { ReservationsReservationId = 1, TablesRestaurantTableId = 1 },
				new { ReservationsReservationId = 2, TablesRestaurantTableId = 2 }
            ));

			// Many-to-Many: Order <-> MenuItems
            builder.Entity<Order>().HasMany(o => o.MenuItems).WithMany(i => i.Orders).UsingEntity(oi => oi.HasData(
				new { OrdersOrderId = 1, MenuItemsMenuItemId = 1 },
				new { OrdersOrderId = 1, MenuItemsMenuItemId = 2 },
				new { OrdersOrderId = 2, MenuItemsMenuItemId = 3 },
				new { OrdersOrderId = 2, MenuItemsMenuItemId = 4 }
            ));

            // Many-to-Many: Customer <-> Order
            builder.Entity<Customer>().HasMany(u => u.Orders).WithMany(d => d.Customers).UsingEntity(du => du.HasData(
                new { OrdersOrderId = 1, CustomersCustomerId = 1 },
                new { OrdersOrderId = 2, CustomersCustomerId = 2 },
                new { OrdersOrderId = 1, CustomersCustomerId = 3 }
            ));

			// One-to-One: Order -> Delivery
			builder.Entity<Order>().HasOne(o => o.Delivery).WithOne(d => d.Order).HasForeignKey<Delivery>(d => d.OrderId).OnDelete(DeleteBehavior.Cascade);

			// One-to-One: Order -> Payment
			builder.Entity<Order>().HasOne(o => o.Payment).WithOne(p => p.Order).HasForeignKey<Payment>(p => p.OrderId).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
