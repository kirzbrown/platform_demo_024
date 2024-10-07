using System.ComponentModel.DataAnnotations;

namespace PlatformDemo.DAL.Model;

public class TimeSheet
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Start Time is required.")]
    public DateTime StartTime { get; set; }

    [Required(ErrorMessage = "End Time is required.")]
    public DateTime EndTime { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; }

    public int? ServicePlanId { get; set; } // Allowing it to be nullable
    public ServicePlan? ServicePlan { get; set; } // Navigation property, no validation
}