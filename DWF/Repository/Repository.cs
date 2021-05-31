using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace DWF.Repository
{
    public class Repository
    {
        public IDbConnection Connect()
        {
            return new MySqlConnection(
                "Server=127.0.0.1;Port=3306;" +
                ";Database=portaaldwf;" +
                "Uid=root;Pwd=Test12345;"
            );
        }
        public string GetNaam(int Id)
        {
            using var connectie = Connect();
            var voornaam = connectie.QuerySingleOrDefault<string>(
                "SELECT voornaam FROM gebruikers WHERE gebruiker_id = @gebruiker_id",
                new
                {
                    gebruiker_id = Id
                });

            var achternaam = connectie.QuerySingleOrDefault<string>(
                "SELECT achternaam FROM gebruikers WHERE gebruiker_id = @gebruiker_id",
                new
                {
                    gebruiker_id = Id
                });

            var naam = voornaam + " " + achternaam;
            return naam;
        }
    }
}