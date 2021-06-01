using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace OlxCrawl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string currDir = Directory.GetCurrentDirectory();
        public string minPrice;
        public string maxPrice;
        public string keyWordsToSearchFor;
        public string emailForNotifications;
        
        public int compareOutput;
        public int searchTime;

        public MainWindow()
        {
            InitializeComponent();
            SetBackGround();
        }

        #region SetBackGround
        public void SetBackGround()
        {
            string backgroundImagePath = currDir + @"\Assets\bg.png";

            BitmapImage bgImage = new BitmapImage();
            bgImage.BeginInit();
            bgImage.UriSource = new Uri(backgroundImagePath);
            bgImage.EndInit();


            backgroundIB.ImageSource = bgImage;
        }
        #endregion


        private void GetDesiredFilterInformation()
        {
            minPrice = minPriceTB.Text;
            maxPrice = maxPriceTB.Text;
            keyWordsToSearchFor = searchForKeywordTB.Text;
            emailForNotifications = sendEmailToTB.Text;
            if (Convert.ToInt32(sendNotificationTimerTB.Text) < 1)
            {
                searchBTN.IsChecked = false;
                MessageBox.Show("Search time is too low..\n Chose atleast 1 minnutes!");
            }
            else
            {
                searchTime = Convert.ToInt32(sendNotificationTimerTB.Text);
            }
        }


        private void searchBTN_Checked(object sender, RoutedEventArgs e)
        {
            HtmlScrape.output = "";
            DisableInput();
            searchBTN.Content = "Searching...";


            if (minPriceTB.Text.Length <= 0)
            {
                searchBTN.IsChecked = false;
                MessageBox.Show("Please input min price!");
            }
            else if (maxPriceTB.Text.Length <= 0)
            {
                searchBTN.IsChecked = false;
                MessageBox.Show("Please input max price!");
            }
            else if (searchForKeywordTB.Text.Length <= 0)
            {
                searchBTN.IsChecked = false;
                MessageBox.Show("Please input keywords!");
            }
            else if (sendEmailToTB.Text.Length <= 0)
            {
                searchBTN.IsChecked = false;
                MessageBox.Show("Please input email!");
            }
            else
            {
                GetDesiredFilterInformation();
                string url = $@"https://www.olx.bg/ads/q-{ keyWordsToSearchFor }/?search%5Bpaidads_listing%5D=2&search%5Bfilter_float_price%3Afrom%5D={minPrice}&search%5Bfilter_float_price%3Ato%5D={maxPrice}";
                HtmlScrape.HTML_Scrape(url, keyWordsToSearchFor, minPrice, maxPrice);
                timer();

            }
        }

        private void searchBTN_Unchecked(object sender, RoutedEventArgs e)
        {
            EnableInput();
            searchBTN.Content = "Search";
        }

        private void DisableInput()
        {
            minPriceTB.IsReadOnly = true;
            maxPriceTB.IsReadOnly = true;
            sendNotificationTimerTB.IsReadOnly = true;
            searchForKeywordTB.IsReadOnly = true;
            sendEmailToTB.IsReadOnly = true;
        }

        private void EnableInput()
        {
            minPriceTB.IsReadOnly = false;
            maxPriceTB.IsReadOnly = false;
            sendNotificationTimerTB.IsReadOnly = false;
            searchForKeywordTB.IsReadOnly = false;
            sendEmailToTB.IsReadOnly = false;
        }

        #region Timer

        private void timer()
        {

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(ShowOutput);
            timer.Interval = new TimeSpan(0, searchTime, 0);
            timer.Start();
        }

        public void ShowOutput(object sender, EventArgs e)
        {

            if((bool)searchBTN.IsChecked)
            {
                if(HtmlScrape.output.Length != compareOutput)
                {
                    SendMailNotification.SendMail(sendEmailToTB.Text, HtmlScrape.output);
                }
            }
            else
            {
                (sender as DispatcherTimer).Stop();
            }

            compareOutput = HtmlScrape.output.Length;

        }



        #endregion

        #region InputFilter

        private void PreviewTextInputForMinPrice(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void minPriceTB_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void maxPriceTB_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void PreviewTextInputForMaxPrice(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PreviewTextInputForTimer(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void sendNotificationTimerTB_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void searchForKeywordTB_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void searchForKeywordTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #endregion


    }
}
