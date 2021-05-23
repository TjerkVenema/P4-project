using System.Collections.Generic;
using DWF.Models;
using DWF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWF.Pages
{
    public class StatestiekenPagina : PageModel
    {
        [BindProperty] public List<Aanvragen_student> aanvragenStudent { get; set; }

        [BindProperty] public Aanvragen_student AanvraagStudent { get; set; }

        [BindProperty] public List<Opdracht> opdrachten { get; set; }

        [BindProperty] public Opdracht opdracht { get; set; }
        
        public string GetNaam(int id)
        {
            return TriageRepository.GetNaam(id);
        }

        public void OnPostBekijkaanvraag()
        {
            //moet nog
        }

        public void OnPostBekijkopdracht()
        {
            //moet nog
        }
        
        public void OnGet()
        {
            aanvragenStudent = TriageRepository.GetAanvragen();
            opdrachten = TriageRepository.GetOpdrachtenBeoordeling();
        }

    }
}