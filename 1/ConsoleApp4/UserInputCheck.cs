using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public static class UserInputCheck
    {

        public static string CheckDate()
        {
            Regex regex = new Regex(@"^[0-3]{1}\d{1}-[0-1]\d{1}-[2]{1}\d{1}\d{2}$");


        Again:
            string input = Console.ReadLine();
            
            if(input == "q")
                Decisions.Decision();

            while (!regex.IsMatch(input))
            {
                Console.WriteLine("Bad date format! Please use \"dd-mm-yyyy\"");
                input = Console.ReadLine();
            }

            int tmpDay = Convert.ToInt32(input[0].ToString() + input[1].ToString());
            int tmpMonth = Convert.ToInt32(input[3].ToString() + input[4].ToString());

            if (tmpDay > 31 || tmpDay < 1)
            {
                Console.WriteLine("Bad input! Invalid day!");
                goto Again;
            }

            if (tmpMonth > 12 || tmpMonth < 1)
            {
                Console.WriteLine("Bad input! Invalid month!");
                goto Again;
            }

            tmpDay = 0;
            tmpMonth = 0;

            return input;
        }

        public static string CheckTime()
        {
            Regex regex = new Regex(@"^\d{1,2}:\d\d$");

        Again:
            string time = Console.ReadLine();

            if (time == "q")
                Decisions.Decision();

            while (!regex.IsMatch(time))
            {
                Console.WriteLine("Invalid time format! Please use \"00:00 - 23:00\"");
                time = Console.ReadLine();
            }

            string[] splittedTime = time.Split(':');
            int tmpHour = 0;
            int tmpMinnute = 0;

            if (splittedTime[0].Length == 2)
            {
                tmpHour = Convert.ToInt32(time[0].ToString() + time[1].ToString());
                tmpMinnute = Convert.ToInt32(time[3].ToString() + time[4].ToString());
            }
            else if (splittedTime[0].Length == 1)
            {
                tmpHour = Convert.ToInt32(time[0].ToString());
                tmpMinnute = Convert.ToInt32(time[2].ToString() + time[3].ToString());
            }
            

            if (tmpHour < 0 || tmpHour > 23)
            {
                Console.WriteLine("Invalid time format! Please use \"00:00 - 23:00\"");
                goto Again;
            }

            if (tmpMinnute < 0 || tmpMinnute > 59)
            {
                Console.WriteLine("Invalid time format! Please use \"00:00 - 23:00\"");
                goto Again;
            }

            tmpHour = 0;
            tmpMinnute = 0;
            return time;
        }

        private static string GetTodayDate()
        {
            string today = DateTime.Now.ToString("dd-mm-yyyy");
            return today;
        }

    }
}
