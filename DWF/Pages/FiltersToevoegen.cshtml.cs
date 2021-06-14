using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class FiltersToevoegen : PageModel
    {
        [BindProperty]
        public string opleiding { get; set; }
        
        [BindProperty]
        public int studiejaar { get; set; }
        
        [BindProperty]
        public Gebruiker Gebruiker { get; set; }

        public void OnPostToevoegen()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            StudentRepository.AddFilters(id, opleiding, studiejaar);
            Response.Redirect("/ProfielPaginaStudent");
        }
        
        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            if (id != 0 && rol == "student")
            {
                Gebruiker = StudentRepository.GetStudent(id);
                if (Gebruiker.opleiding == null)
                {
                    return Page(); 
                }
                return RedirectToPage("/ProfielPaginaStudent");
            }
            else if (id != 0 && rol == "triage")
            {
                return RedirectToPage("/TriageHomepagina");
            }
            return RedirectToPage("/Index");
        }
    }
}