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
using HtmlAgilityPack;
using System.Net.Http;
using System.Windows.Threading;
using System.Timers;

namespace TVProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region public vars

        public List<string> nonFiltered = new List<string>();
        public List<string> filtered = new List<string>();
        #endregion

        #region default constructor

        public MainWindow()
        {
            InitializeComponent();
            InitTimer();
        }
        #endregion

        #region refreshTimeAndDate

        
        public void InitTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.IsEnabled = true;
            timer.Tick += new EventHandler(OnTimeEvent);
        }

        private void OnTimeEvent(object sender , EventArgs e)
        {
            setDateAndTime();
        }

        #endregion

        #region setDateAndTime
        private void setDateAndTime()
        {
            
            dateIS.Content = "Днес е " + DateTime.Now.ToString("dd/MM/yy");
            timeIS.Content = "Часът е " + DateTime.Now.ToString("HH:mm tt");
        }
        #endregion

        #region getRowsFromDesiredHTMLTable


        private async Task getHTMLforDesiredTV(string tv)
        {

            var url = "https://www.xn----8sbafg9clhjcp.bg/tv/" + tv + "/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            int counter = 0;
            htmlDocument.LoadHtml(html);
            HtmlNodeCollection tables = htmlDocument.DocumentNode.SelectNodes("//table");
            foreach (HtmlNode table in tables)
            {
                if (tables[counter].OuterHtml.Contains("programTable"))
                {
                    foreach (HtmlNode row in tables[counter].SelectNodes("tr"))
                    {
                        foreach (HtmlNode cell in row.SelectNodes("th|td"))
                        {
                            nonFiltered.Add(cell.InnerText);
                        }
                    }
                }

                counter++;
            }
            
        }
        #endregion

        #region filtering nonFIlteredList

        public void filtering()
        {
            int counter = 1;
            while (counter < nonFiltered.Count)
            {
                
                string toClear = nonFiltered[counter];
                try 
                { 
                    toClear = toClear.Substring(14);
                }
                catch
                { }
                try
                { 
                    toClear = toClear.Remove(toClear.Length - 13);
                }
                catch
                { }
                filtered.Add(toClear);
                counter++;
            }
            counter = 1;

        }

        #endregion

        #region filterOutUnnecessaryRows
        private void filterOutUnnecessaryRows()
        {
            int currItem = 0;
            while (currItem < filtered.Count)
            {
                if (filtered[currItem].Contains("nbsp"))
                {
                    filtered.RemoveAt(currItem);
                }
                currItem++;
            }
            currItem = 0;
            Console.ReadLine();
        }

        #endregion

        #region previewProgram
        private void previewProgram()
        {
            int counter = 0;
            while (counter < filtered.Count)
            {
                string currTIME = DateTime.Now.ToString("HH:mm tt");
                string[] splitted = currTIME.Split(':');
                int currentHour = Convert.ToInt32(splitted[0]);
                if (filtered[counter].Length.Equals(5))
                {
                    string[] splittedMovie = filtered[counter].Split(':');
                    int movieStartH = Convert.ToInt32(splittedMovie[0]);
                
                    if (currentHour == movieStartH)
                    {
                    displayProgram.Text += " ====> " + filtered[counter] + " - " + filtered[counter + 1] + "\n\n";
                    }
                    else
                    {
                    displayProgram.Text += filtered[counter] + " - " + filtered[counter + 1] + "\n\n";
                    }
                }
                counter = counter + 2;
            }

            counter = 0;
        }
        #endregion

        #region Buttons

        private async void btv_Click(object sender, RoutedEventArgs e)
        {
            displayProgram.Text = "";
            displayProgram.Text = "\n                                                                                === BTV ===\n\n\n";
            nonFiltered.Clear();
            filtered.Clear();
            try
            {
                await getHTMLforDesiredTV("btv");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            

            filtering();
            filterOutUnnecessaryRows();
            previewProgram();
        }

        private async void bnt_Click(object sender, RoutedEventArgs e)
        {
            displayProgram.Text = "";
            displayProgram.Text = "\n                                                                                === BNT ===\n\n\n";
            nonFiltered.Clear();
            filtered.Clear();
            try
            {
                await getHTMLforDesiredTV("bnt");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


            filtering();
            filterOutUnnecessaryRows();
            previewProgram();
        }

        private async void btvACTION_Click(object sender, RoutedEventArgs e)
        {
            displayProgram.Text = "";
            displayProgram.Text = "\n                                                                                === BTV Action ===\n\n\n";
            nonFiltered.Clear();
            filtered.Clear();
            try
            {
                await getHTMLforDesiredTV("btv-action");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


            filtering();
            filterOutUnnecessaryRows();
            previewProgram();
        }

        private async void historyCHANNEL_Click(object sender, RoutedEventArgs e)
        {
            displayProgram.Text = "";
            displayProgram.Text = "\n                                                                                === HistoryCH ===\n\n\n";
            nonFiltered.Clear();
            filtered.Clear();
            try
            {
                await getHTMLforDesiredTV("history");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


            filtering();
            filterOutUnnecessaryRows();
            previewProgram();
        }

        private async void novaTV_Click(object sender, RoutedEventArgs e)
        {
            displayProgram.Text = "";
            displayProgram.Text = "\n                                                                                === NovaTV ===\n\n\n";
            nonFiltered.Clear();
            filtered.Clear();
            try
            {
                await getHTMLforDesiredTV("nova-tv");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


            filtering();
            filterOutUnnecessaryRows();
            previewProgram();
        }

        private async void kinoNOVA_Click(object sender, RoutedEventArgs e)
        {
            displayProgram.Text = "";
            displayProgram.Text = "\n                                                                                === KinoNova ===\n\n\n";
            nonFiltered.Clear();
            filtered.Clear();
            try
            {
                await getHTMLforDesiredTV("kinonova");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


            filtering();
            filterOutUnnecessaryRows();
            previewProgram();
        }

        private async void natGEO_Click(object sender, RoutedEventArgs e)
        {
            displayProgram.Text = "";
            displayProgram.Text = "\n                                                                                === NatGeo ===\n\n\n";
            nonFiltered.Clear();
            filtered.Clear();
            try
            {
                await getHTMLforDesiredTV("national-geographic");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


            filtering();
            filterOutUnnecessaryRows();
            previewProgram();
        }

        private async void btvCINEMA_Click(object sender, RoutedEventArgs e)
        {
            displayProgram.Text = "";
            displayProgram.Text = "\n                                                                                === BTV Cinema ===\n\n\n";
            nonFiltered.Clear();
            filtered.Clear();
            try
            {
                await getHTMLforDesiredTV("btv-cinema");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


            filtering();
            filterOutUnnecessaryRows();
            previewProgram();
        }

        private async void btvCOMEDY_Click(object sender, RoutedEventArgs e)
        {
            displayProgram.Text = "";
            displayProgram.Text = "\n                                                                                === BTV Comedy ===\n\n\n";
            nonFiltered.Clear();
            filtered.Clear();
            try
            {
                await getHTMLforDesiredTV("btv-comedy");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


            filtering();
            filterOutUnnecessaryRows();
            previewProgram();
        }

        private async void DIEMA_Click(object sender, RoutedEventArgs e)
        {
            displayProgram.Text = "";
            displayProgram.Text = "\n                                                                                === DIEMA ===\n\n\n";
            nonFiltered.Clear();
            filtered.Clear();
            try
            {
                await getHTMLforDesiredTV("diema");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


            filtering();
            filterOutUnnecessaryRows();
            previewProgram();
        }
        #endregion
    }
}
