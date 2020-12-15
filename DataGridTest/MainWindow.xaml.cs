using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataGridTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string test;

        public MainWindow()
        {

            InitializeComponent();
            ReadFile();
        }


        private void Some_Button_Click(object sender, RoutedEventArgs e)
        {
            

            //note New_Note = new note();
            //New_Note.NoteName = "Test";
            //New_Note.NoteText = "asdasdasd";
            //Data_Grid1.Items.Add(New_Note);
        }
        public class note
        {
            public string NoteName { get; set; }
            public string NoteText { get; set; }

        }

        public void ReadFile()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\user\source\repos\ExcelDataTest\ExcelDataTest\bin\Debug\DB.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int totalColumns = xlWorksheet.UsedRange.Columns.Count;
            int totalRows = xlWorksheet.UsedRange.Rows.Count;


            for (int row = 2; row <= totalRows; row++)
            {
                if (xlRange.Cells[row, 1] != null)
                    Console.WriteLine(xlRange.Cells[row, 1].Value2.ToString() + "\n");
                xlWorkbook.Close();
                xlApp.Quit();
            }

        }

    }
}
