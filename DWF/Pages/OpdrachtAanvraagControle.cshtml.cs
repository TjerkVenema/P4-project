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

        public void OnGet()
        {
            int Id = Convert.ToInt32(Request.Cookies["OpdrachtAanvraagId"]);
            opdrachtaanvraag = TriageRepository.GetOpdrachtAanvraag(Id);  
            opdrachtgever = TriageRepository.GetGebruiker(opdrachtaanvraag.gebruiker_id);
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