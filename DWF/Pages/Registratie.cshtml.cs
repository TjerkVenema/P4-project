using System.ComponentModel.DataAnnotations;
using DWF.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class Registratie : PageModel
    {
        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            if (id != 0 && rol != null)
            {
                if (rol == "student")
                {
                    return RedirectToPage("/ProfielPaginaStudent");
                }

                if (rol == "triage")
                {
                    return RedirectToPage("/TriageHomepagina");
                }
            }
            return Page();
        }

        
    }
}