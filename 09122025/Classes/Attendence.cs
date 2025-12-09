namespace _09122025.Classes
{
    public class Attendence
    {
        public string Id { get; set; }
        public bool Attended { get; set; } = false;
        public DateTime AppeardTime { get; set; }
        public string SkipReason { get; set; }
        public string SkipComment { get; set; }
        public byte[] SkipDocument { get; set; }

    }
}
