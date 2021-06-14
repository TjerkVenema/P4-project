using System;
using System.ComponentModel.DataAnnotations;
using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class InschrijvenStudent : PageModel
    {
        [BindProperty, Required(ErrorMessage = "Dit veld is verplicht")]
        public string beschrijving { get; set; }
        
        [BindProperty]
        public string uurbeschikbaar { get; set; }
        
        [BindProperty]
        public DateTime Datumvan { get; set; }
        
        [BindProperty]
        public DateTime Datumtot { get; set; }

        [BindProperty]
        public string bericht { get; set; }
        
        [BindProperty]
        public string bericht2 { get; set; }
        
        [BindProperty]
        public string bericht3 { get; set; }
        
        [BindProperty]
        public Opdracht Opdracht { get; set; }
        
        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            //cookie request met id van de opdracht
            if (id != 0 && rol == "student")
            {
                /*if (opdrachtid == 0)
                {
                    return RedirectToPage("homepaginastudents");
                }*/
                Datumtot = DateTime.Today; 
                Datumvan = DateTime.Today;
                Opdracht = TriageRepository.GetById(1);
                return Page();
            }
            else if (id != 0 && rol == "triage")
            {
                return RedirectToPage("/TriageHomepagina");
            }
            return RedirectToPage("/Index");
        }

        public void OnPostNee()
        {
            Response.Cookies.Append("studiepunten", "Nee");
            Response.Redirect("/InschrijvenStudent");
        }
        public void OnPostJa()
        {
            Response.Cookies.Append("studiepunten", "Ja");
            Response.Redirect("/InschrijvenStudent");
        }
        
        public void OnPostInschrijven()
        {
            Opdracht = TriageRepository.GetById(1);
            if (Request.Cookies["studiepunten"] == null)
            {
                bericht3 = "Kies alstublieft een optie";
            }

            else if (Datumvan < Datumtot && Request.Cookies["studiepunten"] == "Nee" && ModelState.IsValid)
            {
                Aanvragen_student nieuweaanvraag = new Aanvragen_student();
                nieuweaanvraag.gebruiker_id = 36;
                nieuweaanvraag.opdracht_id = 1;
                if (Request.Cookies["studiepunten"] == "Ja")
                {
                    nieuweaanvraag.validatieLeeruitkomsten = true;
                }
                else
                {
                    nieuweaanvraag.validatieLeeruitkomsten = false;
                    nieuweaanvraag.beschrijving = beschrijving;
                }

                nieuweaanvraag.startDatum = Datumvan;
                nieuweaanvraag.eindDatum = Datumtot;
                nieuweaanvraag.beschikbareUren = uurbeschikbaar;
                StudentRepository.AddAanvraag(nieuweaanvraag);
                Response.Cookies.Delete("studiepunten");
                Response.Redirect("/ProfielPaginaStudent");
            }
            
            else if (Datumvan < Datumtot && Request.Cookies["studiepunten"] == "Ja")
            {
                Aanvragen_student nieuweaanvraag = new Aanvragen_student();
                nieuweaanvraag.gebruiker_id = 36;
                nieuweaanvraag.opdracht_id = 1;
                if (Request.Cookies["studiepunten"] == "Ja")
                {
                    nieuweaanvraag.validatieLeeruitkomsten = true;
                }
                else
                {
                    nieuweaanvraag.validatieLeeruitkomsten = false;
                    nieuweaanvraag.beschrijving = beschrijving;
                }

                nieuweaanvraag.startDatum = Datumvan;
                nieuweaanvraag.eindDatum = Datumtot;
                nieuweaanvraag.beschikbareUren = uurbeschikbaar;
                StudentRepository.AddAanvraag(nieuweaanvraag);
                Response.Cookies.Delete("studiepunten");
                Response.Redirect("/ProfielPaginaStudent");
            }
            else if (Datumvan > Datumtot || Datumvan == Datumtot)
            {
                bericht = "Voer alstublieft een geldige datum in";
            }
            else
            {
                bericht2 = "Voer alstublieft de velden goed in";
            }
        }

        public void OnPostAnulleren()
        {
            Response.Cookies.Delete("studiepunten");
            Response.Redirect("/ProfielPaginaStudent");
        }
        
    }
}