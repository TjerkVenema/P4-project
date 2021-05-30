using System.ComponentModel.DataAnnotations;
using DWF.Helpers;
using DWF.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class login : PageModel
    {
        public InlogRepository LoginRepository = new InlogRepository();

        [BindProperty, Required(ErrorMessage = "geef alstublieft een E-mailadres op ."),
         EmailAddress(ErrorMessage = "geef alstublieft een E-mailadres op.")]
        public string Email { get; set; }

        [BindProperty, Required(ErrorMessage = "geef alstublieft een geldig wachtwoord op")]
        public string Password { get; set; }

        public string Msg { get; set; }

        public void OnGet()
        {
        }


        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (InlogRepository.Login(Email, Password))
                {
                    int id = InlogRepository.GetUserID(Email);
                    HttpContext.Session.SetObjectAsJson("ID", id);
                    Response.Redirect("/ProfielPaginaStudent");
                }
                else
                {
                    Msg = "Incorrect e-mailadres of wachtwoord ";
                }

            }
            else
            {
                Msg = "Incorrect e-mailadres of wachtwoord ";
            }
        }
    }
}