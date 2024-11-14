using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;
using RelaxingKoala.Models;

namespace RelaxingKoala.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View(await _context.Menus.ToListAsync());
        }

        public async Task<IActionResult> ChangeMenuItems(int menuItemId)
        {
            List<Menu> filteredMenus;

            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();
            ViewBag.SelectedMenuItem = menuItemId;

            if (menuItemId != 0) 
            {
                filteredMenus = await _context.Menus.Where(m => m.Items.Any(i => i.MenuItemId == menuItemId)).ToListAsync();
            }
            else
            {
                filteredMenus = await _context.Menus.ToListAsync();
            }

            return View("Index", filteredMenus);
        }

        [HttpGet]
        public async Task<IActionResult> AssignMenu()
        {
            ViewBag.Menus = await _context.Menus.ToListAsync();
			ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

			return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignMenu(Menu m, string[] assignedMenuItems)
        {

            if(assignedMenuItems != null)
            {
                foreach(var menuItemId in assignedMenuItems)
                {
                    MenuItem i = _context.MenuItems.Find(int.Parse(menuItemId));
                    m.Items.Add(i);
                }
            }

            _context.Menus.Add(m);

            await _context.SaveChangesAsync();

            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();
            List<Menu> menus = await _context.Menus.ToListAsync();

            return View("Index", menus);
        }

        [HttpGet]
        public async Task<IActionResult> EditMenu(int menuId)
        {
            var menu = await _context.Menus.Include(m => m.Items).FirstOrDefaultAsync(m => m.MenuId == menuId);

			ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View(menu);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyMenu(Menu m, string[] assignedMenuItems, string name, string description)
        {
            Menu menu = await _context.Menus.Where(mn => mn.MenuId == m.MenuId).Include(mn => mn.Items).FirstOrDefaultAsync();

			menu.Items.Clear();

            if(assignedMenuItems != null)
            {
                foreach(var menuItemId in assignedMenuItems)
                {
                    MenuItem i = _context.MenuItems.Find(int.Parse(menuItemId));
                    menu.Items.Add(i);
                }
            }

            menu.Name = name;
            menu.Description = description;

            await _context.SaveChangesAsync();

            List<Menu> menus = await _context.Menus.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View("Index", menus);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int menuId)
        {
            return View(await _context.Menus.FindAsync(menuId));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Menu m)
        {
            Menu menu = await _context.Menus.Where(mn => mn.MenuId == m.MenuId).Include(mn => mn.Items).FirstOrDefaultAsync();

            _context.Menus.Remove(menu);

            await _context.SaveChangesAsync();

            List<Menu> menus = await _context.Menus.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View("Index", menus);
        }

    }
}
