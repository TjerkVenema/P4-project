using System.Collections.Generic;
using Dapper;
using DWF.Models;

namespace DWF.Repository
{
    public class ZoekRepository
    {
        public static Repository repository = new();
        
        public static List<Opdracht> opdrachten()
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
        
        public static List<Opdracht> opdrachtenMetFilters(string type)
        {
            using var connectie = repository.Connect();
            var opdrachtlijst = connectie.Query<Opdracht>(
                "SELECT * FROM opdrachten WHERE opdracht_status = @opdracht_status AND type = @type",
                new
                {
                    type = type,
                    opdracht_status = "beschikbaar"
                });
            return opdrachtlijst as List<Opdracht>;
        }
    }
}