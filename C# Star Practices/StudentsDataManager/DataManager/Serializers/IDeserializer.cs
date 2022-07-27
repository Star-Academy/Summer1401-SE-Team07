namespace StudentsDataManager.DataManager.Serializers;


public interface IDeserializer
{
     public List<T> DeserializeObject<T>(string text);
}