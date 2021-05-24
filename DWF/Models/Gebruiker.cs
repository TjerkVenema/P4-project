using System;

namespace DWF.Models
{
    public class Gebruiker
    {
        public enum opleidings_niveau
        {
            MBO,
            HBO,
            Universiteit
        }
        public int gebruiker_id { get; set; }
        
        public string naam { get; set; }
        
        public string email { get; set; }
        
        public opleidings_niveau opleiding { get; set; }
        
        public string zakelijknummer { get; set; }
    }
}