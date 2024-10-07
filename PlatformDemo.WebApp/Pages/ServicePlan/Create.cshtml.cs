using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlatformDemo.DAL.Data;
using PlatformDemo.DAL.Model;


namespace PlatformDemo.WebApp.Pages.ServicePlan;

public class CreateModel(PlatformDbContext context) : PageModel
{
    [BindProperty]
    public DAL.Model.ServicePlan ServicePlan { get; set; }
    [BindProperty]
    public List<TimeSheet> TimeSheets { get; set; } = new List<TimeSheet>();

    public IActionResult OnGet()
    {
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

        // Create a new ServicePlan and set properties
        var newServicePlan = new DAL.Model.ServicePlan
        {
            DateOfPurchase = ServicePlan.DateOfPurchase
            // Set other properties of ServicePlan if necessary
        };

        // Add the ServicePlan to the context
        context.ServicePlans.Add(newServicePlan);
        await context.SaveChangesAsync(); // Save to generate the ServicePlanId

        // Now add the TimeSheets and link them to the ServicePlan
        foreach (var timeSheet in TimeSheets)
        {
            if (ModelState.IsValid)
            {
                // Create a new TimeSheet
                var newTimeSheet = new TimeSheet
                {
                    StartTime = timeSheet.StartTime,
                    EndTime = timeSheet.EndTime,
                    Description = timeSheet.Description,
                    ServicePlanId = newServicePlan.Id // Link to the created ServicePlan
                };

                // Add the TimeSheet to the context
                context.TimeSheets.Add(newTimeSheet);
            }
        }

        try
        {
            await context.SaveChangesAsync(); // Save all TimeSheets
        }
        catch (DbUpdateConcurrencyException)
        {
            // Handle concurrency exception if needed
            throw; // or return an appropriate error response
        }

        return RedirectToPage("./Index");
    }



}
