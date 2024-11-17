using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;
using RelaxingKoala.Models;

namespace RelaxingKoala.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Menus = await _context.Menus.ToListAsync();

            if (User.IsInRole("Customer"))
            {
                // If the user is a Customer, they should only see the menu items without any editing options
                return View(await _context.MenuItems.ToListAsync());
            }

            // For Managers or Staff, return the full MenuItem List with edit and delete options
            return View(await _context.MenuItems.ToListAsync());
        }

        public async Task<IActionResult> ChangeMenus(int menuId)
        {
            List<MenuItem> filteredMenuItems;

            ViewBag.Menus = await _context.Menus.ToListAsync();
            ViewBag.SelectedMenu = menuId;

            if (menuId != 0)
            {
                filteredMenuItems = await _context.MenuItems.Where(i => i.Menus.Any(m => m.MenuId == menuId)).ToListAsync();
            }
            else
            {
                filteredMenuItems = await _context.MenuItems.ToListAsync();
            }

            return View("Index", filteredMenuItems);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> AssignMenuItem()
        {
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();
            ViewBag.Menus = await _context.Menus.ToListAsync();

            return View();
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> AssignMenuItem(MenuItem i, string[] assignedMenus)
        {

            if (assignedMenus != null)
            {
                foreach (var menuId in assignedMenus)
                {
                    Menu m = _context.Menus.Find(int.Parse(menuId));
                    i.Menus.Add(m);
                }
            }

            _context.MenuItems.Add(i);

            await _context.SaveChangesAsync();

            ViewBag.Menus = await _context.Menus.ToListAsync();
            List<MenuItem> menuItems = await _context.MenuItems.ToListAsync();

            return View("Index", menuItems);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> EditMenuItem(int menuItemId)
        {

            var menuItem = await _context.MenuItems.Include(i => i.Menus).FirstOrDefaultAsync(i => i.MenuItemId == menuItemId);

            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();
            ViewBag.Menus = await _context.Menus.ToListAsync();

            return View(menuItem);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> ModifyMenuItem(MenuItem i, string[] assignedMenus, string name, string description, float price)
        {
            MenuItem menuItem = await _context.MenuItems.Where(mi => mi.MenuItemId == i.MenuItemId).Include(mi => mi.Menus).FirstOrDefaultAsync();

            menuItem.Menus.Clear();

            if (assignedMenus != null)
            {
                foreach (var menuId in assignedMenus)
                {
                    Menu m = _context.Menus.Find(int.Parse(menuId));
                    menuItem.Menus.Add(m);
                }
            }

            menuItem.Name = name;
            menuItem.Description = description;
            menuItem.Price = price;

            await _context.SaveChangesAsync();

            List<MenuItem> menuItems = await _context.MenuItems.ToListAsync();
            ViewBag.Menus = await _context.Menus.ToListAsync();

            return View("Index", menuItems);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> Delete(int menuItemId)
        {
            return View(await _context.MenuItems.FindAsync(menuItemId));
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(MenuItem i)
        {
            MenuItem menuItem = await _context.MenuItems.Where(mi => mi.MenuItemId == i.MenuItemId).Include(mi => mi.Menus).FirstOrDefaultAsync();

            _context.MenuItems.Remove(menuItem);

            await _context.SaveChangesAsync();

            List<MenuItem> menuItems = await _context.MenuItems.ToListAsync();
            ViewBag.Menus = await _context.Menus.ToListAsync();

            return View("Index", menuItems);
        }
    }
}
