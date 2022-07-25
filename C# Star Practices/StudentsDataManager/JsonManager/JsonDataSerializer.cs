namespace StudentsDataManager.FileManager;

using StudentsDataManager.Models;
using System.Text.Json;


public class JsonDataSerializer
{
    public List<Student> ReadStudentsFromJson(string json)
    {
        // use ?? to set default value for nullable type
        return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
    }

    public List<Grade> ReadGradesFromJson(string json)
    {
        return JsonSerializer.Deserialize<List<Grade>>(json) ?? new List<Grade>();
    }
}
