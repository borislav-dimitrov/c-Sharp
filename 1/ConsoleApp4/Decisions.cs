using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public static class Decisions
    {

        public static void Decision()
        {
            SQLiteStuff.output = "";
            Console.WriteLine("Chose an option :\n");
            Console.WriteLine("1. Insert information.");
            Console.WriteLine("2. Preview table.");
            Console.WriteLine("3. Export table to txt.");
            Console.WriteLine("q. Exit\n");
            DoSomethingFromChoices();
        }

        public static void DoSomethingFromChoices()
        {
        ChoseAgain:
            string userChoice = Console.ReadLine();
            if (userChoice != "1" && userChoice != "2" && userChoice != "3" && userChoice != "q")
            {
                Console.WriteLine("\nInvalid choice! Please chose again..");
                goto ChoseAgain;
            }
            if (userChoice == "1")
            {
                SQLqueries.InsertRecord();
                Decision();
            }
            if (userChoice == "2")
            {
                PreviewDbOptions();
                Decision();
            }
            if (userChoice == "3")
            {
                ExportDbOptions();
                Decision();
            }
            if (userChoice == "q")
            {
                Console.WriteLine("\n\nBye...");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        public static void PreviewDbOptions()
        {
            Console.Clear();
            Console.WriteLine("Chose a way to view the info:\n");

            Console.WriteLine("1. View all / sort by id.");
            Console.WriteLine("2. View all / sort by date.");
            Console.WriteLine("3. View for date / sort by id.");
            Console.WriteLine("4. View for date / sort by time.");
            Console.WriteLine("b. Go back.\n");

        ChoseAgain:
            string userChoice = Console.ReadLine();
            if (userChoice != "1" && userChoice != "2" && userChoice != "3" && userChoice != "4" && userChoice != "b")
            {
                Console.WriteLine("\nInvalid choice! Please chose again..");
                goto ChoseAgain;
            }

            if (userChoice == "1")
            {
                SQLqueries.ViewWholeDbByID();
                Decision();
            }

            if (userChoice == "2")
            {
                SQLqueries.ViewWholeDbByDate();
                Decision();
            }

            if (userChoice == "3")
            {
                SQLqueries.ViewDbForDateByID();
                Decision();
            }

            if (userChoice == "4")
            {
                SQLqueries.ViewDbForDateByDate();
                Decision();
            }

            if (userChoice == "b")
            {
                Console.Clear();
                Decision();
            }
        }

        public static void ExportDbOptions()
        {
            Console.Clear();
            Console.WriteLine("Chose a way to view the info:\n");

            Console.WriteLine("1. Export all / sort by id.");
            Console.WriteLine("2. Export all / sort by date.");
            Console.WriteLine("3. Export for date / sort by id.");
            Console.WriteLine("4. Export for date / sort by time.");
            Console.WriteLine("b. Go back.\n");

        ChoseAgain:
            string userChoice = Console.ReadLine();
            if (userChoice != "1" && userChoice != "2" && userChoice != "3" && userChoice != "4" && userChoice != "b")
            {
                Console.WriteLine("\nInvalid choice! Please chose again..");
                goto ChoseAgain;
            }

            if (userChoice == "1")
            {
                SQLqueries.ViewWholeDbByID();
                Console.Clear();
                Export.ExportToTXT("-exported_all_sorted_by_id");
                Decision();
            }

            if (userChoice == "2")
            {
                SQLqueries.ViewWholeDbByDate();
                Console.Clear();
                Export.ExportToTXT("-exported_all_sorted_by_date");
                Decision();
            }

            if (userChoice == "3")
            {
                SQLqueries.ViewDbForDateByID();
                Console.Clear();
                Export.ExportToTXT("-exported_for_date_sort_by_id");
                Decision();
            }

            if (userChoice == "4")
            {
                SQLqueries.ViewDbForDateByDate();
                Console.Clear();
                Export.ExportToTXT("-exported_for_date_sort_by_time");
                Decision();
            }

            if (userChoice == "b")
            {
                Console.Clear();
                Decision();
            }
        }
    }
}
