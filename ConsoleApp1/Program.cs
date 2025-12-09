using _09122025.Classes;
using _09122025.Controllers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class Program
    {
        public static AuthControllerClass AuthController { get; set; }
        public static ReportControllerClass ReportController { get; set; }
        public  static AttendenceControllerClass AttendenceController { get; set; }

        public static DBBD db { get; set; }
        static void Main()
        {
            Setup();

            //string userName = "qwerty";
            //string password = "hash1";

            //string result = AuthController.Login(userName, password);

            //string expected = "group1125";

            //string user_id = "ppkstudent1";
            //DateTime date = new DateTime(2025, 5, 5);

            ////Console.Write(expected);
            ////Console.WriteLine(result);

            //var schedule = Schedule(user_id, date);

            //Console.WriteLine(schedule);

            string user_id = "ppkstudent1";
            DateTime date = new DateTime(2025, 5, 5);
            var r = ReportController.GetReport(user_id,date);
            string expectedReport = "всего пропущено по не уважительной причине - 0IMYA OTCH FAM\nпропущеное занятие по не уважительной причине - 05.05.2025 0:00:00, 1. para\nвсего пропущено по не уважительной причине - 1\nвсего пропущено по уважительной причине - 0";

            Console.WriteLine(expectedReport);
            Console.WriteLine("\n");
            Console.WriteLine(r);



        }

        public static void Setup()
        {
            db = new DBBD();

            AuthController = new AuthControllerClass(db);
            ReportController = new ReportControllerClass(db);
            AttendenceController = new AttendenceControllerClass(db);
        }
        public static string Schedule(string user_id, DateTime date)
        {
            List<User> users = db.GetUsers();

            string answer = "";

            foreach (var user in users)
            {
                if (user_id == user.Id)
                {
                    foreach (Schedule schedule in user.Schedule)
                    {
                        if (schedule.Date == date)
                        {
                            foreach (Lesson lesson in schedule.Lessons)
                            {
                                answer += lesson.Number;
                                answer += ". ";
                                answer += lesson.Title;
                                answer += "\n";
                            }
                        }
                    }
                }
            }
            return answer;
        }

    }
}
