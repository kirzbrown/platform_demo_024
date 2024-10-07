using System.ComponentModel.DataAnnotations;

namespace PlatformDemo.DAL.Model;

public class ServicePlan
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Date of Purchase is required.")]
    public DateTime DateOfPurchase { get; set; }

    public List<TimeSheet> TimeSheets { get; set; } = new List<TimeSheet>(); // Updated to TimeSheet
}
