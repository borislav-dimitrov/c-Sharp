using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ConsoleApp4
{
    class SQLiteStuff
    {
        public static string output = "";

        public static void Query(string query)
        {
            //string currDir = Directory.GetCurrentDirectory();
            //string dbPath = currDir + "/newDB.db";
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
                Console.WriteLine(ex);

            }

        }

        public static void PreviewOutput(string query)
        {
            string dbPath = "newDB.db";

            SQLiteConnection sqlite = SqlConnection(dbPath);

            SQLiteCommand cmd = new SQLiteCommand(dbPath, sqlite);

            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;

            sqlite.Open();

            PeviewDb(cmd);

            if (sqlite.State == ConnectionState.Open)
                sqlite.Close();

            
        }

        public static SQLiteConnection SqlConnection(string dbPath)
        {
            SQLiteConnection sqlite = new SQLiteConnection($"Data Source={dbPath};Version=3;");

            return sqlite;
        }

        public static void PeviewDb(SQLiteCommand cmd)
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

                //string output = @"|";

                while (counterRows < rows)
                {
                    while (counterColumns < columns)
                    {
                        output += table.Rows[counterRows][counterColumns].ToString() + " | ";
                        counterColumns++;
                    }
                    counterRows++;
                    if (counterColumns >= columns)
                    {
                        counterColumns = 0;
                        output += Environment.NewLine;

                    }
                }
                output = output.Remove(output.Length - 1);
                //Console.WriteLine(output);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
