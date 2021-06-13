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
        
        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            Filters.Type = Type;
            Response.Redirect("/Zoekpagina");
        }
    }
}