using System.Collections.Generic;
using Dapper;
using DWF.Models;

namespace DWF.Repository
{
    public class ZoekRepository
    {
        public static Repository repository = new();
        
        public static List<Opdracht> Opdrachten()
        {
            using var connectie = repository.Connect();
            var opdrachtlijst = connectie.Query<Opdracht>(
                "SELECT * FROM opdrachten WHERE opdracht_status = @opdracht_status",
                new
                {
                    opdracht_status = "beschikbaar"
                });
            return opdrachtlijst as List<Opdracht>;
        }
        
        public static List<Opdracht> OpdrachtenMetFilters(string type, string sector, string opleidingsNiveau, string opleidingsjaar)
        {
            using var connectie = repository.Connect();
            var opdrachtlijst = connectie.Query<Opdracht>(
                "SELECT * FROM opdrachten WHERE opdracht_status = @opdracht_status AND type = @type AND sector = @sector AND gewenste_opleiding = @opleidingsNiveau AND opleidingsjaar = @opleidingsjaar",
                new
                {
                    @opleidingsjaar = opleidingsjaar,
                    @opleidingsNiveau = opleidingsNiveau,
                    @sector = sector,
                    @type = type,
                    opdracht_status = "beschikbaar"
                });
            return opdrachtlijst as List<Opdracht>;
        }
    }
}