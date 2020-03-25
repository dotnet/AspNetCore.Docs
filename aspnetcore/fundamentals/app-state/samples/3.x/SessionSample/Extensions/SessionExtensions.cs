using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Web.Extensions
{
    #region snippet1
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
    #endregion      
}

namespace Web.Extensions2
{
    // Alternate approach

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static bool TryGet<T>(this ISession session, string key, out T value)
        {
            var state = session.GetString(key);
            value = default;
            if (state == null)
                return false;
            value = JsonSerializer.Deserialize<T>(state);
            return true;
        }
    }
}