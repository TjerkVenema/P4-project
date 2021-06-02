using System;
using Dapper;

namespace DWF.Repository
{
    public class RegistratieRepository
    {
        public static Repository repository = new Repository();

        public int CreateAccount(string email, string wachtwoord, string voornaam, string achternaam, string opleiding, int? zakelijkNummer, string bedrijfsnaam, string school)
        {
            using var connectie = repository.Connect();
            var numRowEffected = connectie.Execute(
                "INSERT INTO gebruikers (email, wachtwoord, voornaam, achternaam, opleiding, zakelijknummer, bedrijfsnaam, school) VALUES (@Email, @Wachtwoord, @Voornaam, @Achternaam, @Opleiding, @ZakelijkNummer, @Bedrijfsnaam, @School)",
                param: new {Email = email, Wachtwoord = wachtwoord, Voornaam = voornaam, Achternaam = achternaam, Opleiding = opleiding , ZakelijkNummer = zakelijkNummer, Bedrijfsnaam = bedrijfsnaam, School = school });
            var gebruikerId = connectie.QuerySingle("SELECT LAST_INSERT_ID();");
            
            int numeric_id = 0;
            foreach (var pair in gebruikerId)
            {
                numeric_id = (int)pair.Value;
            }
            return numeric_id;
        }
        
        public static bool Isdubbel(string email){
            using var db = repository.Connect();
            int count =
                db.QuerySingle<int>("SELECT count(1) FROM gebruikers WHERE email = @email", param: new { @email = email});
            return count > 0;
        }
    }
}