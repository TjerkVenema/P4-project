using System;
using System.Collections.Generic;
using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class OpdrachtControle : PageModel
    {
        [BindProperty] public List<Opdracht> opdrachten { get; set; }
        
        [BindProperty] public Opdracht Opdracht { get; set; }

        [BindProperty] public List<string> Studenten { get; set; }
        
        [BindProperty] public List<Aanvragen_student> AanvragenStudent { get; set; }

        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            AanvragenStudent = TriageRepository.GetAanvragen();

            if (id != 0 && rol == "triage")
            {
                var opdrachtId = Convert.ToInt32(Request.Cookies["opdrachtId"]);
                opdrachten = TriageRepository.Get();
                if (opdrachtId == 0)
                {
                    return RedirectToPage("/TriageHomepagina");
                }
                Opdracht = TriageRepository.GetById(opdrachtId);
                Studenten = TriageRepository.GetStudents(opdrachtId);
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