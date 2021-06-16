using System;
using DWF.Helpers;
using DWF.Models;
using DWF.Repository;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class OpdrachtBekijken : PageModel
    {
        public Opdracht opdracht { get; set; }
        
        public IActionResult OnGet()
        {
            int id = HttpContext.Session.GetObjectFromJson<int>("ID");
            string rol = HttpContext.Session.GetObjectFromJson<string>("Rol");
            if (id != 0 && rol != null)
            {
                if (rol == "student")
                {
                    opdracht = TriageRepository.GetById(Convert.ToInt32(Request.Query["opdracht"]));
                    return Page();
                }

                if (rol == "triage")
                {
                    return RedirectToPage("/TriageHomepagina");
                }
            }

            return RedirectToPage("/Index");


        }
    }
}