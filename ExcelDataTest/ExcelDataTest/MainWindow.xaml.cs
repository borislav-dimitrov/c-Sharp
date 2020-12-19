using System;
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

namespace ExcelDataTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public class New_Note
        {
            public string noteName { get; set; }
            public string noteText { get; set; }
            public string noteXname { get; set; }
        }


        public MainWindow()
        {
            InitializeComponent();
            try
            {
                ReadExcel();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        private void NewRecord_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        public void ReadExcel()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\user\source\repos\ExcelDataTest\ExcelDataTest\bin\Debug\DB.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int totalColumns = xlWorksheet.UsedRange.Columns.Count;
            int totalRows = xlWorksheet.UsedRange.Rows.Count;

            List<string> ls = new List<string>();
            List<string> ls2 = new List<string>();

            for (int row = 2; row <= totalRows; row++)
            {

                if (xlRange.Cells[row, 1] != null)
                    ls.Add(xlRange.Cells[row, 1].Value2.ToString());
                if (xlRange.Cells[row, 2] != null)
                    ls2.Add(xlRange.Cells[row, 2].Value2.ToString());
            }

            Data1.IsReadOnly = false;
            int a = 0;
            foreach (string i in ls)
            {

                New_Note newNote = new New_Note();
                newNote.noteName = i;
                newNote.noteText = ls2[a];
                Data1.Items.Add(newNote);
                a++;
            }

            Data1.IsReadOnly = true;

            xlWorkbook.Close();
            xlApp.Quit();


        }

        private void Text1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



    }
}
