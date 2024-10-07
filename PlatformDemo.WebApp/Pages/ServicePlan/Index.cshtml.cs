using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlatformDemo.DAL.Data;
using PlatformDemo.DAL.Model;


namespace PlatformDemo.WebApp.Pages.ServicePlan;

public class IndexModel(PlatformDbContext context) : PageModel
{
    [BindProperty]
    public IList<DAL.Model.ServicePlan> ServicePlans { get; set; }

    public async Task OnGetAsync()
    {
        // Set the Service Plans from database
        ServicePlans = await context.ServicePlans.Include(i => i.TimeSheets).ToListAsync();
    }
}
