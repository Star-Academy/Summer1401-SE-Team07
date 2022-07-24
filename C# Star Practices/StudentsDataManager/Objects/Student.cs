namespace StudentsDataManager.Objects;

using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int StudentNumber { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Lesson> Lessons { get; set; }
    public double AverageMark { get; set; }

    public Student(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Lessons = new List<Lesson>();
    }
    
    public override string ToString()
    {
        return $"{this.StudentNumber}: {this.FirstName} {this.LastName} {this.AverageMark}";
    }
}
