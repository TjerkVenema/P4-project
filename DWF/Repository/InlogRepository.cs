using Dapper;
using DWF.Models;

namespace DWF.Repository
{
    public class InlogRepository
    {
        public static Repository repository = new();

        public static bool Login(string email, string wachtwoord)
        {
            using var connectie = repository.Connect();

            var gebruiker = connectie.QuerySingleOrDefault<Gebruiker>(
                "SELECT * FROM gebruikers WHERE email = @Email AND wachtwoord = @Wachtwoord",
                new
                {
                    Email = email,
                    Wachtwoord = wachtwoord
                });
            if (gebruiker == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}