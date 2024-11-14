using System.Text.Json;
using Microsoft.AspNetCore.Http;

/// <summary>
///extension for session (ISession interface)
/// </summary>
public static class SessionExtension
{

    //for double type
    public static double? GetDouble(this ISession session, string key)
    {
        var data = session.Get(key);
        if (data == null)
        {
            return null;
        }
        return BitConverter.ToDouble(data, 0);
    }

    public static void SetDouble(this ISession session, string key, double value)
    {
        session.Set(key, BitConverter.GetBytes(value));
    }


    //for objects such as List, arrays etc.
    public static T GetObject<T>(this ISession session, string key)
    {
        var data = session.GetString(key);
        if (data == null)
        {
            return default(T);
        }
        return JsonSerializer.Deserialize<T>(data);
    }

    public static void SetObject(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }
}
