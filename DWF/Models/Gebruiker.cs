using System;

namespace DWF.Models
{
    public class Gebruiker
    {
        public int gebruiker_id { get; set; }
        
        public string naam { get; set; }
        
        public string voornaam { get; set; }
        
        public string achternaam { get; set; }
        
        public string email { get; set; }
        
        public string opleidingsNiveau { get; set; }
        
        public string opleiding { get; set; }
        
        public string school { get; set; }
        
        public int studiejaar { get; set; }
        
        public string zakelijknummer { get; set; }
        
        public string wachtwoord { get; set; }
    }
}