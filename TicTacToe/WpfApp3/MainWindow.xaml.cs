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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region publicVars
        public bool p1Turn;
        public bool gameEnd = false;
        public bool p1Win = false;
        public bool p2Win = false;
        #endregion

        #region Constructor


        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }
        #endregion

        #region NewGame
        public void NewGame()
        {
            Btt0_0.Content = Btt0_1.Content = Btt0_2.Content = Btt1_0.Content = Btt1_1.Content = Btt1_2.Content = Btt2_0.Content = Btt2_1.Content = Btt2_2.Content = string.Empty;
            Btt0_0.Background = Btt0_1.Background = Btt0_2.Background = Btt1_0.Background = Btt1_1.Background = Btt1_2.Background = Btt2_0.Background = Btt2_1.Background = Btt2_2.Background = Brushes.White;
            p1Win = false;
            p2Win = false;
            gameEnd = false;
            p1Turn = true;
        }
        #endregion

        #region PlayerTurns
        private void PlayerTurns(Button button)
        {
            if (p1Turn)
            {
                if (button.Content.ToString().Length == 0)
                { 
                    button.Content = "X";
                    button.Foreground = Brushes.Red;
                    p1Turn = false;
                }

            }
            else
            {
                if (button.Content.ToString().Length == 0)
                { 
                    button.Content = "O";
                    button.Foreground = Brushes.Blue;
                    p1Turn = true;
                }
            }
        }

        #endregion

        #region Buttons


        private void Btt0_0_Click(object sender, RoutedEventArgs e)
        {
            PlayerTurns(Btt0_0);
            CheckWinner();
        }

        private void Btt1_0_Click(object sender, RoutedEventArgs e)
        {
            PlayerTurns(Btt1_0);
            CheckWinner();
        }

        private void Btt2_0_Click(object sender, RoutedEventArgs e)
        {
            PlayerTurns(Btt2_0);
            CheckWinner();
        }

        private void Btt0_1_Click(object sender, RoutedEventArgs e)
        {
            PlayerTurns(Btt0_1);
            CheckWinner();
        }

        private void Btt1_1_Click(object sender, RoutedEventArgs e)
        {
            PlayerTurns(Btt1_1);
            CheckWinner();
        }

        private void Btt2_1_Click(object sender, RoutedEventArgs e)
        {
            PlayerTurns(Btt2_1);
            CheckWinner();
        }

        private void Btt0_2_Click(object sender, RoutedEventArgs e)
        {
            PlayerTurns(Btt0_2);
            CheckWinner();
        }

        private void Btt1_2_Click(object sender, RoutedEventArgs e)
        {
            PlayerTurns(Btt1_2);
            CheckWinner();
        }

        private void Btt2_2_Click(object sender, RoutedEventArgs e)
        {
            PlayerTurns(Btt2_2);
            CheckWinner();
        }
        #endregion

        #region CheckWinner
        private void CheckWinner()
        {

            #region CheckWinnerByLines

            #region CheckP1
            if ((Btt0_0.Content as string) == "X" && (Btt1_0.Content as string) == "X" && (Btt2_0.Content as string) == "X")
            {
                Btt0_0.Background = Btt1_0.Background = Btt2_0.Background = Brushes.Green;
                gameEnd = true;
                p1Win = true;
            }
            else if ((Btt0_1.Content as string) == "X" && (Btt1_1.Content as string) == "X" && (Btt2_1.Content as string) == "X")
            {
                Btt0_1.Background = Btt1_1.Background = Btt2_1.Background = Brushes.Green;
                gameEnd = true;
                p1Win = true;
            }
            else if ((Btt0_2.Content as string) == "X" && (Btt1_2.Content as string) == "X" && (Btt2_2.Content as string) == "X")
            {
                Btt0_2.Background = Btt1_2.Background = Btt2_2.Background = Brushes.Green;
                gameEnd = true;
                p1Win = true;
            }
            #endregion
            #region CheckP2
            if ((Btt0_0.Content as string) == "O" && (Btt1_0.Content as string) == "O" && (Btt2_0.Content as string) == "O")
            {
                Btt0_0.Background = Btt1_0.Background = Btt2_0.Background = Brushes.Green;
                gameEnd = true;
                p2Win = true;
            }
            else if ((Btt0_1.Content as string) == "O" && (Btt1_1.Content as string) == "O" && (Btt2_1.Content as string) == "O")
            {
                Btt0_1.Background = Btt1_1.Background = Btt2_1.Background = Brushes.Green;
                gameEnd = true;
                p2Win = true;
            }
            else if ((Btt0_2.Content as string) == "O" && (Btt1_2.Content as string) == "O" && (Btt2_2.Content as string) == "O")
            {
                Btt0_2.Background = Btt1_2.Background = Btt2_2.Background = Brushes.Green;
                gameEnd = true;
                p2Win = true;
            }
            #endregion

            #endregion

            #region CheckWinnerByRows
            #region CheckP1
            if ((Btt0_0.Content as string) == "X" && (Btt0_1.Content as string) == "X" && (Btt0_2.Content as string) == "X")
            {
                Btt0_0.Background = Btt0_1.Background = Btt0_2.Background = Brushes.Green;
                gameEnd = true;
                p1Win = true;
            }
            else if ((Btt1_0.Content as string) == "X" && (Btt1_1.Content as string) == "X" && (Btt1_2.Content as string) == "X")
            {
                Btt1_0.Background = Btt1_1.Background = Btt1_2.Background = Brushes.Green;
                gameEnd = true;
                p1Win = true;
            }
            else if ((Btt2_0.Content as string) == "X" && (Btt2_1.Content as string) == "X" && (Btt2_2.Content as string) == "X")
            {
                Btt2_0.Background = Btt2_1.Background = Btt2_2.Background = Brushes.Green;
                gameEnd = true;
                p1Win = true;
            }
            #endregion
            #region CheckP2
            if ((Btt0_0.Content as string) == "O" && (Btt0_1.Content as string) == "O" && (Btt0_2.Content as string) == "O")
            {
                Btt0_0.Background = Btt0_1.Background = Btt0_2.Background = Brushes.Green;
                gameEnd = true;
                p2Win = true;
            }
            else if ((Btt1_0.Content as string) == "O" && (Btt1_1.Content as string) == "O" && (Btt1_2.Content as string) == "O")
            {
                Btt1_0.Background = Btt1_1.Background = Btt1_2.Background = Brushes.Green;
                gameEnd = true;
                p2Win = true;
            }
            else if ((Btt2_0.Content as string) == "O" && (Btt2_1.Content as string) == "O" && (Btt2_2.Content as string) == "O")
            {
                Btt2_0.Background = Btt1_2.Background = Btt2_2.Background = Brushes.Green;
                gameEnd = true;
                p2Win = true;
            }
            #endregion
            #endregion

            #region CheckWinnerByDiagonals

            #region CheckP1
            if ((Btt0_0.Content as string) == "X" && (Btt1_1.Content as string) == "X" && (Btt2_2.Content as string) == "X")
            {
                Btt0_0.Background = Btt1_1.Background = Btt2_2.Background = Brushes.Green;
                gameEnd = true;
                p1Win = true;
            }
            if ((Btt0_2.Content as string) == "X" && (Btt1_1.Content as string) == "X" && (Btt2_0.Content as string) == "X")
            {
                Btt0_2.Background = Btt1_1.Background = Btt2_0.Background = Brushes.Green;
                gameEnd = true;
                p1Win = true;
            }
            #endregion
            #region CheckP2
            if ((Btt0_0.Content as string) == "O" && (Btt1_1.Content as string) == "O" && (Btt2_2.Content as string) == "O")
            {
                Btt0_0.Background = Btt1_1.Background = Btt2_2.Background = Brushes.Green;
                gameEnd = true;
                p2Win = true;
            }
            if ((Btt0_2.Content as string) == "O" && (Btt1_1.Content as string) == "O" && (Btt2_0.Content as string) == "O")
            {
                Btt0_2.Background = Btt1_1.Background = Btt2_0.Background = Brushes.Green;
                gameEnd = true;
                p2Win = true;
            }
            #endregion

            #endregion

            #region CheckIfGameIsEqual
            if (Btt0_0.Content != "" && Btt0_1.Content != "" && Btt0_2.Content != "" && Btt1_0.Content != "" && Btt1_1.Content != "" && Btt1_2.Content != "" && Btt2_0.Content != "" && Btt2_1.Content != "" && Btt2_2.Content != "")
            {
                gameEnd = true;
            }
            #endregion

            #region GameEnd
            if (gameEnd)
            {
                if(p1Win)
                {
                    MessageBox.Show("Congratulations player 1 wins !");
                }
                else if (p2Win)
                {
                    MessageBox.Show("Congratulations player 2 wins !");
                }
                else
                {
                    Btt0_0.Background = Btt0_1.Background = Btt0_2.Background = Btt1_0.Background = Btt1_1.Background = Btt1_2.Background = Btt2_0.Background = Btt2_1.Background = Btt2_2.Background = Brushes.Orange;
                    MessageBox.Show("Noboy winds !");
                }

                NewGame();
            }
            #endregion

        }
        #endregion


        
    }
}
