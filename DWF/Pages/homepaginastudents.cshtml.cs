using System.Collections.Generic;
using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class Homepaginastudents : PageModel
    {
        public List<Opdracht> Opdrachten { get; set; }
        
        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            if (id != 0 && rol != null)
            {
                if (rol == "student")
                {
                    Opdrachten = StudentRepository.GetOpdrachten(id);
                    return Page();
                }

                if (rol == "triage")
                {
                    return RedirectToPage("/TriageHomepagina");
                }
            }

            return RedirectToPage("/Index");
            
        }

        public void Onpost()
        {
            
        }

    }
}