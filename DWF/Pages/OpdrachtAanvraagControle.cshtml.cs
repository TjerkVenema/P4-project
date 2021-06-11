using System;
using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class OpdrachtAanvraagControle : PageModel
    {
        [BindProperty]
        public Opdracht opdrachtaanvraag { get; set; }
        
        [BindProperty]
        public Gebruiker opdrachtgever { get; set; }

        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            if (id != 0 && rol == "triage")
            {
                int Id = Convert.ToInt32(Request.Cookies["OpdrachtAanvraagId"]);
                if (Id == 0)
                {
                    return RedirectToPage("/TriageHomepagina");
                }
                opdrachtaanvraag = TriageRepository.GetOpdrachtAanvraag(Id); 
                opdrachtgever = TriageRepository.GetGebruiker(opdrachtaanvraag.gebruiker_id);
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
            int Id = Convert.ToInt32(Request.Cookies["OpdrachtAanvraagId"]);
            TriageRepository.OpdrachtAanvraagGoedgekeurd(Id);
            Response.Redirect("/Aanvragen");
        }
        
        public void OnPostNee()
        {
            int Id = Convert.ToInt32(Request.Cookies["OpdrachtAanvraagId"]);
            TriageRepository.OpdrachtAanvraagAfgekeurd(Id);
            Response.Redirect("/Aanvragen");
        }
    }
}