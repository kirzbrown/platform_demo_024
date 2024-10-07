using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlatformDemo.DAL.Data;
using PlatformDemo.DAL.Model;


namespace PlatformDemo.WebApp.Pages.ServicePlan;

public class EditModel : PageModel
{
    private readonly PlatformDbContext context; // Replace with your actual DbContext

    public EditModel(PlatformDbContext context)
    {
        this.context = context;
    }

    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public DAL.Model.ServicePlan ServicePlan { get; set; }

    [BindProperty]
    public List<TimeSheet> TimeSheets { get; set; } = new List<TimeSheet>();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        ServicePlan = await context.ServicePlans.FindAsync(id);
        TimeSheets = await context.TimeSheets.Where(ts => ts.ServicePlanId == id).ToListAsync();

        if (ServicePlan == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Collect the indices of invalid TimeSheets
            var invalidTimeSheetIndices = new List<int>();

            for (int i = 0; i < TimeSheets.Count; i++)
            {
                // Check if there are any validation errors for the TimeSheet properties
                if (ModelState.TryGetValue($"TimeSheets[{i}].StartTime", out var startTimeEntry) && startTimeEntry.Errors.Count > 0 ||
                    ModelState.TryGetValue($"TimeSheets[{i}].EndTime", out var endTimeEntry) && endTimeEntry.Errors.Count > 0 ||
                    ModelState.TryGetValue($"TimeSheets[{i}].Description", out var descriptionEntry) && descriptionEntry.Errors.Count > 0)
                {
                    invalidTimeSheetIndices.Add(i + 1); // +1 for a 1-based index display
                }
            }

            // Store the indices in ViewData for use in the view
            ViewData["OpenAccordion"] = invalidTimeSheetIndices;
            return Page(); // Return the page with validation messages
        }

        // Retrieve the existing entity based on the Id from the POST data
        var existingServicePlan = await context.ServicePlans.FindAsync(Id);

        if (existingServicePlan == null)
        {
            return NotFound();
        }

        // Update the fields of the existing entity with the posted data
        existingServicePlan.DateOfPurchase = ServicePlan.DateOfPurchase;

        // Update TimeSheets
        // Here, you might want to clear existing TimeSheets and add new ones or update them accordingly
        context.TimeSheets.RemoveRange(context.TimeSheets.Where(ts => ts.ServicePlanId == existingServicePlan.Id));
        foreach (var timeSheet in TimeSheets)
        {
            timeSheet.ServicePlanId = existingServicePlan.Id; // Set the ServicePlanId for the new TimeSheets
            context.TimeSheets.Add(timeSheet);
        }

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServicePlanExists(Id)) // Use the Id from the POST data
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool ServicePlanExists(int id)
    {
        return context.ServicePlans.Any(e => e.Id == id);
    }
}