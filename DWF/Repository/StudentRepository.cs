using Dapper;
using DWF.Models;

namespace DWF.Repository
{
    public class StudentRepository
    {
        public static Repository repository = new Repository();

        public static Gebruiker GetStudent(int Id)
        {
            using var connectie = repository.Connect();
            var gebruiker = connectie.QuerySingleOrDefault<Gebruiker>(
                "SELECT * FROM gebruikers WHERE gebruiker_id = @gebruiker_id",
                new
                {
                    gebruiker_id = Id
                });

            gebruiker.naam = repository.GetNaam(Id);
            
            return gebruiker;
        }

        public static void UpdateStudent(Gebruiker gebruiker)
        {
            using var connectie = repository.Connect();
            connectie.Execute(
                "UPDATE gebruikers SET wachtwoord = @Wachtwoord, opleiding = @Opleiding, opleidingsniveau = @opleidingsniveau, studiejaar = @Studiejaar WHERE gebruiker_id = @gebruikerId",
                new
                {
                    gebruikerId = gebruiker.gebruiker_id,
                    Wachtwoord = gebruiker.wachtwoord,
                    Opleiding = gebruiker.opleiding,
                    opleidingsniveau = gebruiker.opleidingsNiveau,
                    Studiejaar = gebruiker.studiejaar
                });
        }

        public static void AddFilters(int id, string Opleiding, int jaar)
        {
            using var connectie = repository.Connect();
            connectie.Execute(
                "UPDATE gebruikers SET opleiding = @opleiding, studiejaar = @studiejaar WHERE gebruiker_id = @gebruikers_id",
                new
                {
                    opleiding = Opleiding,
                    studiejaar = jaar,
                    gebruikers_id = id
                });
        }

        public static void AddAanvraag(Aanvragen_student aanvraag)
        {
            using var connectie = repository.Connect();
            connectie.Execute(
                @"INSERT INTO aanvragen_student(gebruiker_id, opdracht_id, validatie_leeruitkomsten, beschrijving, startdatum, einddatum, beschikbare_uren)
                     VALUES (@gebruikerId, @opdrachtId, @validatie_leeruitkomsten, @Beschrijving, @startdatum, @einddatum, @beschikbare_uren)",
            new
                {
                    gebruikerId = aanvraag.gebruiker_id,
                    opdrachtId = aanvraag.opdracht_id,
                    validatie_leeruitkomsten = aanvraag.validatieLeeruitkomsten,
                    Beschrijving = aanvraag.beschrijving,
                    startdatum = aanvraag.startDatum,
                    einddatum = aanvraag.eindDatum,
                    beschikbare_uren = aanvraag.beschikbareUren
                });
        }
    }
}