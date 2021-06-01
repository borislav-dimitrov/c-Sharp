using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTime
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTime();
        }

        public static void TestTime()
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            string[] splitDate = date.Split('.');
            date = splitDate[1] + "_" + splitDate[0] + "_" + splitDate[2];
            Console.WriteLine(date);
            Console.ReadLine();
        }
    }
}
