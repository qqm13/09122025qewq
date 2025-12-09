namespace _09122025.Classes
{
    public class Schedule
    {
        public DateOnly Date { get; set; } 
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
