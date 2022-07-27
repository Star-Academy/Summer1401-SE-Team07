namespace StudentsDataManager.DataManager.Serializers;

using System.Text.Json;

public class JsonDataSerializer : IDeserializer
{
    public List<T> DeserializeObject<T>(string json)
    {
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }
}
