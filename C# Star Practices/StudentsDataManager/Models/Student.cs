namespace StudentsDataManager.Models;

using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int StudentNumber { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public List<Lesson> Lessons { get; set; }
    public double AverageMark
    {
        get
        {
            if (this.Lessons.Any())
            {
                return this.Lessons.Average(x => x.Score);
            }
            return 0;
        }
    }

    public Student(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Lessons = new List<Lesson>();
    }

    public override string ToString()
    {
        return $"[{StudentNumber}] {FirstName} {LastName} {AverageMark}";
    }
}
