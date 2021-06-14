using System;
using Dapper;

namespace DWF.Repository
{
    public class RegistratieRepository
    {
        public static Repository repository = new Repository();

        public int CreateAccount(string email, string wachtwoord, string voornaam, string achternaam, string opleidingsNiveau, int? zakelijkNummer, string bedrijfsnaam, string school, string rol)
        {
            using var connectie = repository.Connect();
            var numRowEffected = connectie.Execute(
                "INSERT INTO gebruikers (email, wachtwoord, voornaam, achternaam, opleidingsniveau, zakelijknummer, bedrijfsnaam, school, rol) VALUES (@Email, @Wachtwoord, @Voornaam, @Achternaam, @OpleidingsNiveau, @ZakelijkNummer, @Bedrijfsnaam, @School, @Rol)",
                param: new {Email = email, Wachtwoord = wachtwoord, Voornaam = voornaam, Achternaam = achternaam, OpleidingsNiveau = opleidingsNiveau , ZakelijkNummer = zakelijkNummer, Bedrijfsnaam = bedrijfsnaam, School = school, Rol = rol });
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