using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class InschrijvenStudent : PageModel
    {
        [BindProperty]
        public string beschrijving { get; set; }
        
        [BindProperty]
        public string uurbeschikbaar { get; set; }
        
        [BindProperty]
        public DateTime Datumvan { get; set; }
        
        [BindProperty]
        public DateTime Datumtot { get; set; }
        
        public void OnGet()
        {
            
        }

        public void OnPostInschrijven()
        {
            
        }
        
    }
}