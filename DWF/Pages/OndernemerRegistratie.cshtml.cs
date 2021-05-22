using System;
using System.ComponentModel.DataAnnotations;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class OndernemerRegistratie : PageModel
    {
        [BindProperty, Required(ErrorMessage = "Voer alstublieft een geldig e-mailadres in."),
         EmailAddress(ErrorMessage = "Voer alstublieft een geldig e-mailadres in.")]
        public string Email { get; set; }

        [BindProperty, Required(ErrorMessage = "Voer alstublieft een geldig wachtwoord in"), RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,16}$", ErrorMessage = "Uw wachtwoord voldoet niet aan de vereisten.")]
        public string Wachtwoord { get; set; }
        
        [BindProperty, Required(ErrorMessage = "Voer alstublieft uw voornaam in.")]
        public string Voornaam { get; set; }
        
        [BindProperty, Required(ErrorMessage = "Voer alstublieft uw achternaam in.")]
        public string Achternaam { get; set; }

        [BindProperty, Required] 
        public int? ZakelijkNummer { get; set; }

        public string Bericht { get; set; }

        public RegistratieRepository registratieRepository = new RegistratieRepository();

        public void OnGet()
        {
      
        }

        public void OnPost()
        {
            bool isDubbel = RegistratieRepository.Isdubbel(Email);
            if (ModelState.IsValid && !isDubbel)
            {
                int gebruiker = registratieRepository.CreateAccount(Email, Wachtwoord, Voornaam, Achternaam, null,
                        ZakelijkNummer);
                    string doel = String.Format("/{0}", gebruiker);
                    Response.Redirect(doel, permanent: true);
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
        }
        

    }
}