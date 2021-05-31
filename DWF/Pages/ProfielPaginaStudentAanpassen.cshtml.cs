using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        
        [BindProperty, MinLength(2, ErrorMessage = "Uw voornaam moet minimaal 2 letters bevatten")]
        public string voornaam { get; set; }
        
        [BindProperty, MinLength(2, ErrorMessage = "Uw achternaam moet minimaal 2 letters bevatten")]
        public string achternaam { get; set; }
        
        
        [BindProperty,
         EmailAddress(ErrorMessage = "Voer alstublieft een geldig e-mailadres in")]
        public string email { get; set; }
        
        [BindProperty]
        public string opleiding { get; set; }

        public string Bericht { get; set; }
        

        public void OnPostPasaan()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            Gebruiker = StudentRepository.GetStudent(id);
            bool isDubbel = RegistratieRepository.Isdubbel(email);
            if (ModelState.IsValid && !isDubbel)
            {
                Gebruiker nieuweGebruiker = new Gebruiker();
                nieuweGebruiker.voornaam = voornaam;
                nieuweGebruiker.achternaam = achternaam;
                nieuweGebruiker.email = email;
                nieuweGebruiker.opleiding = opleiding;
                nieuweGebruiker.wachtwoord = wachtwoord;
                
                if (nieuweGebruiker.voornaam != null)
                {
                    Gebruiker.voornaam = nieuweGebruiker.voornaam;
                }
                if (nieuweGebruiker.achternaam != null)
                {
                    Gebruiker.achternaam = nieuweGebruiker.achternaam;
                }
                if (nieuweGebruiker.email != null)
                {
                    Gebruiker.email = nieuweGebruiker.email;
                }
                if (nieuweGebruiker.opleiding != null)
                {
                    Gebruiker.opleiding = nieuweGebruiker.opleiding;
                }
                if (nieuweGebruiker.wachtwoord != null)
                {
                    Gebruiker.wachtwoord = nieuweGebruiker.wachtwoord;
                }
                StudentRepository.UpdateStudent(Gebruiker);
            }
            else
            {
                if (isDubbel)
                {
                    Bericht = "Dit e-mailadres is al geregistreerd.";
                }
                else
                {
                    Bericht = "Voer alstublieft de velden juist in.";
                }
            }
            Response.Redirect("/ProfielPaginaStudent");
        }
        
        public void OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            //ik moet even commenten want anders kan ik niet commiten 
            Gebruiker = StudentRepository.GetStudent(id);
        }
    }
}