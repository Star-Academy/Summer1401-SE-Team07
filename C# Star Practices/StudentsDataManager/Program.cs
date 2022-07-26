namespace StudentsDataManager;
using StudentsDataManager.DataManager.Serializers;
using StudentsDataManager.DataManager.Providers;
using StudentsDataManager.StudentManager;
using StudentsDataManager.Models;

public class MainClass
{
    private const string StudentsFilePath = "../../Files/JsonData/students.json";
    private const string GradesFilesPath = "../../Files/JsonData/scores.json";

    private static StudentDataHandler studentDataHandlerInit(string studentsDataPath, string gradesDataPath)
    {
        var fileReader = new FileReader();
        var jsonDataSerializer = new JsonDataSerializer();
        var studentsJson = fileReader.ReadData(studentsDataPath);
        var gradesJson = fileReader.ReadData(gradesDataPath);
        var students = jsonDataSerializer.DeserializeObject<Student>(studentsJson);
        var scores = jsonDataSerializer.DeserializeObject<Grade>(gradesJson);

        return new StudentDataHandler(students, scores);
    }

    public static void Main(string[] args)
    {
        var studentDataHandler = studentDataHandlerInit(StudentsFilePath, GradesFilesPath);
        var topStudents = studentDataHandler.GetTopStudents(3);
        foreach (var student in topStudents)
        {
            Console.WriteLine(student);
        }
    }
}