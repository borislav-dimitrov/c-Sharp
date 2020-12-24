using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MyGame
{
    class Cinema
    {
        private bool[,] seats = new bool[30, 15];
        private const int size = 16;
        private const int space = 2;

        public void drawSeats(Canvas drawMe)
        {
            for (int j = 0; j < seats.GetLength(1); j++)
            {
                for(int i = 0; i < seats.GetLength(0); i++)
                {
                    Rectangle rectangle = new Rectangle{Height = size, Width = size,};
                    rectangle.Fill = seats[i, j] ? Brushes.Red : Brushes.Green;
                    drawMe.Children.Add(rectangle);

                    Canvas.SetLeft(rectangle, i * (size + space));
                    Canvas.SetTop(rectangle, j * (size + space));
                }
            }
        }

        public void switchSeatStatus(int x, int y)
        {
            seats[x,y] = !seats[x, y];
            
                        
        }
    }
}
