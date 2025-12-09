namespace _09122025.Classes
{
    public class Schedule
    {
        public string Id { get; set; }
        public DateTime Date { get; set; } 
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();

        
    }
}
