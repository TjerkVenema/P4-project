using System.ComponentModel.DataAnnotations.Schema;
using WebMatrix.Data;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;
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
                "UPDATE gebruikers SET email = @Email, voornaam = @Voornaam, achternaam = @Achternaam, wachtwoord = @Wachtwoord, opleiding = @Opleiding WHERE gebruiker_id = @gebruikerId",
                new
                {
                    gebruikerId = gebruiker.gebruiker_id,
                    Email = gebruiker.email,
                    Voornaam = gebruiker.voornaam,
                    Achternaam = gebruiker.achternaam,
                    Wachtwoord = gebruiker.wachtwoord,
                    Opleiding = gebruiker.opleiding
                });
        }
    }

    {
    public static void studentopdrachten()

    {
        var db = Database.Open("portaaldwf");

        var selectQueryString = "SELECT * FROM Opdrachten ORDER BY ID",
    }
    }
}
