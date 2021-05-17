using System;
using Dapper;

namespace DWF.Repository
{
    public class RegistratieRepository
    {
        public static Repository repository = new Repository();

        public int CreateAccount(string email, string wachtwoord, string voornaam, string achternaam)
        {
            using var connectie = repository.Connect();
            var numRowEffected = connectie.Execute(
                "INSERT INTO gebruikers (email, wachtwoord, voornaam, achternaam) VALUES (@Email, @Wachtwoord, @Voornaam, @Achternaam)",
                param: new {Email = email, Wachtwoord = wachtwoord, Voornaam = voornaam, Achternaam = achternaam});
            var gebruikerId = connectie.QuerySingle("SELECT LAST_INSERT_ID();");
            
            int numeric_id = 0;
            foreach (var pair in gebruikerId)
            {
                numeric_id = (int)pair.Value;
            }
            return numeric_id;
        }
    }
}