using System;

namespace DWF.Models
{
    public class Aanvragen_student
    {
        public int aanvraag_id { get; set; }
        public int opdracht_id { get; set; }

        public int gebruiker_id { get; set; }

        public bool validatie_leeruitkomsten { get; set; }
        
        public string beschrijving { get; set; }

        public DateTime startDatum { get; set; }
        
        public DateTime eindDatum { get; set; }
        
        public string beschikbare_uren { get; set; }
        
        public string student_naam { get; set; }

        public string opdracht_naam { get; set; }
    }
}