namespace StudentsDataManager;
using StudentsDataManager.FileManager;
using StudentsDataManager.StudentManager;

public class MainClass
{
    private static string SudentsFilePath = "../../Files/JsonData/students.json";
    private static string GradesFilesPath = "../../Files/JsonData/scores.json";
    public static void Main(string[] args)
    {
        // Read students and scores from json file
        FileReader fileReader = new FileReader();
        string studentsJson = fileReader.ReadFile(SudentsFilePath);
        var students = fileReader.ReadStudentsFromJson(studentsJson);
        string gradesJson = fileReader.ReadFile(GradesFilesPath);
        var scores = fileReader.ReadGradesFromJson(gradesJson);

        // Create student data handler, and get top 3 students
        StudentDataHandler studentDataHandler = new StudentDataHandler(students, scores);
        var topStudents = studentDataHandler.GetTopStudents(3);
        foreach (var student in topStudents)
        {
            Console.WriteLine(student);
        }
    }
}