using _09122025.Classes;
using _09122025.Controllers;
using NUnit.Framework.Internal;
using System.Runtime.Intrinsics.X86;

namespace TestProject1
{
    public class Tests
    {
        public AuthControllerClass AuthController { get; set; }
        public ReportControllerClass ReportController { get; set; }
        public AttendenceControllerClass AttendenceController { get; set; }
        public static DBBD db { get; set; }
        [SetUp]
        public void Setup()
        {
            db = new DBBD();
            AuthController = new AuthControllerClass(db);
            ReportController = new ReportControllerClass(db);
            AttendenceController = new AttendenceControllerClass(db);
        }

        [Test]
        public void Test1Auth()
        {
            string userName = "qwerty";
            string password = "hash1";

            string result = AuthController.Login(userName, password);

            string expected = "group1125";
            Assert.That(expected.Equals(result));
        }

        [Test]
        public void Test2GetSchedule()
        {
            string user_id = "ppkstudent1";
            DateTime date = new DateTime(2025, 5, 5);

            string resultSchedule = AuthController.Schedule(user_id, date);

            string expected = "1. para\n";
            Assert.That(expected.Equals(resultSchedule));
        }

        [Test]
        public void Test3AppeardOnlesson()
        {
            var user_id = "ppkstudent1";
            var lesson_id = "mayW01D05L02";

            AttendenceController.AppeardOnLesson(user_id, lesson_id);

            var list = db.Users.ToList();
            DateTime date = new DateTime(2025, 5, 5);

            string resultAppear = "";

            foreach (var user in list)
            {
                if (user.Id == user_id)
                {
                    foreach (Schedule schedule in user.Schedule)
                    {
                        if (date.Day == schedule.Date.Day && date.Year == schedule.Date.Year && date.Month == schedule.Date.Month)
                        {
                            foreach (Lesson lesson in schedule.Lessons)
                            {
                                if (lesson.Id == lesson_id)
                                {
                                    resultAppear = lesson.Attendence.Attended.ToString();
                                }
                            }

                        }
                    }

                }
            } //проверяю запись ищу ее в бд и проверяю изменился ли статус с фолс на тру

            var expected = "True";

            Assert.That(expected.Equals(resultAppear));
        }

        [Test]
        public void Test4DocumentAdd()
        {
            string userId = "ppkstudent1"; string lessonId = "mayW01D05L02"; string reason = "illness"; byte[] document = new byte[1]; string comment = "болел ОРВИ"; string scheduleId = "ATTmayW01D05L";

            string resultUpload = "";

            AttendenceController.Upload(userId, lessonId, reason, comment, document, scheduleId);

            List<User> users = db.GetUsers();
            foreach (var user in users)
            {
                if (user.Id == userId)
                {
                    foreach (Schedule schedule in user.Schedule)
                    {
                        if (schedule.Id == scheduleId)
                        {
                            foreach (Lesson lesson in schedule.Lessons)
                            {
                                if (lesson.Id == lessonId)
                                {
                                    resultUpload = lesson.Attendence.SkipReason.ToString();

                                }
                            }
                        }
                    }
                }
            }//проверяю запись ищу ее в бд и проверяю изменился ли причина с фолс на тру - если она сменилась то и остальное тоже

            string expected = "illness";

            Assert.That(expected.Equals(resultUpload));
        }
        [Test]
        public void Test5ReportBack()
        {
            string user_id = "ppkstudent1";
            DateTime date = new DateTime(2025, 5, 5);
            var actualReport = ReportController.GetReport(user_id, date);

            string expectedReport = "";
            expectedReport += "всего пропущено по не уважительной причине - 0IMYA OTCH FAM";
            expectedReport += "\n";
            expectedReport += "пропущеное занятие по не уважительной причине - 05.05.2025 0:00:00, 1. para";
            expectedReport += "\n";
            expectedReport += "всего пропущено по не уважительной причине - 1";
            expectedReport += "\n";
            expectedReport += "всего пропущено по уважительной причине - 0";
            expectedReport += "\n";
            Assert.That(expectedReport.Equals(actualReport));
        }
    }
}
