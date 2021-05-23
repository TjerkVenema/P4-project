using System.Collections.Generic;
using Dapper;
using DWF.Models;

namespace DWF.Repository
{
    public class TriageRepository
    {
        public static Repository repository = new();

        public static List<Opdracht> Get()
        {
            using var connectie = repository.Connect();
            var opdrachtlijst = connectie.Query<Opdracht>(
                "SELECT * FROM opdrachten WHERE opdracht_status = @opdracht_status",
                new
                {
                    opdracht_status = 1
                });
            return opdrachtlijst as List<Opdracht>;
        }

        public static Opdracht GetById(int opdrachtId)
        {
            using var connectie = repository.Connect();
            var opdracht = connectie.QuerySingleOrDefault<Opdracht>(
                "SELECT * FROM opdrachten WHERE opdracht_id = @opdracht_id",
                new
                {
                    opdracht_id = opdrachtId
                });
            return opdracht;
        }

        public static List<string> GetStudents(int opdrachtId)
        {
            using var connectie = repository.Connect();
            var studentenId = connectie.Query<int>(
                "SELECT gebruiker_id FROM doet WHERE opdracht_id = @opdracht_Id",
                new
                {
                    opdracht_Id = opdrachtId
                });

            var studenten = new List<string>();

            foreach (var a in studentenId)
            {
                studenten.Add(GetNaam(a));
            }

            return studenten;
        }

        public static List<Aanvragen_student> GetAanvragen()
        {
            using var connectie = repository.Connect();
            var aanvragen = connectie.Query<Aanvragen_student>(
                "SELECT * FROM aanvragen_student");

            foreach (var a in aanvragen)
            {
                a.opdracht_naam = connectie.QuerySingleOrDefault<string>(
                    "SELECT opdracht_naam FROM opdrachten WHERE opdracht_Id = @opdrachtId",
                    new
                    {
                        opdrachtId = a.opdracht_id
                    });
                
                a.student_naam = GetNaam(a.gebruiker_id);
            }

            return aanvragen as List<Aanvragen_student>;
        }

        public static List<Opdracht> GetOpdrachtenBeoordeling()
        {
            using var connectie = repository.Connect();
            var opdrachten = connectie.Query<Opdracht>(
                "SELECT * FROM opdrachten WHERE opdracht_status = @opdracht_status",
                new
                {
                    opdracht_status = 4
                });

            return opdrachten as List<Opdracht>;
        }

        public static string GetNaam(int Id)
        {
            using var connectie = repository.Connect();
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