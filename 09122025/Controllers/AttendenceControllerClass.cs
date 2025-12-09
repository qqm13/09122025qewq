using Microsoft.AspNetCore.Mvc;

namespace _09122025.Classes
{
    public class AttendenceControllerClass(DBBD db)
    {
        private DBBD db = db;

        public void AppeardOnLesson(string userId, string lessonsId)
        {
            List<User> users = db.GetUsers();
            DateTime date = new DateTime(2025,5,5);

            foreach (var user in users)
            {
                if (user.Id == userId)
                {
                    foreach (Schedule schedule in user.Schedule)
                    {
                        if (date.Day == schedule.Date.Day && date.Year == schedule.Date.Year && date.Month == schedule.Date.Month)
                        {
                            foreach (Lesson lesson in schedule.Lessons)
                            {
                                if(lesson.Id == lessonsId)
                                {
                                    lesson.Attendence.Attended = true;
                                    lesson.Attendence.AppeardTime = date;
                                }
                            }

                        }
                    }

                }
            }
        }

        public void Upload(string userId, string lessonId, string reason, string comment, byte[] document, string scheduleId)
        {
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
                                    lesson.Attendence.SkipReason = reason;
                                    lesson.Attendence.SkipComment = comment;
                                    lesson.Attendence.SkipDocument = document;

                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
