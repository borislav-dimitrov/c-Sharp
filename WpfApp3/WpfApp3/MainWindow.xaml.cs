using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
		public List<string> allUsers = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ChangeToOLDold()
        {
            string currUser = Environment.UserName.ToString();

            if (File.Exists($@"C:\Users\{currUser}\.jorgachim\client.properties"))
                ChangeToOLDOldReportingIpFromNonVDI();
            else if (File.Exists($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties"))
                ChangeToOLDOldReportingIpFromVDI();
            else
            {
                logTb.Clear();
                logTb.Text += "Path not found :( .." + Environment.NewLine;
            }

        }

        public void ChangeToNEWold()
        {
            string currUser = Environment.UserName.ToString();

            if (File.Exists($@"C:\Users\{currUser}\.jorgachim\client.properties"))
                ChangeToNEWOldReportingIpFromNonVDI();
            else if (File.Exists($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties"))
                ChangeToNEWOldReportingIpFromVDI();
            else
            {
                logTb.Clear();
                logTb.Text += "Path not found :( .." + Environment.NewLine;
            }
        }

        #region ChangeToOLDoldReporting

        public void ChangeToOLDOldReportingIpFromNonVDI()
        {
            string currUser = Environment.UserName.ToString();
            string replace = "";

            try
            {
                using (StreamReader sr = new StreamReader
                                                ($@"C:\Users\{currUser}\.jorgachim\client.properties"))
                {
                    do
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("url.endpoint=http"))
                        {
                            replace += @"url.endpoint=http\://172.30.1.68\:8080/JRepServices" + Environment.NewLine;
                        }
                        else
                            replace += line + Environment.NewLine;
                    } while (sr.EndOfStream == false);
                }
                System.IO.File.WriteAllText($@"C:\Users\{currUser}\.jorgachim\client.properties", replace);
                replace = string.Empty;

                logTb.Clear();
                logTb.Text += "Changing endpoint to 172.30.1.68" + Environment.NewLine;
                logTb.Text += "Done..." + Environment.NewLine;
            }
            catch
            {
                logTb.Clear();
                logTb.Text += "Something went wrong :(" + Environment.NewLine;
            }
        }

        public void ChangeToOLDOldReportingIpFromVDI()
        {
            string currUser = Environment.UserName.ToString();
            string replace = "";

            try
            {
                using (StreamReader sr = new StreamReader
                                                ($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties"))
                {
                    do
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("url.endpoint=http"))
                        {
                            replace += @"url.endpoint=http\://172.30.1.68\:8080/JRepServices" + Environment.NewLine;
                        }
                        else
                            replace += line + Environment.NewLine;
                    } while (sr.EndOfStream == false);
                }
                System.IO.File.WriteAllText($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties", replace);
                replace = string.Empty;

                logTb.Clear();
                logTb.Text += "Changing endpoint to 172.30.1.68" + Environment.NewLine;
                logTb.Text += "Done..." + Environment.NewLine;
            }
            catch
            {

                logTb.Clear();
                logTb.Text += "Something went wrong :(" + Environment.NewLine;
            }
        }
        #endregion

        #region ChangeToNEWoldReporting


        public void ChangeToNEWOldReportingIpFromNonVDI()
        {
            string currUser = Environment.UserName.ToString();
            string replace = "";

            try
            {
                using (StreamReader sr = new StreamReader
                                                    ($@"C:\Users\{currUser}\.jorgachim\client.properties"))
                {
                    do
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("url.endpoint=http"))
                        {
                            replace += @"url.endpoint=http\://172.30.1.49\:8080/JRepServices" + Environment.NewLine;
                        }
                        else
                            replace += line + Environment.NewLine;
                    } while (sr.EndOfStream == false);
                }
                System.IO.File.WriteAllText($@"C:\Users\{currUser}\.jorgachim\client.properties", replace);
                replace = string.Empty;

                logTb.Clear();
                logTb.Text += "Changing endpoint to 172.30.1.49" + Environment.NewLine;
                logTb.Text += "Done..." + Environment.NewLine;
            }
            catch
            {
                logTb.Clear();
                logTb.Text += "Something went wrong :(" + Environment.NewLine;
            }
        }

        public void ChangeToNEWOldReportingIpFromVDI()
        {
            string currUser = Environment.UserName.ToString();
            string replace = "";

            try
            {
                using (StreamReader sr = new StreamReader
                                                    ($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties"))
                {
                    do
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("url.endpoint=http"))
                        {
                            replace += @"url.endpoint=http\://172.30.1.49\:8080/JRepServices" + Environment.NewLine;
                        }
                        else
                            replace += line + Environment.NewLine;
                    } while (sr.EndOfStream == false);
                }
                System.IO.File.WriteAllText($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties", replace);
                replace = string.Empty;

                logTb.Clear();
                logTb.Text += "Changing endpoint to 172.30.1.49" + Environment.NewLine;
                logTb.Text += "Done..." + Environment.NewLine;
            }
            catch
            {
                logTb.Clear();
                logTb.Text += "Something went wrong :(" + Environment.NewLine;
            }
        }
        #endregion

        private void OldOldRepBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeToOLDold();
        }

        private void NewOldRepBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeToNEWold();
        }
    }
}
