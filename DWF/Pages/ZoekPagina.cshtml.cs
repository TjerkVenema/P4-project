using DWF.Helpers;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class ZoekPagina : PageModel
    {
        public void OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");

            if (id == 0 && rol == null)
            {
                Response.Redirect("/Error");
            }
        }
    }
}