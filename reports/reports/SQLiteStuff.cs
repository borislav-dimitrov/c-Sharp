using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows;

namespace reports
{
    public static class SQLiteStuff
    {

        public static string TableNames = "";
        public static string result = "";
        public static string output = "";
        public static List<string> startingTimes = new List<string>();
        public static List<string> finishingTimes = new List<string>();
        public static int totalTime = 0;

        public static void Query(string query)
        {
            string dbPath = "newDB.db";

            SQLiteConnection sqlite = SqlConnection(dbPath);

            SQLiteCommand cmd = new SQLiteCommand(dbPath, sqlite);

            sqlite.Open();

            ExecuteQuery(sqlite, query);

            if (sqlite.State == ConnectionState.Open)
                sqlite.Close();
        }

        public static void QueryToDB(string dbPath, string query)
        {

            SQLiteConnection sqlite;
            sqlite = new SQLiteConnection($"Data Source={dbPath};Version=3;");

            sqlite.Open();

            ExecuteQuery(sqlite, query);

            if (sqlite.State == ConnectionState.Open)
                sqlite.Close();

        }


        public static void ExecuteQuery(SQLiteConnection connection, string query)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(connection);
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }

        }

        public static void PreviewOutput(string query)
        {
            string dbPath = "newDB.db";

            SQLiteConnection sqlite = SqlConnection(dbPath);

            SQLiteCommand cmdTableNames = new SQLiteCommand("select name from pragma_table_info(\"otcheti\")", sqlite);


            SQLiteCommand cmd = new SQLiteCommand(query, sqlite);



            sqlite.Open();

            PreviewTableNames(cmdTableNames);
            PreviewDb(cmd);

            if (sqlite.State == ConnectionState.Open)
                sqlite.Close();


        }

        public static SQLiteConnection SqlConnection(string dbPath)
        {
            SQLiteConnection sqlite = new SQLiteConnection($"Data Source={dbPath};Version=3;");

            return sqlite;
        }

        public static void PreviewDb(SQLiteCommand cmd)
        {
            try
            {
                cmd.ExecuteNonQuery();
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                DataTable table = new DataTable("Table");
                sda.Fill(table);
                int columns = table.Columns.Count;
                int rows = table.Rows.Count;
                int counterColumns = 0;
                int counterRows = 0;


                while (counterRows < rows)
                {
                    while (counterColumns < columns)
                    {
                        result += table.Rows[counterRows][counterColumns].ToString() + " | ";
                        counterColumns++;
                    }
                    counterRows++;
                    if (counterColumns >= columns)
                    {
                        counterColumns = 0;
                        result += Environment.NewLine;

                    }
                }
                result = result.Remove(result.Length - 1);

                output = TableNames + Environment.NewLine + Environment.NewLine + result;


            }
            catch (Exception ex)
            {
                
            }
        }

        public static void PreviewTableNames(SQLiteCommand cmd)
        {
            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                DataTable table = new DataTable("Table");
                sda.Fill(table);
                int columns = table.Columns.Count;
                int rows = table.Rows.Count;
                int counterColumns = 0;
                int counterRows = 0;


                while (counterRows < rows)
                {
                    while (counterColumns < columns)
                    {
                        TableNames += table.Rows[counterRows][counterColumns].ToString() + " | ";
                        counterColumns++;
                    }
                    counterRows++;
                    if (counterColumns >= columns)
                    {
                        counterColumns = 0;

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #region GetTimes

        public static void GetTimes()
        {
            string[] prepareToGetTimes = result.Split('|');
            int counter = 2;

            try
            {
                while (counter < prepareToGetTimes.Length)
                {
                    startingTimes.Add(prepareToGetTimes[counter]);
                    finishingTimes.Add(prepareToGetTimes[counter + 1]);
                    counter += 7;
                }
            }
            catch 
            {

            }

            CalculateTotalTime();
        }

        private static void CalculateTotalTime()
        {
            int counter = 0;
            while (counter < startingTimes.Count())
            {
                int currentStartTime = Convert.ToInt32(TimeToMinnutes(startingTimes[counter]));
                int currentFinishTime = Convert.ToInt32(TimeToMinnutes(finishingTimes[counter]));
                totalTime += currentFinishTime - currentStartTime;
                counter++;
            }

            output += Environment.NewLine + Environment.NewLine + "Total time in minnutes : " + totalTime.ToString();
        }

        private static int TimeToMinnutes(string time)
        {
            try
            {
                string[] splitTime = time.Split(':');
                int hourToMinnute = Convert.ToInt32(splitTime[0])*60;
                int totalToMinnute = hourToMinnute + Convert.ToInt32(splitTime[1]);
                return totalToMinnute;
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        #endregion

    }
}
