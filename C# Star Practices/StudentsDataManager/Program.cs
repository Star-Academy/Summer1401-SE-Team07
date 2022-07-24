namespace StudentsDataManager;
using StudentsDataManager.FileManager;

public class MainClass
{
    private static string SudentsFilePath = "../../Files/JsonData/students.json";
    private static string GradesFilesPath = "../../Files/JsonData/scores.json";
    public static void Main(string[] args)
    {
        FileReader fileReader = new FileReader();
        string studentsJson = fileReader.ReadFile(SudentsFilePath);
        var students = fileReader.ReadStudentsFromJson(studentsJson);
        string gradesJson = fileReader.ReadFile(GradesFilesPath);
        var scores = fileReader.ReadGradesFromJson(gradesJson);

        Console.WriteLine(string.Join(Environment.NewLine, students));
        Console.WriteLine(string.Join(Environment.NewLine, scores));
    }
}