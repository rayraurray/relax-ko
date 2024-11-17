using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelaxingKoala.Data;
using RelaxingKoala.Models;

namespace RelaxingKoala.Controllers
{
    [Authorize(Roles = "Manager")]
	public class StatisticsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public StatisticsController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

			return View(await _context.Statistics.ToListAsync());
		}

		public async Task<IActionResult> ChangeMenuItems(int menuItemId)
		{
			List<Statistics> filterStatistics;

			ViewBag.MenuItems = await _context.MenuItems.ToListAsync();
			ViewBag.SelectedMenuItem = menuItemId;

			if (menuItemId != 0)
			{
				filterStatistics = await _context.Statistics.Where(s => s.MenuItem.MenuItemId == menuItemId).ToListAsync();
			}
			else
			{
				filterStatistics = await _context.Statistics.ToListAsync();
			}

			return View("Index", filterStatistics);
		}

        [HttpGet]
        public async Task<IActionResult> AddStatistics()
        {
            ViewBag.Statistics = await _context.Statistics.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStatistics(Statistics s, string assignedMenuItem)
        {

            if (assignedMenuItem != null)
            {
                MenuItem i = _context.MenuItems.Find(int.Parse(assignedMenuItem));
                s.MenuItem = i;
            }

            _context.Statistics.Add(s);

            await _context.SaveChangesAsync();

            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();
            List<Statistics> statistics = await _context.Statistics.ToListAsync();

            return View("Index", statistics);
        }

        [HttpGet]
        public async Task<IActionResult> EditStatistics(int statId)
        {

            var statistics = await _context.Statistics.Include(s => s.MenuItem).FirstOrDefaultAsync(s => s.StatisticsId == statId);

            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View(statistics);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyStatistics(Statistics s, int assignedMenuItem)
        {
            Statistics statistic = await _context.Statistics.Where(st => st.StatisticsId == s.StatisticsId).Include(st => st.MenuItem).FirstOrDefaultAsync();


            if (assignedMenuItem != null)
            {
                statistic.MenuItemId = assignedMenuItem;
            }

            await _context.SaveChangesAsync();

            List<Statistics> statistics = await _context.Statistics.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View("Index", statistics);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int statId)
        {
            return View(await _context.Statistics.FindAsync(statId));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Statistics s)
        {
            Statistics statistic = await _context.Statistics.Where(st => st.StatisticsId == s.StatisticsId).Include(st => st.MenuItem).FirstOrDefaultAsync();

            _context.Statistics.Remove(statistic);

            await _context.SaveChangesAsync();

            List<Statistics> statistics = await _context.Statistics.ToListAsync();
            ViewBag.MenuItems = await _context.MenuItems.ToListAsync();

            return View("Index", statistics);
        }
    }
}
