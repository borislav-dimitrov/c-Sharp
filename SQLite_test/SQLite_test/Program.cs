using System;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;

namespace SQLite_test
{
    class MainClass
    {
        // BEGIN

        public static void Main(string[] args)
        {
            CreateDB();
        }

        public static void CreateDB()
        {
            string query = "select * from test_table";

            string currDir = Directory.GetCurrentDirectory();
            string dbPath = $"{currDir}/newDB.db";

            SqliteConnection sqlite;
            sqlite = new SqliteConnection($"Data Source={dbPath};Version=3;");
            sqlite.Open();

            ExecuteQuery(sqlite, query);

            if(sqlite.State == ConnectionState.Open)
                sqlite.Close();

            Console.ReadKey();
        }

        public static void ExecuteQuery(SqliteConnection connection, string query)
        {
            try
            {
                SqliteCommand cmd = new SqliteCommand(connection);
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                PreviewOutput(cmd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

        }


        public static void PreviewOutput(SqliteCommand cmd)
        {
            try
            {
                SqliteDataAdapter sda = new SqliteDataAdapter(cmd);
                DataTable table = new DataTable("Table");
                sda.Fill(table);
                int columns = table.Columns.Count;
                int rows = table.Rows.Count;
                int counterColumns = 0;
                int counterRows = 0;

                string output = "|";

                while (counterRows < rows)
                {
                    while (counterColumns < columns)
                    {
                        output += table.Rows[counterRows][counterColumns].ToString() + " | ";
                        counterColumns++;
                    }
                    counterRows++;
                    if(counterColumns >= columns)
                    {
                        Console.WriteLine(output);
                        counterColumns = 0;
                        output = "|";
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }
        // END
    }
}
