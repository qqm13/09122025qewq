namespace _09122025.Classes
{
    public class DBBD
    {
        public List<User> Users { get; set; } = new List<User>();


        public List<User> GetUsers()
        {
            return Users;
        }

       public DBBD()
        {
            Attendence attendence = new Attendence
            {
                Id = "ATTmayW01D05L02",
                AppeardTime = new DateTime(2025, 5, 5),
                Attended = false,
            };
            Lesson lesson = new Lesson
            {
                Id = "mayW01D05L02",
                Attendence = attendence,
                Number = 1,
                Title = "para"
            };
            Schedule schedule = new Schedule
            {
                Id = "ATTmayW01D05L",
                Date = new DateTime(2025,5,5),
                Lessons = new List<Lesson> { lesson },
            };
            User user = new User
            {
                FIO = "IMYA OTCH FAM",
                Id = "ppkstudent1",
                Info = "group1125",
                Login = "qwerty",
                Password = "hash1",
                Schedule = new List<Schedule> { schedule },
            };

            Users.Add(user);
        }
    }
}
