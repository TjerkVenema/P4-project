using System;
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

        public void OnGet()
        {
            int Id = Convert.ToInt32(Request.Cookies["AanvraagId"]);
            AanvragenStudent = TriageRepository.GetAanvraagById(Id);
        }

        public void OnPostJa()
        {
            int Id = Convert.ToInt32(Request.Cookies["AanvraagId"]);
            TriageRepository.StudentAanvraagGoedgekeurd(Id);
            Response.Redirect("/StatestiekenPagina");
        }
        
        public void OnPostNee()
        {
            int Id = Convert.ToInt32(Request.Cookies["AanvraagId"]);
            TriageRepository.StudentAanvraagAfgekeurd(Id);
            Response.Redirect("/StatestiekenPagina");
        }
    }
}