namespace StudentsDataManager.Models;

public class Lesson
{
    public string Name { get; init; }
    public double Score { get; set; }
    
    public Lesson(string name)
    {
        this.Name = name;
    }

    public Lesson GetMarkedLesson(double score){
        return new Lesson(this.Name)
        {
            Score = score
        };
    }
}