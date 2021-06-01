using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public static class Export
    {

        public static void ExportToTXT(string fileInfo)
        {
            //SQLqueries.ViewWholeDB();
            //string currDir = Directory.GetCurrentDirectory();
            //string path = currDir + "/export.txt";
            string path = $"export_for_{fileInfo}.txt";
            File.WriteAllText(path, SQLiteStuff.output);
            Process.Start(path);
        }

    }
}
