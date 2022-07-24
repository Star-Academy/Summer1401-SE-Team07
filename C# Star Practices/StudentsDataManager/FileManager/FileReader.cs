namespace StudentsDataManager.FileManager;

using StudentsDataManager.Objects;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
        List<Student> students = JsonSerializer.Deserialize<List<Student>>(json);
        return students;
    }

    public List<Grade> ReadGradesFromJson(string json)
    {
        List<Grade> grades = JsonSerializer.Deserialize<List<Grade>>(json);
        return grades;
    }
}
