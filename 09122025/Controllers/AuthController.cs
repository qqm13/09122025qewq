using _09122025.Classes;
using Microsoft.AspNetCore.Mvc;

namespace _09122025.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private DBBD db;

        [HttpPost("Auth/Verify")]
        public string Login(string login, string password)
        {
            List<User> users = db.GetUsers();

            foreach (var user in users)
            {
                if(user.Password == password&&user.Login == login)
                {
                    return user.Info;
                }
            }

            return "Неверный логин или пароль";
        }

        [HttpGet("Auth/Schedule")]
        public string Schedule(string user_id, DateOnly date)
        {
            List<User> users = db.GetUsers();

            string answer = "";

            foreach (var user in users)
            {
                if (user_id == user.Id)
                {
                   foreach(Schedule schedule in user.Schedule)
                    {
                        if(schedule.Date == date)
                        {
                            foreach(Lesson lesson in schedule.Lessons)
                            {
                                answer += lesson.Number;
                                answer += ". ";
                                answer += lesson.Title;
                                answer += "\n";
                            }
                            return answer;
                        }
                    }
                }
            }

            return "Неверный логин или пароль";
        }
    }
}
