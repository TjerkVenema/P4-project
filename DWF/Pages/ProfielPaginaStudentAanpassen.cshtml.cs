using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ubiety.Dns.Core.Records.NotUsed;

namespace DWF.Pages
{
    public class ProfielPaginaStudentAanpassen : PageModel
    {
        [BindProperty]
        public Gebruiker Gebruiker { get; set; }

        [BindProperty,
         RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,16}$",
             ErrorMessage = "Uw wachtwoord voldoet niet aan de vereisten.")]
        public string wachtwoord { get; set; }

        [BindProperty]
        public string wachtwoordcheck { get; set; }
        
        [BindProperty]
        public string opleidingsniveau { get; set; }
        
        [BindProperty]
        public int studiejaar { get; set; }
        
        [BindProperty]
        public string opleiding { get; set; }

        public string Bericht { get; set; }
        

        public void OnPostPasaan()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            Gebruiker = StudentRepository.GetStudent(id);

            bool wachtwoordgoed = WachtwoordCheck();
            
            if (ModelState.IsValid && wachtwoordgoed)
            {
                if (opleidingsniveau != null)
                {
                    Gebruiker.opleidingsNiveau = opleidingsniveau;
                }
                
                if (opleiding != null)
                {
                    Gebruiker.opleiding = opleiding;
                }
                if (studiejaar != 0)
                {
                    Gebruiker.studiejaar = studiejaar;
                }
                if (wachtwoord != null)
                { 
                    Gebruiker.wachtwoord = wachtwoord;
                }
                StudentRepository.UpdateStudent(Gebruiker);
                Response.Redirect("/ProfielPaginaStudent");
            }
            else
            {
                if (wachtwoordcheck == null && wachtwoord != null)
                {
                    Bericht = "Bijde velden zijn verplicht";
                } 
                else if (wachtwoordcheck != Gebruiker.wachtwoord)
                {
                    Bericht = "Onjuist wachtwoord ingevoerd";
                }
            }
            
        }

        public bool WachtwoordCheck()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            Gebruiker = StudentRepository.GetStudent(id);
            if (wachtwoordcheck == Gebruiker.wachtwoord || wachtwoord == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            Gebruiker = StudentRepository.GetStudent(id);
        }
    }
}