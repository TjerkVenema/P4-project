using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class ProfielPaginaStudent : PageModel
    {
        [BindProperty]
        public Gebruiker Gebruiker { get; set; }

        public void OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            Gebruiker = StudentRepository.GetStudent(id);
            if (Gebruiker.opleiding == null)
            {
                Response.Redirect("/FiltersToevoegen");
            }
        }
    }
}