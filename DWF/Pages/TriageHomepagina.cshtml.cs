using System.Collections.Generic;
using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class TriageHomepagina : PageModel
    {
        [BindProperty] public List<Opdracht> opdrachten { get; set; }

        [BindProperty] public int opdrachtId { get; set; }
        
        [BindProperty] public List<Aanvragen_student> AanvragenStudent { get; set; }


        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            AanvragenStudent = TriageRepository.GetAanvragen();
            if (id != 0 && rol == "triage")
            {
                Response.Cookies.Delete("opdrachtId"); 
                opdrachten = TriageRepository.Get();
                return Page(); 
            }
            else if (id != 0 && rol == "student")
            {
                return RedirectToPage("/homepaginastudents");
            }
            return RedirectToPage("/Index");
        }

        public void OnPostBekijk()
        {
            var opdrachtid = opdrachtId;
            Response.Cookies.Append("opdrachtId", opdrachtid.ToString());
            Response.Redirect("/OpdrachtControle");
        }
    }
}