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

namespace MyGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cinema.drawSeats(drawMe);
        }

        private Cinema cinema = new Cinema();

        private void drawMe_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Rectangle)
            {
                Rectangle activeRectangle = (Rectangle)e.OriginalSource;
                double x = Canvas.GetLeft(activeRectangle);
                x = x / 18;
                double y = Canvas.GetTop(activeRectangle);
                y = y / 18;
                cinema.switchSeatStatus(Convert.ToInt32(x), Convert.ToInt32(y));
                cinema.drawSeats(drawMe);
                
            }
            
        }
    }
}
