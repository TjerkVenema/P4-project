using System;
using System.Collections.Generic;
using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class StudentAanvraagControle : PageModel
    {
        [BindProperty] public List<Opdracht> opdrachten { get; set; }
        
        [BindProperty]
        public Aanvragen_student aanvragenStudent { get; set; }
        
        [BindProperty]
        public Gebruiker student { get; set; }
        
        [BindProperty] public List<Aanvragen_student> AanvragenStudent { get; set; }
        

        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            AanvragenStudent = TriageRepository.GetAanvragen();
            if (id != 0 && rol == "triage")
            {
                int Id = Convert.ToInt32(Request.Cookies["AanvraagId"]);
                opdrachten = TriageRepository.Get();
                if (Id == 0)
                {
                    return RedirectToPage("/TriageHomepagina");
                }
                student = TriageRepository.GetStudentAanvraag(Id);
                aanvragenStudent = TriageRepository.GetAanvraagById(Id);
                return Page(); 
            }
            else if (id != 0 && rol == "student")
            {
                return RedirectToPage("/homepaginastudents");
            }
            return RedirectToPage("/Index");
        }

        public void OnPostJa()
        {
            int Id = Convert.ToInt32(Request.Cookies["AanvraagId"]);
            if (TriageRepository.StudentAanvraagGoedgekeurd(Id))
            {
                Response.Redirect("/Aanvragen");
            }
            else
            {
                Response.Redirect("/Error");
            }
        }
        

        public void OnPostNee()
        {
            int Id = Convert.ToInt32(Request.Cookies["AanvraagId"]);
            TriageRepository.StudentAanvraagAfgekeurd(Id);
            Response.Redirect("/Aanvragen");
        }
    }
}