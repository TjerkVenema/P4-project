using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using Dapper;
using System.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace account.Pages
{
    public class AccountModel : PageModel
    {
        public LoginRepository loginRepository = new LoginRepository();
        [BindProperty, Required(ErrorMessage = "geef alstublieft een E-mailadres op ."), EmailAddress(ErrorMessage = "geef alstublieft een E-mailadres op.")]       
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
                if (loginRepository.IsUserValidLogin(FormEmail, FormPassword))
                {
                    int id = loginRepository.GetUserID(FormEmail);
                    HttpContext.Session.SetString("ID", id.ToString());
                    Response.Redirect("/", permanent: true);
                }
                else
                {
                    Msg = "Incorrect e-mailadres of wachtwoord ";
                }

            }
            else
            {
                Msg ="Incorrect e-mailadres of wachtwoord ";
            }
        }
    }
}