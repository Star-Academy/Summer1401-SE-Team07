namespace StudentsDataManager.StudentManager;
using StudentsDataManager.Models;

public class StudentDataHandler
{
    public List<Student> Students { get; private set; }
    public List<Lesson> Lessons { get; private set; }
    public StudentDataHandler(List<Student> students, List<Grade> grades)
    {
        this.Students = students;
        this.Lessons = GenerateLessonList(grades);
        foreach (var grade in grades)
        {
            AddGradeToStudent(grade);
        }
    }

    private List<Lesson> GenerateLessonList(List<Grade> grades)
    {
        var lessons = new List<Lesson>();
        foreach (var grade in grades)
        {
            if (!lessons.Any(x => x.Name == grade.Lesson))
            {
                lessons.Add(new Lesson(grade.Lesson));
            }
        }
        return lessons;
    }

    private void AddGradeToStudent(Grade grade)
    {
        var student = this.Students.FirstOrDefault(x => x.StudentNumber == grade.StudentNumber);
        if (student is not null)
        {
            var lesson = this.Lessons.FirstOrDefault(x => x.Name == grade.Lesson);
            if (lesson is not null)
            {
                student.Lessons.Add(lesson.GetMarkedLesson(grade.Score));
            }
        }
    }

    public List<Student> GetTopStudents(int count)
    {
        return this.Students.OrderByDescending(x => x.AverageMark).Take(count).ToList();
    }
}