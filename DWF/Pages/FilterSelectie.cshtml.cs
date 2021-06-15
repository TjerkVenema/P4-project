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
        
        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            Filters.OpleidingsNiveau = OpleidingsNiveau;
            Filters.Sector = Sector;
            Filters.Type = Type;
            Response.Redirect("/Zoekpagina");
        }
    }
}