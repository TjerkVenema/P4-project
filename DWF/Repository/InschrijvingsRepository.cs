using Dapper;

namespace DWF.Repository
{
    public class InschrijvingsRepository
    {
        public static Repository repository = new Repository();

        public void gebruikerKoppelen(int id, int opdracht)
        {
            using var connectie = repository.Connect();
            var nieuweKoppeling = connectie.Execute(
                "INSERT INTO  toegekende_gebruikers (gebruiker_id, opdracht_id) VALUES (@Gebruiker_id, @Opdracht_id)",
                param: new {@Gebruiker_id = id, @Opdracht_id = opdracht});
        }

        public int gebruikerOpdrachten(int id)
        {
            using var connectie = repository.Connect();
            var opdrachtenCheck =
                connectie.Execute("SELECT * FROM toegekende_gebruikers WHERE gebruiker_id = @Gebruiker_id",
                    param: new {@Gebruiker_id = id});

            return opdrachtenCheck;
        }
    }
}