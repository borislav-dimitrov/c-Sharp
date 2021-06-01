using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace reports
{
    public static class SQLqueries
    {

        public static void ViewWholeDbByID()
        {
            string query = "Select * from otcheti order by id";
            SQLiteStuff.PreviewOutput(query);
            SQLiteStuff.GetTimes();
        }

        public static void ViewWholeDbByDate()
        {
            string query = "Select * from otcheti order by today_date";
            SQLiteStuff.PreviewOutput(query);
            SQLiteStuff.GetTimes();
        }

        public static void ViewDbForDateByID(string input)
        {
            string query = $"Select * from otcheti where today_date = \"{input}\" order by id";
            SQLiteStuff.PreviewOutput(query);
            SQLiteStuff.GetTimes();
        }

        public static void ViewDbForDateByDate(string input)
        {
            string query = $"Select * from otcheti where today_date = \"{input}\" order by starting_time";
            SQLiteStuff.PreviewOutput(query);
            SQLiteStuff.GetTimes();
        }

        /////////////////////////////////////////////

        public static void InsertRecord(string date, string firm, string starting_time, string finishing_time, string username, string report)
        {
            string query = $"insert into otcheti (today_date, starting_time, finishing_time, user, description, firm) values (\"{date}\",\"{starting_time}\",\"{finishing_time}\",\"{username}\",\"{report}\",\"{firm}\")";
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

        public static void CalculateTime(string query)
        {

        }

    }
}
