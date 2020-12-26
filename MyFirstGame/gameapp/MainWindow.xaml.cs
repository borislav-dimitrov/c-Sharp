using My_app_lib;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Player _p1;
        public Drawing _draw = new Drawing();
        
        public MainWindow()
        {
            WorldBuilder newWorld = new WorldBuilder();
            newWorld.buildWorld();
            

            InitializeComponent();
            
            gameScreen.Effect = new BlurEffect();
            charCreation.Visibility = Visibility.Visible;
            
        }




        #region updatePlayerInfo

        private void updatePlayerInfo(Player _p1)
        {

            lblPlayerName.Content = _p1.Name.ToString();
            lblPlayerHP.Content = _p1.CurrHP.ToString();
            lblPlayerMinDMG.Content = _p1.MinDMG.ToString();
            lblPlayerMaxDMG.Content = _p1.MaxDMG.ToString();
            lblPlayerExp.Content = _p1.CurrEXP.ToString();
            lblPlayerLvl.Content = _p1.Level.ToString();
        }
        #endregion

        #region sendAtHome

        private void sendAtHome(Player _p1)
        {
            
            _p1.currentLocation = WorldBuilder.LocationByID(WorldBuilder.LOC_ID_HOME);
            updateLocation(_p1);
            _p1.CurrHP = _p1.MaxHP / 2;
            
        }
        #endregion

        #region updateLocationInfo

        private void updateLocation(Player _p1)
        {
            lblLocation.Content = _p1.currentLocation.Name.ToString() + " - " +
                _p1.currentLocation.Description.ToString();
            drawLocation(_p1);
        }


        #region drawLocation

        private void drawLocation(Player _p1)
        {
            Drawing drawing = new Drawing();
            drawing.drawCurrLocation(drawScene, _p1.currentLocation);
        }
        #endregion

        #endregion

        #region characterCreation

        private void btnCreateChar_Click(object sender, RoutedEventArgs e)
        {
            if (tbCharName.Text == "")
            {
                MessageBox.Show("Input a name please");
            }
            else
            {
                _p1 = new Player(1, tbCharName.Text.ToString(), 50, 50, 1, 3, 0, 1);
                updatePlayerInfo(_p1);
                sendAtHome(_p1);
                charCreation.Visibility = Visibility.Hidden;
                gameScreen.Effect = null;
            }
            

        }

        #endregion

        #region showMap

        private void showMap()
        {
            _draw.drawMap(drawScene,_p1);
        }
        #endregion

        private void btnMap_Click(object sender, RoutedEventArgs e)
        {
            showMap();
        }

        private void drawScene_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _draw.clearCanvas(drawScene);
            updateLocation(_p1);
        }

        private void btnMoveNorth_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMoveWest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMoveSouth_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
