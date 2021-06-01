using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace reports
{
    public static class Export
    {
        public static void PreviewInTxt()
        {
            string path = "tmp_export.txt";
            File.WriteAllText(path, SQLiteStuff.output);
            Process.Start(path);
        }

        public static void ExportToTXT()
        {
            string path = $"reports_export.txt";
            File.WriteAllText(path, SQLiteStuff.output);
            Process.Start(path);
        }

        public static void ExportToCSV()
        {
            SQLiteStuff.output = SQLiteStuff.output.Replace('|', '\t');
            string path = $"reports_export.csv";
            File.WriteAllText(path, SQLiteStuff.output);
            Process.Start(path);
        }

    }
}
