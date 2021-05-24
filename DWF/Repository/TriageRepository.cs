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

        public static Gebruiker GetGebruiker(int Id)
        {
            using var connectie = repository.Connect();
            var gebruiker = connectie.QuerySingleOrDefault<Gebruiker>(
                "SELECT * FROM gebruikers WHERE gebruiker_id = @gebruiker_id",
                new
                {
                    gebruiker_id = Id
                });
            gebruiker.naam = GetNaam(gebruiker.gebruiker_id);
            return gebruiker;
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

        public static Aanvragen_student GetAanvraagById(int Id)
        {
            using var connectie = repository.Connect();
            var aanvraag = connectie.QuerySingleOrDefault<Aanvragen_student>(
                "SELECT * FROM aanvragen_student WHERE aanvraag_id = @aanvraag_id",
                new
                {
                    aanvraag_id = Id
                });
            
            aanvraag.opdracht_naam = connectie.QuerySingleOrDefault<string>(
                "SELECT opdracht_naam FROM opdrachten WHERE opdracht_Id = @opdrachtId",
                new
                {
                    opdrachtId = aanvraag.opdracht_id
                });
                
            aanvraag.student_naam = GetNaam(aanvraag.gebruiker_id);
            return aanvraag;
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

        public static void StudentAanvraagAfgekeurd(int Id)
        {
            using var connectie = repository.Connect();
            connectie.Execute(
                "DELETE FROM aanvragen_student WHERE aanvraag_id = @aanvraag_id",
                new
                {
                    aanvraag_id = Id
                });
        }

        public static void StudentAanvraagGoedgekeurd(int Id)
        {
            using var connectie = repository.Connect();

            Aanvragen_student aanvragenStudent = GetAanvraagById(Id);
            
            connectie.Execute(
                "INSERT INTO doet(gebruiker_id, opdracht_id) VALUES (@gebruikerId, @opdrachtId)",
                new
                {
                    gebruikerId = aanvragenStudent.gebruiker_id,
                    opdrachtId = aanvragenStudent.opdracht_id
                });

            connectie.Execute(
                "UPDATE opdrachten SET opdracht_status = @opdracht_status WHERE opdracht_id = @opdrachtId",
                new
                {
                    opdracht_status = 1,
                    opdrachtId = aanvragenStudent.opdracht_id
                });
            
            connectie.Execute(
                "DELETE FROM aanvragen_student WHERE aanvraag_id = @aanvraag_id",
                new
                {
                    aanvraag_id = Id
                });
        }

        public static void OpdrachtAanvraagGoedgekeurd(int Id)
        {
            using var connectie = repository.Connect();
            connectie.Execute(
                "UPDATE opdrachten SET opdracht_status = @opdracht_status WHERE opdracht_id = @opdracht_id ",
                new
                {
                    opdracht_status = 2,
                    opdracht_id = Id
                });
        }

        public static void OpdrachtAanvraagAfgekeurd(int Id)
        {
            using var connectie = repository.Connect();
            connectie.Execute(
                "DELETE FROM opdrachten WHERE opdracht_id = @opdracht_id",
                new
                {
                    opdracht_id = Id
                });
        }
        
        public static Gebruiker GetStudentAanvraag(int id)
        {
            using var connectie = repository.Connect();

            var gebruiker_id = connectie.QuerySingleOrDefault<int>(
                "SELECT gebruiker_id FROM aanvragen_student WHERE aanvraag_id = @aanvraag_id",
                new
                {
                    aanvraag_id = id
                });
            
            var student = connectie.QuerySingleOrDefault<Gebruiker>(
                "SELECT * FROM gebruikers WHERE gebruiker_id = @gebruikerId",
                new
                {
                    gebruikerId = gebruiker_id
                });
            student.naam = GetNaam(student.gebruiker_id);
            return student;
        }

        public static Opdracht GetOpdrachtAanvraag(int Id)
        {
            using var connectie = repository.Connect();
            var opdracht = connectie.QuerySingleOrDefault<Opdracht>(
                "SELECT * FROM opdrachten WHERE opdracht_id = @opdracht_id",
                new
                {
                    opdracht_id = Id
                });
            return opdracht;
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