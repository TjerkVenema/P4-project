using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DWF.Helpers
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        
        //om een sessie aan te maken:
        //HttpContext.Session.SetObjectAsJson("De naam van de sessie", De value die in de sessie moet komen);
        
        //om vervolgens de sessie op te vragen doe:
        //var naam = HttpContext.Session.GetObjectFromJson<Het type variabele dat in de sessie zit bv. Int>("De naam van de sessie");
    }
}