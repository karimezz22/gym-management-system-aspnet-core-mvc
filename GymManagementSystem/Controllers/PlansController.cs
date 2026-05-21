using GymManagementSystem.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Controllers
{
    public class PlansController : Controller
    {
        private readonly GymDbContext dbContext;

        public PlansController()
        {
            dbContext = new GymDbContext();
        }

        //Index Action
        // Get BaseURL/Plans/Index Or BaseURL/Plans => Listing All Plans 
        public async Task<IActionResult> Index()
        {
            var plans = await dbContext.Plans.ToListAsync();

            return View(plans);
        }

        //Details Action
        // Get BaseURL/Plans/Details/ID => Displaying Details of a Specific Plan
        public async Task<IActionResult> Details(int id)
        {
            var plan = await dbContext.Plans.FindAsync(id);

            if (plan is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(plan);
        }

    }
}
