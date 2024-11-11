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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUserLogin<string>>()
                .HasKey(login => new { login.UserId, login.LoginProvider, login.ProviderKey });

            builder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, Name = "Italian Menu", Description = "Delicious Meals from the Northern Parts of Italy"},
                new Menu { MenuId = 2, Name = "Seafood Menu", Description = "Scrumptiousness By the Ocean"},
                new Menu { MenuId = 3, Name = "Vegan Menu", Description = "Absolute Healthiness lol"}
            );

            builder.Entity<MenuItem>().HasData(
                new MenuItem { MenuItemId = 1, Name = "Spaghetti Carbonara", Description = "Classic Italian pasta dish with eggs, cheese, pancetta, and pepper.", Price = 12.99f},
                new MenuItem { MenuItemId = 2, Name = "Margherita Pizza", Description = "Traditional pizza with fresh tomatoes, mozzarella cheese, and basil.", Price = 10.50f },
                new MenuItem { MenuItemId = 3, Name = "Lobster Bisque", Description = "Rich and creamy lobster soup with a hint of sherry.", Price = 15.75f},
                new MenuItem { MenuItemId = 4, Name = "Grilled Salmon", Description = "Fresh Atlantic salmon grilled to perfection with lemon butter sauce.", Price = 18.00f},
                new MenuItem { MenuItemId = 5, Name = "Quinoa Salad", Description = "Healthy vegan salad with quinoa, avocado, cherry tomatoes, and a light vinaigrette.", Price = 9.50f },
                new MenuItem { MenuItemId = 6, Name = "Vegan Burger", Description = "Plant-based burger with lettuce, tomato, vegan cheese, and a special sauce.", Price = 11.25f }
            );

            builder.Entity<Menu>().HasMany(m => m.Items).WithMany(i => i.Menus).UsingEntity(mi => mi.HasData(
                new { MenusMenuId = 1, ItemsMenuItemId = 1 },
                new { MenusMenuId = 1, ItemsMenuItemId = 2 },
                new { MenusMenuId = 2, ItemsMenuItemId = 3 },
                new { MenusMenuId = 2, ItemsMenuItemId = 4 },
                new { MenusMenuId = 3, ItemsMenuItemId = 5 },
                new { MenusMenuId = 3, ItemsMenuItemId = 6 }
            ));
        }
    }
}
