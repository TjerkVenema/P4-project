using DWF.Helpers;
using DWF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class ZoekPagina : PageModel
    {
        [BindProperty]
        public Opdracht Opdracht { get; set; }
        
        public void OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");

            if (id == 0 && rol == null)
            {
                Response.Redirect("/Error");
            }
        }

        public IActionResult OnPostBekijk()
        {
            HttpContext.Session.SetObjectAsJson("opdrachtid", Opdracht.opdracht_id);
            return RedirectToPage("OpdrachtBekijken");
        }
    }
}