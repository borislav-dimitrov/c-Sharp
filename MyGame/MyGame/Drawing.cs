using MyGameLib;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyGame
{
    public class Drawing
    {

        public void drawCurrLocation(Canvas drawScene, Location currLocation)
        {

            drawScene.Width = 1150;
            drawScene.Height = 970;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + $"\\images\\{currLocation.Name.ToString()}.jpg"));
            drawScene.Background = ib;
        }

        #region map

        public void drawMap(Canvas drawScene, Player _p1)
        {

            clearCanvas(drawScene);

            drawScene.Width = 1150;
            drawScene.Height = 970;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Map.png"));
            drawScene.Background = ib;

            drawStormwindOnMap(drawScene, _p1);
            drawHomeOnMap(drawScene, _p1);
            drawGoldShireOnMap(drawScene, _p1);
        }

        #region drawStormwindOnMap
        private void drawStormwindOnMap(Canvas drawScene, Player _p1)
        {
            Rectangle rectangle = new Rectangle { Width = 150, Height = 100, };
            if (_p1.currentLocation.Name == "Storm_Wind")
            {
                rectangle.Fill = Brushes.LimeGreen;
            }
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = Brushes.Black;

            drawScene.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (100 + 2));
            Canvas.SetTop(rectangle, 1 * (250 + 2));

            TextBlock text = new TextBlock { Width = 130, Height = 25, };
            text.Text = "Storm Wind";

            drawScene.Children.Add(text);
            Canvas.SetLeft(text, 1 * (115 + 2));
            Canvas.SetTop(text, 1 * (290 + 2));
        }
        #endregion

        #region drawHomeOnMap
        private void drawHomeOnMap(Canvas drawScene, Player _p1)
        {
            Rectangle rectangle = new Rectangle { Width = 150, Height = 100, };
            if (_p1.currentLocation.Name == "Start_Town")
            {
                rectangle.Fill = Brushes.LimeGreen;
            }
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = Brushes.Black;

            drawScene.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (300 + 2));
            Canvas.SetTop(rectangle, 1 * (110 + 2));

            TextBlock text = new TextBlock { Width = 130, Height = 25, };
            text.Text = "Home";

            drawScene.Children.Add(text);
            Canvas.SetLeft(text, 1 * (315 + 2));
            Canvas.SetTop(text, 1 * (150 + 2));

           
        }
        #endregion

        #region drawGoldShireOnMap
        private void drawGoldShireOnMap(Canvas drawScene, Player _p1)
        {
            Rectangle rectangle = new Rectangle { Width = 150, Height = 100, };
            if (_p1.currentLocation.Name == "Gold_Shire")
            {
                rectangle.Fill = Brushes.LimeGreen;
            }
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = Brushes.Black;

            drawScene.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (300 + 2));
            Canvas.SetTop(rectangle, 1 * (250 + 2));

            TextBlock text = new TextBlock { Width = 130, Height = 25, };
            text.Text = "Gold Shire";

            drawScene.Children.Add(text);
            Canvas.SetLeft(text, 1 * (315 + 2));
            Canvas.SetTop(text, 1 * (290 + 2));

            /////////////////////
            
            Line myLine1 = new Line();

            myLine1.Stroke = Brushes.Black;

            myLine1.X1 = 250;
            myLine1.X2 = 304;
            myLine1.Y1 = 300;
            myLine1.Y2 = 300;

            myLine1.StrokeThickness = 2;
            drawScene.Children.Add(myLine1);

            Line myLine2 = new Line();

            myLine2.Stroke = Brushes.Black;

            myLine2.X1 = 250;
            myLine2.X2 = 304;
            myLine2.Y1 = 320;
            myLine2.Y2 = 320;

            myLine2.StrokeThickness = 2;
            drawScene.Children.Add(myLine2);

            /////////////////////
            
            Line myLine3 = new Line();

            myLine3.Stroke = Brushes.Black;

            myLine3.X1 = 350;
            myLine3.X2 = 350;
            myLine3.Y1 = 210;
            myLine3.Y2 = 253;

            myLine3.StrokeThickness = 2;
            drawScene.Children.Add(myLine3);

            Line myLine4 = new Line();

            myLine4.Stroke = Brushes.Black;

            myLine4.X1 = 380;
            myLine4.X2 = 380;
            myLine4.Y1 = 210;
            myLine4.Y2 = 253;

            myLine4.StrokeThickness = 2;
            drawScene.Children.Add(myLine4);

            /////////////////////
            
            Line myLine5 = new Line();

            myLine5.Stroke = Brushes.Black;

            myLine5.X1 = 350;
            myLine5.X2 = 350;
            myLine5.Y1 = 350;
            myLine5.Y2 = 393;

            myLine5.StrokeThickness = 2;
            drawScene.Children.Add(myLine5);

            Line myLine6 = new Line();

            myLine6.Stroke = Brushes.Black;

            myLine6.X1 = 380;
            myLine6.X2 = 380;
            myLine6.Y1 = 350;
            myLine6.Y2 = 393;

            myLine6.StrokeThickness = 2;
            drawScene.Children.Add(myLine6);
        }
        #endregion

        #region closeMap

        public void clearCanvas(Canvas drawScene)
        {
            drawScene.Background = Brushes.Gray;
            drawScene.Children.Clear();

        }
        #endregion
        #endregion

        #region battleGround

        async Task taskDelay()
        {
            await Task.Delay(500);
        }

        #region bg1

        public void drawBG1(Canvas drawScene, Monster nmy)
        {
            clearCanvas(drawScene);

            drawScene.Width = 1150;
            drawScene.Height = 970;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\bg1.jpg"));
            drawScene.Background = ib;
            drawHero(drawScene);
            drawEnemy(drawScene, nmy);
        }

        public async void drawBG1HeroHitEnemy(Canvas drawScene, Monster nmy)
        {
            clearCanvas(drawScene);

            drawScene.Width = 1150;
            drawScene.Height = 970;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\bg1.jpg"));
            drawScene.Background = ib;
            heroHitEnemy(drawScene);
            drawEnemy(drawScene, nmy);

            await taskDelay();
            drawBG1(drawScene, nmy);

            if (nmy.IsAlive)
            {
                await taskDelay();
                drawBG1EnemyHitHero(drawScene, nmy);
            }
            
        }

        public async void drawBG1EnemyHitHero(Canvas drawScene, Monster nmy)
        {
            clearCanvas(drawScene);

            drawScene.Width = 1150;
            drawScene.Height = 970;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\bg1.jpg"));
            drawScene.Background = ib;
            drawHero(drawScene);
            enemyHitHero(drawScene, nmy);

            await taskDelay();
            drawBG1(drawScene, nmy);
        }
        #endregion

        #region bg2

        public void drawBG2(Canvas drawScene, Monster nmy)
        {
            clearCanvas(drawScene);

            drawScene.Width = 1150;
            drawScene.Height = 970;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\bg2.jpg"));
            drawScene.Background = ib;
            drawHero(drawScene);
            drawEnemy(drawScene, nmy);
        }

        public async void drawBG2HeroHitEnemy(Canvas drawScene, Monster nmy)
        {
            clearCanvas(drawScene);

            drawScene.Width = 1150;
            drawScene.Height = 970;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\bg2.jpg"));
            drawScene.Background = ib;
            heroHitEnemy(drawScene);
            drawEnemy(drawScene, nmy);

            await taskDelay();
            drawBG2(drawScene, nmy);
            if (nmy.IsAlive)
            {
                await taskDelay();
                drawBG2EnemyHitHero(drawScene, nmy);
            }


        }

        public async void drawBG2EnemyHitHero(Canvas drawScene, Monster nmy)
        {
            clearCanvas(drawScene);

            drawScene.Width = 1150;
            drawScene.Height = 970;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\bg2.jpg"));
            drawScene.Background = ib;
            drawHero(drawScene);
            enemyHitHero(drawScene, nmy);

            await taskDelay();
            drawBG2(drawScene, nmy);
        }
        #endregion

        #region bg3

        public void drawBG3(Canvas drawScene, Monster nmy)
        {
            clearCanvas(drawScene);

            drawScene.Width = 1150;
            drawScene.Height = 970;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\bg3.jpg"));
            drawScene.Background = ib;
            drawHero(drawScene);
            drawEnemy(drawScene, nmy);
        }

        public async void drawBG3HeroHitEnemy(Canvas drawScene, Monster nmy)
        {
            clearCanvas(drawScene);

            drawScene.Width = 1150;
            drawScene.Height = 970;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\bg3.jpg"));
            drawScene.Background = ib;
            heroHitEnemy(drawScene);
            drawEnemy(drawScene, nmy);

            await taskDelay();
            drawBG3(drawScene, nmy);
            if (nmy.IsAlive)
            {
                await taskDelay();
                drawBG3EnemyHitHero(drawScene, nmy);
            }
            
        }

        public async void drawBG3EnemyHitHero(Canvas drawScene, Monster nmy)
        {
            clearCanvas(drawScene);

            drawScene.Width = 1150;
            drawScene.Height = 970;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\bg3.jpg"));
            drawScene.Background = ib;
            drawHero(drawScene);
            enemyHitHero(drawScene, nmy);

            await taskDelay();
            drawBG3(drawScene, nmy);
        }

        #endregion

        #region drawHero

        private void drawHero(Canvas drawScene)
        {
            Rectangle rectangle = new Rectangle { Width=150, Height=300};
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Hero.png"));
            rectangle.Fill = ib;
            drawScene.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (300));
            Canvas.SetTop(rectangle, 1 * (500));
        }
        private void heroHitEnemy(Canvas drawScene)
        {
            Rectangle rectangle = new Rectangle { Width=150, Height=300};
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Hero.png"));
            rectangle.Fill = ib;
            drawScene.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (660));
            Canvas.SetTop(rectangle, 1 * (500));
        }
        #endregion

        #region drawEnemy
        private void drawEnemy(Canvas drawScene , Monster nmy)
        {
            Rectangle rectangle = new Rectangle { Width = 300, Height = 300 };
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + $"\\images\\{nmy.Name}.png"));
            rectangle.Fill = ib;
            drawScene.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (700));
            Canvas.SetTop(rectangle, 1 * (500));
        }

        private void enemyHitHero(Canvas drawScene, Monster nmy)
        {
            Rectangle rectangle = new Rectangle { Width = 300, Height = 300 };
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + $"\\images\\{nmy.Name}.png"));
            rectangle.Fill = ib;
            drawScene.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (380));
            Canvas.SetTop(rectangle, 1 * (500));
        }
        #endregion


        #endregion

        #region EquippedItems

        public void drawEquippedITems(Canvas drawEquipped)
        {
            clearCanvas(drawEquipped);

            drawEquipped.Width = 350;
            drawEquipped.Height = 250;

            drawEquippedArmor(drawEquipped);
            drawEquippedWeapon(drawEquipped);
            drawEquippedShield(drawEquipped);
            drawEquippedBoots(drawEquipped);
            drawEquippedGloves(drawEquipped);
            drawEquippedBelt(drawEquipped);
            drawEquippedHelm(drawEquipped);
        }

        
        #region drawEquippedArmor

        private void drawEquippedArmor(Canvas drawEquipped)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\BodyArmor.png"));
            Rectangle rectangle = new Rectangle {Width = 100, Height = 130 };
            rectangle.Fill = ib;
            rectangle.Name = "drawBodyArmor";
            drawEquipped.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1*(130));
            Canvas.SetTop(rectangle, 1 * (60));

        }
        #endregion

        #region drawEquippedWeapon

        private void drawEquippedWeapon(Canvas drawEquipped)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Sword.png"));
            Rectangle rectangle = new Rectangle { Width = 100, Height = 130 };
            rectangle.Fill = ib;
            rectangle.Name = "drawWeapon";
            drawEquipped.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (0));
            Canvas.SetTop(rectangle, 1 * (60));
        }
        #endregion

        #region drawEquippedShield

        private void drawEquippedShield(Canvas drawEquipped)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Shield.png"));
            Rectangle rectangle = new Rectangle { Width = 100, Height = 130 };
            rectangle.Fill = ib;
            rectangle.Name = "drawShield";
            drawEquipped.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (250));
            Canvas.SetTop(rectangle, 1 * (60));
        }
        #endregion

        #region drawEquippedBoots

        private void drawEquippedBoots(Canvas drawEquipped)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Boots.png"));
            Rectangle rectangle = new Rectangle { Width = 100, Height = 75 };
            rectangle.Fill = ib;
            rectangle.Name = "drawBoots";
            drawEquipped.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (250));
            Canvas.SetTop(rectangle, 1 * (180));
        }
        #endregion

        #region drawEquippedGloves

        private void drawEquippedGloves(Canvas drawEquipped)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Gloves.png"));
            Rectangle rectangle = new Rectangle { Width = 100, Height = 75 };
            rectangle.Fill = ib;
            rectangle.Name = "drawGloves";
            drawEquipped.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (0));
            Canvas.SetTop(rectangle, 1 * (180));
        }
        #endregion

        #region drawEquippedBelt

        private void drawEquippedBelt(Canvas drawEquipped)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Belt.png"));
            Rectangle rectangle = new Rectangle { Width = 100, Height = 45 };
            rectangle.Fill = ib;
            rectangle.Name = "drawBelt";
            drawEquipped.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (130));
            Canvas.SetTop(rectangle, 1 * (200));
        }
        #endregion

        #region drawEquippedHelm

        private void drawEquippedHelm(Canvas drawEquipped)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Helm.png"));
            Rectangle rectangle = new Rectangle { Width = 100, Height = 75 };
            rectangle.Fill = ib;
            rectangle.Name = "drawHelm";
            drawEquipped.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, 1 * (130));
            Canvas.SetTop(rectangle, 1 * (0));
        }
        #endregion

        #endregion
    }
}
