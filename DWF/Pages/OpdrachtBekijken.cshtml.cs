using System;
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
            opdracht = TriageRepository.GetById(Convert.ToInt32(Request.Query["opdracht"]));
        }
    }
}