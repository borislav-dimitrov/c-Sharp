using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public static class SQLqueries
    {

        public static void ViewWholeDbByID()
        {
            Console.WriteLine("\n");
            string query = "Select * from otcheti order by id";
            SQLiteStuff.PreviewOutput(query);
            Console.Clear();

            Console.WriteLine("\n=======\n");
            Console.WriteLine(SQLiteStuff.output);
            Console.WriteLine("\n=======\n");
        }

        public static void ViewWholeDbByDate()
        {
            Console.WriteLine("\n");
            string query = "Select * from otcheti order by today_date";
            SQLiteStuff.PreviewOutput(query);
            Console.Clear();

            Console.WriteLine("\n=======\n");
            Console.WriteLine(SQLiteStuff.output);
            Console.WriteLine("\n=======\n");
        }

        public static void ViewDbForDateByID()
        {
            Console.WriteLine("\nChose date..");
            string input = UserInputCheck.CheckDate();

            Console.WriteLine("\n");
            string query = $"Select * from otcheti where today_date = \"{input}\" order by id";
            SQLiteStuff.PreviewOutput(query);
            Console.Clear();

            Console.WriteLine("\n=======\n");
            Console.WriteLine(SQLiteStuff.output);
            Console.WriteLine("\n=======\n");
        }

        public static void ViewDbForDateByDate()
        {
            Console.WriteLine("\nChose date..");
            string input = UserInputCheck.CheckDate();

            Console.WriteLine("\n");
            string query = $"Select * from otcheti where today_date = \"{input}\" order by starting_time";
            SQLiteStuff.PreviewOutput(query);
            Console.Clear();

            Console.WriteLine("\n=======\n");
            Console.WriteLine(SQLiteStuff.output);
            Console.WriteLine("\n=======\n");
        }

        /////////////////////////////////////////////

        public static void InsertRecord()
        {
            Console.WriteLine("\n\nInput \"q\" to cancel");

            Console.WriteLine("Input date (dd-mm-yyyy)..");
            string date = UserInputCheck.CheckDate();

            Console.WriteLine("Input start time..");
            string starting_time = UserInputCheck.CheckTime();

            Console.WriteLine("Input finish time...");
            string finishing_time = UserInputCheck.CheckTime();

            Console.WriteLine("Input user name...");
            string username = Console.ReadLine();
            if (username == "q")
                Decisions.Decision();

            Console.WriteLine("Input report description...");
            string report = Console.ReadLine();
            if (username == "q")
                Decisions.Decision();

            string query = $"insert into otcheti (today_date, starting_time, finishing_time, user, description) values (\"{date}\",\"{starting_time}\",\"{finishing_time}\",\"{username}\",\"{report}\")";
            Console.WriteLine("");
            SQLiteStuff.Query(query);

        }

        public static void DeleteRowByID()
        {
            Console.WriteLine("\nInput report ID to delete..");
            string idToDel = Console.ReadLine();
            string query = $"delete from otcheti where id={idToDel} ";
            SQLiteStuff.Query(query);
        }

    }
}
