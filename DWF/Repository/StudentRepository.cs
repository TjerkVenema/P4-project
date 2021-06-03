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
    }
}