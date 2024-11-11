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
        }
    }
}
