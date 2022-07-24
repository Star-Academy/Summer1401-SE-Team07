namespace StudentsDataManager.Objects;

public class Grade
{
    public int StudentNumber { get; set; }
    public string Lesson { get; set; }
    public double Score { get; set; }

    public Grade(int studentNumber, string lesson, double score)
    {
        this.StudentNumber = studentNumber;
        this.Lesson = lesson;
        this.Score = score;
    }

    public override string ToString()
    {
        return $"{this.StudentNumber}: {this.Lesson} {this.Score}";
    }
}