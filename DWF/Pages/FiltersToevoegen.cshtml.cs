using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class FiltersToevoegen : PageModel
    {
        [BindProperty]
        public string opleiding { get; set; }
        
        [BindProperty]
        public int studiejaar { get; set; }

        public void OnPostToevoegen()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            StudentRepository.AddFilters(id, opleiding, studiejaar);
            Response.Redirect("/ProfielPaginaStudent");
        }
        
        public void OnGet()
        {
            
        }
    }
}