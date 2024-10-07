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
        //Retrieve service plan by id
        ServicePlan = await context.ServicePlans.FindAsync(id);

        if (ServicePlan == null)
        {
            // Return not found for invalid Ids
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        //Retrieve service plan by id
        ServicePlan = await context.ServicePlans.FindAsync(id);

        if (ServicePlan != null)
        {
            // Remove from database
            context.ServicePlans.Remove(ServicePlan);
            await context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
