using System;
using System.Collections.Generic;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class OpdrachtControle : PageModel
    {
        [BindProperty] public Opdracht Opdracht { get; set; }

        [BindProperty] public List<string> Studenten { get; set; }

        public void OnGet()
        {
            var opdrachtId = Convert.ToInt32(Request.Cookies["opdrachtId"]);
            Opdracht = TriageRepository.GetById(opdrachtId);
            Studenten = TriageRepository.GetStudents(opdrachtId);
        }
    }
}