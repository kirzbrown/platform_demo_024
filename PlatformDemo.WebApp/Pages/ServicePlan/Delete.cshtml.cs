using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformDemo.DAL.Data;
using PlatformDemo.DAL.Model;


namespace PlatformDemo.WebApp.Pages.ServicePlan;

public class DeleteModel(PlatformDbContext context) : PageModel
{
    [BindProperty]
    public DAL.Model.ServicePlan ServicePlan { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        ServicePlan = await context.ServicePlans.FindAsync(id);

        if (ServicePlan == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        ServicePlan = await context.ServicePlans.FindAsync(id);

        if (ServicePlan != null)
        {
            context.ServicePlans.Remove(ServicePlan);
            await context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
