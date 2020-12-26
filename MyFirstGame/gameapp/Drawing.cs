using My_app_lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    public class Drawing
    {
        private int Width = 820;
        private int Height = 650;


        public void drawCurrLocation(System.Windows.Controls.Canvas drawScene, Location currLocation)
        {

            drawScene.Width = 820;
            drawScene.Height = 650;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + $"\\images\\{currLocation.Name.ToString()}.jpg"));
            drawScene.Background = ib;
        }

        public void drawMap(System.Windows.Controls.Canvas drawScene, Player _p1)
        {
            
            clearCanvas(drawScene);

            drawScene.Width = 820;
            drawScene.Height = 650;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Map.png"));
            drawScene.Background = ib;

            drawStormwindOnMap(drawScene, _p1);
            drawHomeOnMap(drawScene, _p1);
            drawGoldShireOnMap(drawScene, _p1);
        }

        #region drawStormwindOnMap
        private void drawStormwindOnMap(System.Windows.Controls.Canvas drawScene, Player _p1)
        {
            Rectangle rectangle = new Rectangle { Width = 150, Height = 100, };
            if (_p1.currentLocation.Name == "Storm_Wind")
            {
                rectangle.Fill = Brushes.LimeGreen;
            }
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = Brushes.Black;
            
            drawScene.Children.Add(rectangle);
            System.Windows.Controls.Canvas.SetLeft(rectangle, 1 * (100 + 2));
            System.Windows.Controls.Canvas.SetTop(rectangle, 1 * (150 + 2));

            TextBlock text = new TextBlock { Width = 130, Height = 25, };
            text.Text = "Storm Wind";

            drawScene.Children.Add(text);
            System.Windows.Controls.Canvas.SetLeft(text, 1 * (115 + 2));
            System.Windows.Controls.Canvas.SetTop(text, 1 * (190 + 2));
        }
        #endregion

        #region drawHomeOnMap
        private void drawHomeOnMap(System.Windows.Controls.Canvas drawScene, Player _p1)
        {
            Rectangle rectangle = new Rectangle { Width = 150, Height = 100, };
            if (_p1.currentLocation.Name == "Home")
            {
                rectangle.Fill = Brushes.LimeGreen;
            }
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = Brushes.Black;
            
            drawScene.Children.Add(rectangle);
            System.Windows.Controls.Canvas.SetLeft(rectangle, 1 * (300 + 2));
            System.Windows.Controls.Canvas.SetTop(rectangle, 1 * (110 + 2));

            TextBlock text = new TextBlock { Width = 130, Height = 25, };
            text.Text = "Home";

            drawScene.Children.Add(text);
            System.Windows.Controls.Canvas.SetLeft(text, 1 * (315 + 2));
            System.Windows.Controls.Canvas.SetTop(text, 1 * (150 + 2));
        }
        #endregion

        #region drawGoldShireOnMap
        private void drawGoldShireOnMap(System.Windows.Controls.Canvas drawScene, Player _p1)
        {
            Rectangle rectangle = new Rectangle { Width = 150, Height = 100, };
            if (_p1.currentLocation.Name == "Gold_Shire")
            {
                rectangle.Fill = Brushes.LimeGreen;
            }
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = Brushes.Black;

            drawScene.Children.Add(rectangle);
            System.Windows.Controls.Canvas.SetLeft(rectangle, 1 * (300 + 2));
            System.Windows.Controls.Canvas.SetTop(rectangle, 1 * (250 + 2));

            TextBlock text = new TextBlock { Width = 130, Height = 25, };
            text.Text = "Gold Shire";

            drawScene.Children.Add(text);
            System.Windows.Controls.Canvas.SetLeft(text, 1 * (315 + 2));
            System.Windows.Controls.Canvas.SetTop(text, 1 * (290 + 2));
        }
        #endregion

        #region closeMap

        public void clearCanvas(System.Windows.Controls.Canvas drawScene)
        {
            drawScene.Background = Brushes.White;
            drawScene.Children.Clear();
            
        }
        #endregion
    }
}
