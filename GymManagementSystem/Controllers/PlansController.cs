using GymManagement.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.PL.Controllers
{
    public class PlansController : Controller
    {

        private readonly IPlanRepository planRepository;
        public PlansController(IPlanRepository planRepository)
        {
            this.planRepository = planRepository;
        }

        //Index Action
        // Get BaseURL/Plans/Index Or BaseURL/Plans => Listing All Plans 
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var plans = await planRepository.GetAllAsync(cancellationToken: cancellationToken);

            return View(plans);
        }

        //Details Action
        // Get BaseURL/Plans/Details/ID => Displaying Details of a Specific Plan
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var plan = await planRepository.GetByIdAsync(id, cancellationToken);

            if (plan is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(plan);
        }

    }
}
