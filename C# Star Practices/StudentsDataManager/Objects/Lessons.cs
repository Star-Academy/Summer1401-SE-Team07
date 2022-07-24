namespace StudentsDataManager.Objects;

public class Lesson
{
    public string Name { get; init; }
    public int Score { get; set; }
    
    public Lesson(string name)
    {
        this.Name = name;
    }

    public Lesson GetMarkedLesson(int score){
        return new Lesson(this.Name)
        {
            Score = score
        };
    }
}