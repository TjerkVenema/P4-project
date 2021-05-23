namespace DWF.Models
{
    public class Opdracht
    {
        public enum status
        {
            bezig,
            beschikbaar,
            afgerond,
            moet_beoordeeld
        }

        public int opdracht_id { get; set; }

        public int gebruiker_id { get; set; }

        public string opdracht_naam { get; set; }

        public string beschrijving { get; set; }

        public string gewenste_opleiding { get; set; }

        public status opdracht_status { get; set; }
    }
}