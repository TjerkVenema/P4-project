using System;
using System.Collections.Generic;
using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class Aanvragen : PageModel
    {
        [BindProperty] public List<Aanvragen_student> aanvragenStudent { get; set; }

        [BindProperty] public int AanvraagStudentId { get; set; }

        [BindProperty] public List<Opdracht> opdrachten { get; set; }

        [BindProperty] public int opdrachtId { get; set; }
        
        public string GetNaam(int id)
        {
            return TriageRepository.GetNaam(id);
        }

        public void OnPostBekijkaanvraag()
        {
            Response.Cookies.Append("AanvraagId", AanvraagStudentId.ToString());
            Response.Redirect("/StudentAanvraagControle");
        }

        public void OnPostBekijkopdracht()
        {
            Response.Cookies.Append("OpdrachtAanvraagId", opdrachtId.ToString());
            Response.Redirect("/OpdrachtAanvraagControle");
        }
        
        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            if (id != 0 && rol == "triage")
            {
               Response.Cookies.Delete("AanvraagId");
               Response.Cookies.Delete("OpdrachtAanvraagId");
               aanvragenStudent = TriageRepository.GetAanvragen();
               opdrachten = TriageRepository.GetOpdrachtenBeoordeling();
               return Page(); 
            }
            else if (id != 0 && rol == "student")
            {
                return RedirectToPage("/homepaginastudents");
            }
            return RedirectToPage("/Index");
            
        }

    }
}