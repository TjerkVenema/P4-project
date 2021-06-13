using System;
using Account.models;
using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class StudentAanvraagControle : PageModel
    {
        [BindProperty]
        public Aanvragen_student AanvragenStudent { get; set; }
        
        [BindProperty]
        public Gebruiker student { get; set; }

        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            if (id != 0 && rol == "triage")
            {
                int Id = Convert.ToInt32(Request.Cookies["AanvraagId"]);
                if (Id == 0)
                {
                    return RedirectToPage("/TriageHomepagina");
                }
                student = TriageRepository.GetStudentAanvraag(Id);
                AanvragenStudent = TriageRepository.GetAanvraagById(Id);
                return Page(); 
            }
            else if (id != 0 && rol == "student")
            {
                return RedirectToPage("/ProfielPaginaStudent");
            }
            return RedirectToPage("/Index");
        }

        public void OnPostJa()
        {
            int Id = Convert.ToInt32(Request.Cookies["AanvraagId"]);
            TriageRepository.StudentAanvraagGoedgekeurd(Id);
            Response.Redirect("/Aanvragen");
        }
        
        public void OnPostNee()
        {
            int Id = Convert.ToInt32(Request.Cookies["AanvraagId"]);
            TriageRepository.StudentAanvraagAfgekeurd(Id);
            Response.Redirect("/Aanvragen");
        }
    }
}