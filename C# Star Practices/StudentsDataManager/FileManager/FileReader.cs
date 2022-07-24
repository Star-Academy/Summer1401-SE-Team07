namespace StudentsDataManager.FileManager;

using StudentsDataManager.Objects;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class FileReader
{
    public string ReadFile(string filePath)
    {
        string fileContent = string.Empty;
        using (StreamReader reader = new StreamReader(filePath))
        {
            fileContent = reader.ReadToEnd();
        }

        return fileContent;
    }

    public List<Student> ReadStudentsFromJson(string json)
    {
        var students = JsonSerializer.Deserialize<List<Student>>(json);
        if (students is not null)
            return students;
        return new List<Student>();
    }

    public List<Grade> ReadGradesFromJson(string json)
    {
        var grades = JsonSerializer.Deserialize<List<Grade>>(json);
        if (grades is not null)
            return grades;
        return new List<Grade>();
    }
}
