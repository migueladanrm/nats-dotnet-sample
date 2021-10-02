using System.Text.Json;

namespace api.Extensions {
  public static class JsonSerializationExtensions {
    private static JsonSerializerOptions defaultSerializerSettings = new JsonSerializerOptions {
      DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static T Deserialize<T>(this string json) {
      return JsonSerializer.Deserialize<T>(json, defaultSerializerSettings);
    }

    public static T DeserializeCustom<T>(this string json, JsonSerializerOptions settings) {
      return JsonSerializer.Deserialize<T>(json, settings);
    }

    public static string Serialize<T>(this T obj) {
      return JsonSerializer.Serialize(obj, typeof(T), defaultSerializerSettings);
    }
  }
}