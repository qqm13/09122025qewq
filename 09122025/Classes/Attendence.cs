namespace _09122025.Classes
{
    public class Attendence
    {
        public string Id { get; set; }
        public bool Attended { get; set; } = false;
        public DateTime AppeardTime { get; set; }
        public string Reason { get; set; }
        public string Comment { get; set; }
        public byte[] Document { get; set; }

    }
}
