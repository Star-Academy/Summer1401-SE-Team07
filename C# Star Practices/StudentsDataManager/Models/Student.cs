namespace StudentsDataManager.Models;

using System.Linq;

public record Student(int StudentNumber, string FirstName, string LastName)
{
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();

    public sealed override string ToString() => $"[{StudentNumber}] {FirstName} {LastName} {AverageMark}";
    public string AverageMark => Lessons.Any() ? $"{Lessons.Average(l => l.Score):0.000}" : "0";
}