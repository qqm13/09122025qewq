namespace _09122025.Classes
{
    public class User
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Info { get; set; }
        public string FIO { get; set; }
        public List<Schedule> Schedule { get; set; } = new List<Schedule>();
    }
}
