using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SurfsUp.Models;

public static class SessionExtensions
{
    public static void SetObject(this ISession session, string key, object value)
    {
        var jsonString = JsonConvert.SerializeObject(value);
        Console.WriteLine(jsonString);
        session.SetString(key, jsonString);
    }

    public static T GetObject<T>(this ISession session, string key)
    {
        var jsonString = session.GetString(key);
        if (string.IsNullOrEmpty(jsonString))
        {
            return default;
        }

        try
        {
            JObject obj = JObject.Parse(jsonString);
            return obj.ToObject<T>();
            //return JsonConvert.DeserializeObject<dynamic>(jsonString);
        }
        catch (JsonException)
        {
            // Log the exception and return default value
            return default;
        }
    }


    // Method to get the cart count
    public static int GetCartCount(this ISession session)
    {
        var cart = session.GetObject<DetailModel>("Cart");
        int ec = cart?.Equipment?.Count ?? 0;
        int sc = cart?.Suits?.Count ?? 0;
        int ac = cart?.Addons?.Count ?? 0;
        return ec + sc + ac;
    }
}