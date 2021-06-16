using DWF.Helpers;
using DWF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class ZoekPagina : PageModel
    {
        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol"); 
            
            if (id != 0 && rol == "student")
            {
                return Page();
            }
            if (id != 0 && rol == "triage")
            {
                return RedirectToPage("/TriageHomepagina"); 
            }
            
            return RedirectToPage("/Index");
        }
    }
}