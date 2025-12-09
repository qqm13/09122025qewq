using Microsoft.AspNetCore.Mvc;

namespace _09122025.Classes
{
    public class ReportControllerClass(DBBD db)
    {
        
        private DBBD db = db;

        [HttpPost("reports/attendance")]
        public string GetReport(string user_id, DateTime date)
        {
            List<User> users = db.GetUsers();
            string answer = "";
            int schetPropeskneUvazh = 0;
            int schetPropeskUvazh = 0;


            foreach (var user in users)
            {
                if (user.Id == user_id)
                {
                    answer += $"всего пропущено по не уважительной причине - {schetPropeskneUvazh}";
                    answer += $"{user.FIO}";
                    answer += "\n";
                    foreach (Schedule schedule in user.Schedule)
                    {
                        if (date.Year == schedule.Date.Year && date.Month == schedule.Date.Month)
                        {
                            foreach (Lesson lesson in schedule.Lessons)
                            {
                                if (lesson.Attendence.Attended == false && lesson.Attendence.SkipDocument != null)
                                {
                                    answer += $"пропущеное занятие по уважительной причине - {schedule.Date}, {lesson.Number}. {lesson.Title}";
                                    answer += "\n";
                                    schetPropeskUvazh++;
                                }
                                else if (lesson.Attendence.Attended == false && lesson.Attendence.SkipDocument == null)
                                {
                                    answer += $"пропущеное занятие по не уважительной причине - {schedule.Date}, {lesson.Number}. {lesson.Title}";
                                    answer += "\n";
                                    schetPropeskneUvazh++;
                                }
                            }

                        }
                    }

                }
            }
            answer += $"всего пропущено по не уважительной причине - {schetPropeskneUvazh}";
            answer += "\n";
            answer += $"всего пропущено по уважительной причине - {schetPropeskUvazh}";
            answer += "\n";
            return answer;
        }






    }
}
