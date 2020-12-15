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


namespace FileReadTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadTextAndNewListAdd();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Add(New_Item.Text);

        }

        public void ReadTextAndNewListAdd()
        {
            

            
            
                try
                {
                    StreamReader reader = new StreamReader("test.txt");
                    using (reader)
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            line = reader.ReadLine();
                            ListBox.Items.Add(line);
                        }
                    }
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            
        }

        public void WriteTextToFile()
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter("test.txt");

                using (streamWriter)
                {
                    
                    foreach(var item in ListBox.Items)
                    {
                        streamWriter.WriteLine(item.ToString());
                    }
                    
                    MessageBox.Show("Saved!");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            WriteTextToFile();
        }
    }
}
