using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlatformDemo.DAL.Data;
using PlatformDemo.DAL.Model;
using System.ComponentModel.DataAnnotations;

namespace PlatformDemo.WebApp.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnGet()
    {
        return RedirectToPage("/ServicePlan/Index");
    }
}
