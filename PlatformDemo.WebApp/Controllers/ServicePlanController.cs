using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatformDemo.DAL.Data;

namespace PlatformDemo.WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServicePlanController(PlatformDbContext context) : Controller
    {
        private readonly PlatformDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            var servicePlans = await _context.ServicePlans
                .Include(sp => sp.TimeSheets)
                .ToListAsync();
            return View(servicePlans);
        }
    }   
}
