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

namespace AngelSix002
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

        private void New_Note_Click(object sender, RoutedEventArgs e)
        {
            Input_Box.Visibility = System.Windows.Visibility.Visible;


        }

        private void Input_No_Click(object sender, RoutedEventArgs e)
        {
            Input_Box.Visibility = System.Windows.Visibility.Collapsed;
            Name_For_New_Note.Text = string.Empty;
        }

        private void Input_Yes_Click(object sender, RoutedEventArgs e)
        {
            string Add_New_Note = Name_For_New_Note.Text;
            All_Notes.Items.Add(Add_New_Note);
            Add_New_Note = string.Empty;
            Input_Box.Visibility = System.Windows.Visibility.Collapsed;
            Name_For_New_Note.Text = string.Empty;
        }

        public void ReadFile()
        {

        }
        




    }
}
