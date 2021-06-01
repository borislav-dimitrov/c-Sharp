using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;

namespace reports
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        #region Buttons

        private void currentDateBTN_Click(object sender, RoutedEventArgs e)
        {
            dateTB.Text = GetTodayDate();
        }

        private void currentTimeBTN_Click(object sender, RoutedEventArgs e)
        {
            startTimeTB.Text = GetCurrentTime();
        }

        private void currentTime2BTN_Click(object sender, RoutedEventArgs e)
        {
            finishTimeTB.Text = GetCurrentTime();
        }

        private void previewBTN_Click(object sender, RoutedEventArgs e)
        {
            if(previewCB.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an option first...");
            }
            else if (previewCB.SelectedIndex == 0)
            {
                SQLqueries.ViewWholeDbByID();
                Export.PreviewInTxt();
            }
            else if (previewCB.SelectedIndex == 1)
            {
                SQLqueries.ViewWholeDbByDate();
                Export.PreviewInTxt();
            }
            else if (previewCB.SelectedIndex == 2)
            {
                string date = CheckDate(sortByDateTB);
                if (date.Length > 1)
                {
                    SQLqueries.ViewDbForDateByID(date);
                    Export.PreviewInTxt();
                }
            }
            else if (previewCB.SelectedIndex == 3)
            {
                string date = CheckDate(sortByDateTB);
                if (date.Length > 1)
                {
                    SQLqueries.ViewDbForDateByDate(date);
                    Export.PreviewInTxt();
                }
            }

            sortByDateTB.Visibility = Visibility.Hidden;
            previewCB.SelectedIndex = -1;
            SQLiteStuff.TableNames = "";
            SQLiteStuff.result = "";
            SQLiteStuff.output = "";
            SQLiteStuff.totalTime = 0;
            SQLiteStuff.startingTimes.Clear();
            SQLiteStuff.finishingTimes.Clear();
            sortByDateTB.Text = "";
        }

        private void exportBTN_Click(object sender, RoutedEventArgs e)
        {
            if (exportCB.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an option first...");
            }
            else if (exportCB.SelectedIndex == 0)
            {
                SQLqueries.ViewWholeDbByID();
                Export.ExportToCSV();
            }
            else if (exportCB.SelectedIndex == 1)
            {
                SQLqueries.ViewWholeDbByDate();
                Export.ExportToCSV();
            }
            else if (exportCB.SelectedIndex == 2)
            {
                string date = CheckDate(exportByDateTB);
                if(date.Length>1)
                {
                    SQLqueries.ViewDbForDateByID(date);
                    Export.ExportToCSV();
                }
            }
            else if (exportCB.SelectedIndex == 3)
            {
                string date = CheckDate(exportByDateTB);
                if (date.Length > 1)
                {
                    SQLqueries.ViewDbForDateByDate(date);
                    Export.ExportToCSV();
                }
            }

            exportByDateTB.Visibility = Visibility.Hidden;
            exportCB.SelectedIndex = -1;
            SQLiteStuff.TableNames = "";
            SQLiteStuff.result = "";
            SQLiteStuff.output = "";
            SQLiteStuff.totalTime = 0;
            SQLiteStuff.startingTimes.Clear();
            SQLiteStuff.finishingTimes.Clear();
            exportByDateTB.Text = "";
        }

        private void InsertBTN_Click(object sender, RoutedEventArgs e)
        {
            string date = CheckDate(dateTB);
            string firm = firmTB.Text;
            string starting_time = CheckTime(startTimeTB);
            string finishing_time = CheckTime(finishTimeTB);
            string username = userTB.Text;
            string report = reportDescriptionTB.Text;

            if (report.Length < 1)
            {
                reportDescriptionTB.Text = "";
                MessageBox.Show("You cannot insert empty reports!");
            }
            else
            {
                SQLqueries.InsertRecord(date, firm, starting_time, finishing_time, username, report);
                dateTB.Text = "";
                firmTB.Text = "";
                startTimeTB.Text = "";
                finishTimeTB.Text = "";
                userTB.Text = "";
                reportDescriptionTB.Text = "";
            }
        }

        #endregion

        private void exportCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (exportCB.SelectedIndex == 2 || exportCB.SelectedIndex == 3)
                exportByDateTB.Visibility = Visibility.Visible;
            else if (exportCB.SelectedIndex == -1 || exportCB.SelectedIndex == 0 || exportCB.SelectedIndex == 1)
                exportByDateTB.Visibility = Visibility.Hidden;
        }

        private void previewCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (previewCB.SelectedIndex == 2 || previewCB.SelectedIndex == 3)
                sortByDateTB.Visibility = Visibility.Visible;
            else if(previewCB.SelectedIndex == -1 || previewCB.SelectedIndex == 0 || previewCB.SelectedIndex == 1 )
                sortByDateTB.Visibility = Visibility.Hidden;

        }

        #region Checks

        #region CheckDate

        private string CheckDate(TextBox tb)
        {


            Regex regex = new Regex(@"^[0-3]{1}\d{1}-[0-1]\d{1}-[2]{1}\d{1}\d{2}$");


            if (!regex.IsMatch(tb.Text))
            {
                tb.Text = "";
                MessageBox.Show("Bad date format! Please use \"dd-mm-yyyy\"");
                return tb.Text;
            }
            else
            {
                int tmpDay = Convert.ToInt32(tb.Text[0].ToString() + tb.Text[1].ToString());
                int tmpMonth = Convert.ToInt32(tb.Text[3].ToString() + tb.Text[4].ToString());

                if (tmpDay > 31 || tmpDay < 1)
                {
                    tb.Text = "";
                    tmpDay = 0;
                    tmpMonth = 0;
                    MessageBox.Show("Bad input! Invalid day!");
                    return tb.Text;
                }

                else if (tmpMonth > 12 || tmpMonth < 1)
                {
                    tb.Text = "";
                    tmpDay = 0;
                    tmpMonth = 0;
                    MessageBox.Show("Bad input! Invalid month!");
                    return tb.Text;
                }
                else
                {
                    tmpDay = 0;
                    tmpMonth = 0;
                    return tb.Text;
                }
            }




        }

        #endregion

        #region CheckTime

        private string CheckTime(TextBox tb)
        {
            Regex regex = new Regex(@"^\d{1,2}:\d\d$");

            if (!regex.IsMatch(tb.Text))
            {
                tb.Text = "";
                MessageBox.Show("Invalid time format! Please use \"00:00 - 23:00\"");
                return tb.Text;
            }
            else
            {
                string[] splittedTime = tb.Text.Split(':');
                int tmpHour = 0;
                int tmpMinnute = 0;

                if (splittedTime[0].Length == 2)
                {
                    tmpHour = Convert.ToInt32(tb.Text[0].ToString() + tb.Text[1].ToString());
                    tmpMinnute = Convert.ToInt32(tb.Text[3].ToString() + tb.Text[4].ToString());
                }
                else if (splittedTime[0].Length == 1)
                {
                    tmpHour = Convert.ToInt32(tb.Text[0].ToString());
                    tmpMinnute = Convert.ToInt32(tb.Text[2].ToString() + tb.Text[3].ToString());
                }


                if (tmpHour < 0 || tmpHour > 23)
                {
                    tb.Text = "";
                    tmpHour = 0;
                    tmpMinnute = 0;
                    MessageBox.Show("Invalid time format! Please use \"00:00 - 23:00\"");
                    return tb.Text;
                }

                if (tmpMinnute < 0 || tmpMinnute > 59)
                {
                    tb.Text = "";
                    tmpHour = 0;
                    tmpMinnute = 0;
                    MessageBox.Show("Invalid time format! Please use \"00:00 - 23:00\"");
                    return tb.Text;
                }
                else
                {
                    tmpHour = 0;
                    tmpMinnute = 0;
                    return tb.Text;
                }
            }

        }

        #endregion

        #endregion

        private static string GetTodayDate()
        {
            string today = DateTime.Now.ToString("dd-MM-yyyy");
            return today;
        }

        private static string GetCurrentTime()
        {
            string now = DateTime.Now.ToString("HH:mm");
            return now;
        }

        
    }
}
