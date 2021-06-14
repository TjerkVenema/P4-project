using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class OpdrachtBekijken : PageModel
    {
        public Opdracht opdracht { get; set; }
        
        public void OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("opdrachtid");
            opdracht = TriageRepository.GetById(id);
        }
    }
}