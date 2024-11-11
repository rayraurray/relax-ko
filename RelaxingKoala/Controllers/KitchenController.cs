using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;
using RelaxingKoala.Models;

namespace RelaxingKoala.Controllers
{
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View(await _context.Kitchens.ToListAsync());
        }

        public async Task<IActionResult> ChangeMenuItems(int menuItemId)
        {
            List<Kitchen> filteredKitchens;

            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();
            ViewBag.SelectedMenuItem = menuItemId;

            if (menuItemId != 0)
            {
                filteredKitchens = await _context.Kitchens.Where(k => k.MenuItem.MenuItemId == menuItemId).ToListAsync();
            }
            else
            {
                filteredKitchens = await _context.Kitchens.ToListAsync();
            }

            return View("Index", filteredKitchens);
        }

        [HttpGet]
        public async Task<IActionResult> AddKitchen()
        {
            ViewBag.Kitchens = await _context.Kitchens.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddKitchen(Kitchen k, string assignedMenuItem)
        {

            if (assignedMenuItem != null)
            {
                MenuItem i = _context.MenuItems.Find(int.Parse(assignedMenuItem));
                k.MenuItem = i;
            }

            k.IsPrepared = false;
            k.OrderTime = DateTime.Now;

            _context.Kitchens.Add(k);

            await _context.SaveChangesAsync();

            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();
            List<Kitchen> kitchens = await _context.Kitchens.ToListAsync();

            return View("Index", kitchens);
        }

        [HttpGet]
        public async Task<IActionResult> EditKitchen(int kitchenId)
        {

            var kitchen = await _context.Kitchens.Include(k => k.MenuItem).FirstOrDefaultAsync(k => k.KitchenId == kitchenId);

            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View(kitchen);
        }
            
        [HttpPost]
        public async Task<IActionResult> ModifyState(Kitchen k, bool assignedValue)
        {
            Kitchen kitchen = await _context.Kitchens.Where(ki => ki.KitchenId == k.KitchenId).Include(ki => ki.MenuItem).FirstOrDefaultAsync();

            if (assignedValue != null)
            {
                kitchen.IsPrepared = assignedValue;
            }

            await _context.SaveChangesAsync();

            List<Kitchen> kitchens = await _context.Kitchens.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View("Index", kitchens);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int kitchenId)
        {
            return View(await _context.Kitchens.FindAsync(kitchenId));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Kitchen k)
        {
            Kitchen kitchen = await _context.Kitchens.Where(ki => ki.KitchenId == k.KitchenId).Include(ki => ki.MenuItem).FirstOrDefaultAsync();

            _context.Kitchens.Remove(kitchen);

            await _context.SaveChangesAsync();

            List<Kitchen> kitchens = await _context.Kitchens.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View("Index", kitchens);
        }
    }
}
