using System.Collections.Generic;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class TriageHomepagina : PageModel
    {
        [BindProperty] public List<Opdracht> opdrachten { get; set; }

        [BindProperty] public int opdrachtId { get; set; }

        public void OnGet()
        {
            Response.Cookies.Delete("opdrachtId");
            opdrachten = TriageRepository.Get();
        }

        public void OnPostBekijk()
        {
            var opdrachtid = opdrachtId;
            Response.Cookies.Append("opdrachtId", opdrachtid.ToString());
            Response.Redirect("/OpdrachtControle");
        }
    }
}