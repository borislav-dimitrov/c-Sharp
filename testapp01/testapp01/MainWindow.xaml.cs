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
using System.Text.RegularExpressions;

namespace testapp01
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



        private void TextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToInt32(TextBox1.Text);
            double y = Convert.ToInt32(TextBox2.Text);
            double z = x + y;
            Label1.Content = z;

        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToInt32(TextBox1.Text);
            double y = Convert.ToInt32(TextBox2.Text);
            double z = x - y;
            Label1.Content = z;
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToInt32(TextBox1.Text);
            double y = Convert.ToInt32(TextBox2.Text);
            double z = x / y;
            Label1.Content = z;
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToInt32(TextBox1.Text);
            double y = Convert.ToInt32(TextBox2.Text);
            double z = x * y;
            Label1.Content = z;
        }

        private void TextBox1_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
            e.Command == ApplicationCommands.Cut ||
            e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TextBox2_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
            e.Command == ApplicationCommands.Cut ||
            e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

    }
}
