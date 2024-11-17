using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        /*var connectionString = builder.Configuration.GetConnectionString("DatabaseConn") ?? throw new InvalidOperationException("Connection string 'DatabaseConn' not found.");*/

        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DatabaseConn")));

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Define roles
            var roles = new[] { "Customer", "Manager", "Staff" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Define users
            var users = new[]
            {
        new { Email = "customer@customer.com", Password = "Test1234!", Role = "Customer" },
        new { Email = "manager@manager.com", Password = "Manager123!", Role = "Manager" },
        new { Email = "staff@staff.com", Password = "Staff123!", Role = "Staff" }
    };

            foreach (var userInfo in users)
            {
                if (await userManager.FindByEmailAsync(userInfo.Email) == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = userInfo.Email,
                        Email = userInfo.Email
                    };

                    await userManager.CreateAsync(user, userInfo.Password);
                    await userManager.AddToRoleAsync(user, userInfo.Role);
                }
            }
        }

        app.Run();
    }

}


