using _09122025.Classes;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _09122025.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttendenceController : ControllerBase
    {
        private DBBD db;

        [HttpPost("Attendence/Mark")]
        public string AppeardOnLesson(string userId, string lessonsId)
        {
            List<User> users = db.GetUsers();
            DateTime date = DateTime.Now;

            foreach (var user in users)
            {
                if(user.Id == userId)
                {
                    foreach (Schedule schedule in user.Schedule)
                    {
                        if (date.Day == schedule.Date.Day && date.Year == schedule.Date.Year && date.Month == schedule.Date.Month)
                        {
                            foreach (Lesson lesson in schedule.Lessons)
                            {
                               lesson.Attendence.Attended = true;
                                lesson.Attendence.AppeardTime = date;
                                return "Посещение учтено";
                                
                            }
                          
                        }
                    }
                   
                }
            }

            return "Неверный логин или пароль";
        }

        [HttpPost("Attendence/Upload-document")]
        public ActionResult Upload(string userId, string attendenceId, string reason, string comment, byte[] document)
        {

            return Ok();
        }

    }
}
