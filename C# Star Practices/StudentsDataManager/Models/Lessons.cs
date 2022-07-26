namespace StudentsDataManager.Models;

public record Lesson(string Name)
{
    public double Score { get; set; }
    public Lesson GetMarkedLesson(double score) => new Lesson(Name) { Score = score };
}
