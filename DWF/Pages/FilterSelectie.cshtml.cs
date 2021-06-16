using DWF.Helpers;
using DWF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class FilterSelectie : PageModel
    {

        
        [BindProperty]
        public string Type { get; set; }
        
        [BindProperty]
        public string Sector { get; set; }
        
        [BindProperty]
        public string OpleidingsNiveau { get; set; }
        
        [BindProperty]
        public string Opleidingsjaar { get; set; }

        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            if (id != 0 && rol != null)
            {
                if (rol == "student")
                {
                    return Page();
                }
            
                if (rol == "triage")
                {
                    return RedirectToPage("/TriageHomepagina");
                }
            }

            return RedirectToPage("/Index");
        }
        

        public void OnPost()
        {
            Filters.Opleidingsjaar = Opleidingsjaar;
            Filters.OpleidingsNiveau = OpleidingsNiveau;
            Filters.Sector = Sector;
            Filters.Type = Type;
            Response.Redirect("/Zoekpagina");
        }
    }
}