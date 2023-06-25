using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class Start : Controller
    {
        public string Hello()
        {
            var timeNight1 = new TimeOnly(0, 0);
            var timeNight2 = new TimeOnly(5, 59);            

            var timeMorning1 = new TimeOnly(6, 0);
            var timeMorning2 = new TimeOnly(11, 59);

            var timeDay1 = new TimeOnly(12, 0);
            var timeDay2 = new TimeOnly(17, 59);

            var timeEvening1 = new TimeOnly(18, 0);
            var timeEvening2 = new TimeOnly(23, 59);

            var result = "";
           
            var time = TimeOnly.FromDateTime(DateTime.Now);

            if (time >= timeNight1 && time <= timeNight2) 
            {
                result = "Доброй ночи";
            }
            if (time >= timeMorning1 && time <= timeMorning2)
            {
                result = "Доброе утро";
            }
            if (time >= timeDay1 && time <= timeDay2)
            {
                result = "Добрый день";
            }
            if (time >= timeEvening1 && time <= timeEvening2)
            {
                result = "Добрый вечер";
            }
            
            return result;
        }
    }
}