namespace StudentsDataManager;
using StudentsDataManager.FileManager;
using StudentsDataManager.StudentManager;

public class MainClass
{
    private const string StudentsFilePath = "../../Files/JsonData/students.json";
    private const string GradesFilesPath = "../../Files/JsonData/scores.json";
    public static void Main(string[] args)
    {
        // Read students and scores from json file
        FileReader fileReader = new FileReader();
        JsonDataSerializer jsonDataSerializer = new JsonDataSerializer();
        var studentsJson = fileReader.ReadFile(StudentsFilePath);
        var students = jsonDataSerializer.ReadStudentsFromJson(studentsJson);
        var gradesJson = fileReader.ReadFile(GradesFilesPath);
        var scores = jsonDataSerializer.ReadGradesFromJson(gradesJson);

        // Create student data handler, and get top 3 students
        StudentDataHandler studentDataHandler = new StudentDataHandler(students, scores);
        var topStudents = studentDataHandler.GetTopStudents(3);
        foreach (var student in topStudents)
        {
            Console.WriteLine(student);
        }
    }
}