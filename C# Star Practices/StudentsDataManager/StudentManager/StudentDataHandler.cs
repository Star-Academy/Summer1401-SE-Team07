namespace StudentsDataManager.StudentManager;
using StudentsDataManager.Models;

public class StudentDataHandler
{
    public Dictionary<int, Student> Students { get; private set; }
    public List<Lesson> Lessons { get; private set; }
    public StudentDataHandler(List<Student> students, List<Grade> grades)
    {
        this.Lessons = GenerateLessonList(grades);
        this.Students = new Dictionary<int, Student>();
        foreach (var student in students)
        {
            AddStudent(student);
        }
        foreach (var grade in grades)
        {
            AddGradeToStudent(grade);
        }
    }

    private Student GetStudentById(int id)
    {
        return this.Students[id];
    }

    private List<Lesson> GenerateLessonList(List<Grade> grades)
    {
        var lessons = new List<Lesson>();
        return grades.Select(g => new Lesson(g.Lesson)).Distinct().ToList();
    }

    public void AddGradeToStudent(Grade grade)
    {
        var student = GetStudentById(grade.StudentNumber);
        if (student is not null)
        {
            var lesson = this.Lessons.FirstOrDefault(x => x.Name == grade.Lesson);
            if (lesson is not null)
            {
                student.Lessons.Add(lesson.GetMarkedLesson(grade.Score));
            }
        }
    }

    public void AddStudent(Student student)
    {
        this.Students.Add(student.StudentNumber, student);
    }

    public List<Student> GetTopStudents(int count)
    {
        return this.Students.Values.OrderByDescending(x => x.AverageMark).Take(count).ToList();
    }
}