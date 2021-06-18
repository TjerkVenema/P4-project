using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebMatrix.Data;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;
using Dapper;
using DWF.Models;

namespace DWF.Repository
{
    public class StudentRepository
    {
        public static Repository repository = new Repository();

        public static Gebruiker GetStudent(int Id)
        {
            using var connectie = repository.Connect();
            var gebruiker = connectie.QuerySingleOrDefault<Gebruiker>(
                "SELECT * FROM gebruikers WHERE gebruiker_id = @gebruiker_id",
                new
                {
                    gebruiker_id = Id
                });

            gebruiker.naam = repository.GetNaam(Id);

            return gebruiker;
        }

        public static void UpdateStudent(Gebruiker gebruiker)
        {
            using var connectie = repository.Connect();
            connectie.Execute(
                "UPDATE gebruikers SET wachtwoord = @Wachtwoord, opleiding = @Opleiding, opleidingsniveau = @opleidingsniveau, studiejaar = @Studiejaar WHERE gebruiker_id = @gebruikerId",
                new
                {
                    gebruikerId = gebruiker.gebruiker_id,
                    Wachtwoord = gebruiker.wachtwoord,
                    Opleiding = gebruiker.opleiding,
                    opleidingsniveau = gebruiker.opleidingsNiveau,
                    Studiejaar = gebruiker.studiejaar
                });
        }

        public static void AddFilters(int id, string Opleiding, int jaar)
        {
            using var connectie = repository.Connect();
            connectie.Execute(
                "UPDATE gebruikers SET opleiding = @opleiding, studiejaar = @studiejaar WHERE gebruiker_id = @gebruikers_id",
                new
                {
                    opleiding = Opleiding,
                    studiejaar = jaar,
                    gebruikers_id = id
                });
        }

        public static void AddAanvraag(Aanvragen_student aanvraag)
        {
            using var connectie = repository.Connect();
            connectie.Execute(
                @"INSERT INTO aanvragen_student(gebruiker_id, opdracht_id, validatie_leeruitkomsten, beschrijving, startdatum, einddatum, beschikbare_uren)
                     VALUES (@gebruikerId, @opdrachtId, @validatieLeeruitkomsten, @Beschrijving, @startdatum, @einddatum, @beschikbareUren)",
                new
                {
                    gebruikerId = aanvraag.gebruiker_id,
                    opdrachtId = aanvraag.opdracht_id,
                    validatieLeeruitkomsten = aanvraag.validatie_leeruitkomsten,
                    Beschrijving = aanvraag.beschrijving,
                    startdatum = aanvraag.startDatum,
                    einddatum = aanvraag.eindDatum,
                    beschikbareUren = aanvraag.beschikbare_uren
                });
        }

        public static List<Opdracht> GetOpdrachten(int gebruikerid)
        {
            using var connectie = repository.Connect();
            var opdrachtId = connectie.Query<int>(
                "SELECT opdracht_id FROM doet WHERE gebruiker_id = @gebruiker_id", 
                new
                {
                    gebruiker_id = gebruikerid
                });

            List<Opdracht> opdrachten = new List<Opdracht>();
            
            foreach (var id in opdrachtId)
            {
                var opdracht = connectie.QuerySingleOrDefault<Opdracht>(
                    "SELECT * FROM opdrachten WHERE opdracht_id = @opdracht_id",
                    new
                    {
                        opdracht_id = id
                    });
                opdrachten.Add(opdracht);
            }
            return opdrachten;
        }

        public static List<Meldingen> getMeldingen(int gebruikerid)
        {
            using var connectie = repository.Connect();

            var meldingen = connectie.Query<Meldingen>("SELECT * FROM meldingen WHERE gebruiker_id = @gebruiker",
                param: new {gebruiker = gebruikerid});

            return meldingen.AsList();
        }
        
        public static bool getMelding(int opdracht)
        {
            using var connectie = repository.Connect();

            var meldingen = connectie.QuerySingle<string>("SELECT keuring FROM meldingen WHERE opdracht_id = @opdracht",
                param: new {opdracht = opdracht});

            if (meldingen == "goedgekeurd")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}