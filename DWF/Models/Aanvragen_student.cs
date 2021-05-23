namespace DWF.Models
{
    public class Aanvragen_student
    {
        public int opdracht_id { get; set; }

        public int gebruiker_id { get; set; }

        public string beschrijving { get; set; }

        public string student_naam { get; set; }

        public string opdracht_naam { get; set; }
    }
}