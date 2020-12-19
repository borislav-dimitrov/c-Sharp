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

namespace GuessTheNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int guess_me;

        public void RandomNum()
        {
            
            Random Rnd = new Random();
            int RndNum = Rnd.Next(1, 100);
            guess_me = RndNum;
            
        }

        public MainWindow()
        {
            
            
            InitializeComponent();
            RandomNum();
            
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            int user_guess = Convert.ToInt32(TextBox1.Text);
            if (user_guess > 100 || user_guess < 0)
            {
                MessageBox.Show("Only numbers between 0 - 100 please!");
            }

            if (user_guess < guess_me && user_guess > 0)
            {
                MessageBox.Show("Guess higher.");
            }
            else if (user_guess > guess_me && user_guess <= 100)
            {
                MessageBox.Show("Guess lower.");
            }
            else if (user_guess == guess_me)
            {
                Label3.Content = "Congratulations you win !!!";
                Label4.Content = "The number was: " + guess_me;
            }
        }

        private void TextBox1_PreviewTextinput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
    }
}

