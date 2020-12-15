using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace ConsoleAppExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\user\source\repos\ExcelDataTest\ExcelDataTest\bin\Debug\DB.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int totalColumns = xlWorksheet.UsedRange.Columns.Count;
            int totalRows = xlWorksheet.UsedRange.Rows.Count;

            List<string> ls = new List<string>();
            //string x = "";

            #region Read nonEmpty Rows
            // read all nonempty rows in column 1
            for (int row = 2; row <= totalRows; row++)
            {
                if (xlRange.Cells[row, 1] != null)
                    //Console.Write(xlRange.Cells[row, 1].Value2.ToString() + "\n");
                    ls.Add(xlRange.Cells[row, 1].Value2.ToString());

            }
            xlWorkbook.Close();
            xlApp.Quit();
            foreach (string i in ls)
            {
                Console.WriteLine(i);
            }

            #endregion


            #region Write to Excel
            //write text to cell [row2,col1]
            //xlRange.Cells[2, 1] = "1";
            //xlApp.DisplayAlerts = false;
            //xlWorkbook.Save();
            //xlWorkbook.Close();
            //xlApp.DisplayAlerts = true;
            //xlApp.Quit();

            #endregion



        }

    }
}
