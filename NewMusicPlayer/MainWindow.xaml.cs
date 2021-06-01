using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;


namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region public variables

        public List<string> openedFilesPath = new List<string>();
        public List<string> openedFilesNames = new List<string>();
        public int counter = 0;
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public bool PauseFlag = false;
        public TimeSpan pauza;
        public int getIndexOfSelectedSong;
        public bool muteIsOn = false;
        
        #endregion

        #region default constructor       

        public MainWindow()
        {

            
            InitializeComponent();

            #region load images for buttons
            string currentPath = Directory.GetCurrentDirectory();
            Uri uri = new Uri($"{currentPath}\\GUI\\backward-48.ico", UriKind.RelativeOrAbsolute);
            ImageSource imgSource = new BitmapImage(uri);
            backwardIMG.Source = imgSource;

            currentPath = Directory.GetCurrentDirectory();
            uri = new Uri($"{currentPath}\\GUI\\play-48.ico", UriKind.RelativeOrAbsolute);
            imgSource = new BitmapImage(uri);
            playIMG.Source = imgSource;

            currentPath = Directory.GetCurrentDirectory();
            uri = new Uri($"{currentPath}\\GUI\\pause-48.ico", UriKind.RelativeOrAbsolute);
            imgSource = new BitmapImage(uri);
            pauseIMG.Source = imgSource;

            currentPath = Directory.GetCurrentDirectory();
            uri = new Uri($"{currentPath}\\GUI\\stop-48.ico", UriKind.RelativeOrAbsolute);
            imgSource = new BitmapImage(uri);
            stopIMG.Source = imgSource;

            currentPath = Directory.GetCurrentDirectory();
            uri = new Uri($"{currentPath}\\GUI\\forward-48.ico", UriKind.RelativeOrAbsolute);
            imgSource = new BitmapImage(uri);
            forwardIMG.Source = imgSource;

            currentPath = Directory.GetCurrentDirectory();
            uri = new Uri($"{currentPath}\\GUI\\add-48.ico", UriKind.RelativeOrAbsolute);
            imgSource = new BitmapImage(uri);
            addIMG.Source = imgSource;

            currentPath = Directory.GetCurrentDirectory();
            uri = new Uri($"{currentPath}\\GUI\\unmute-48.ico", UriKind.RelativeOrAbsolute);
            imgSource = new BitmapImage(uri);
            muteIMG.Source = imgSource;

            currentPath = Directory.GetCurrentDirectory();
            uri = new Uri($"{currentPath}\\GUI\\equalizer.mp4", UriKind.RelativeOrAbsolute);
            media.Source = uri;

            currentPath = Directory.GetCurrentDirectory();
            uri = new Uri($"{currentPath}\\GUI\\1.ico", UriKind.RelativeOrAbsolute);
            imgSource = new BitmapImage(uri);
            MyPlayer.Icon = imgSource;

            #endregion
            mediaPlayer.MediaEnded += new EventHandler(media_ended);
            mediaPlayer.MediaOpened += new EventHandler(media_opened);
        }

        #endregion

        #region equalizer loop

        private void media_Loaded(object sender, RoutedEventArgs e)
        {
            media.Play();
            media.Stop();
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            media.Position = TimeSpan.FromSeconds(0);
        }

        #endregion

        #region load files button
        
        private void add_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Select mp3";

            if (openFileDialog.ShowDialog() == true)
            {
                string[] openFilesPath = openFileDialog.FileNames;              
                
                try
                {
                    while (counter <= openFilesPath.Count())
                    {
                        try
                        {
                            openedFilesPath.Add(openFilesPath[counter]);
                            string selectedFile = openFilesPath[counter].ToString();
                            string[] splitted = selectedFile.Split('\\');
                            playlist.Items.Add(splitted.Last());
                            openedFilesNames.Add(splitted.Last());
                            
                        }
                        catch 
                        {
                            //MessageBox.Show(exc.Message);
                        }
                        counter++;
                    }
                    counter = 0;
                }
                catch (Exception excc)
                {
                    MessageBox.Show(excc.Message);
                }
                //MessageBox.Show(count[0]);
                //

            }
        }

        #endregion

        #region player buttons

        #region previous button
        
        private void backward_click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (playlist.SelectedIndex >= 0 && playlist.SelectedIndex <= openedFilesNames.Count)
                {
                    
                    try
                    {
                        string selectedSong = playlist.SelectedItem.ToString();
                        if (openedFilesNames.Contains(selectedSong))
                        {
                            int getIndexOfSelectedSong = openedFilesNames.IndexOf(selectedSong);
                            //MessageBox.Show(openedFilesPath[getIndexOfSelectedSong]);
                            mediaPlayer.Open(new Uri(openedFilesPath[getIndexOfSelectedSong - 1]));
                            mediaPlayer.Play();
                            playlist.SelectedIndex = getIndexOfSelectedSong - 1 ;

                        }
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }


        }

        #endregion

        #region next button

        private void forward_click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (playlist.SelectedIndex >= 0 && playlist.SelectedIndex <= openedFilesNames.Count)
                {
                    
                    try
                    {
                        string selectedSong = playlist.SelectedItem.ToString();
                        if (openedFilesNames.Contains(selectedSong))
                        {
                            int getIndexOfSelectedSong = openedFilesNames.IndexOf(selectedSong);
                            //MessageBox.Show(openedFilesPath[getIndexOfSelectedSong]);
                            mediaPlayer.Open(new Uri(openedFilesPath[getIndexOfSelectedSong + 1]));
                            mediaPlayer.Play();
                            playlist.SelectedIndex = getIndexOfSelectedSong + 1;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }

        #endregion

        #region play button


        private void play_click(object sender, RoutedEventArgs e)
        {
            
            if (PauseFlag)
            {
                media.Play();
                mediaPlayer.Play();
                pauza = TimeSpan.Zero;
                PauseFlag = false;
            }
            else
            {
                try
                {
                    string selectedSong = playlist.SelectedItem.ToString();
                    if (openedFilesNames.Contains(selectedSong))
                    {
                        getIndexOfSelectedSong = openedFilesNames.IndexOf(selectedSong);
                        //MessageBox.Show(openedFilesPath[getIndexOfSelectedSong]);
                        mediaPlayer.Open(new Uri(openedFilesPath[getIndexOfSelectedSong]));
                        mediaPlayer.Play();
                        media.Play();

                        
                        //playlist.SelectedIndex = getIndexOfSelectedSong;
                        
                        
                    }
                    else
                    {

                    }
                }
                catch
                {
                    if (playlist.Items.Count >= 1)
                    {
                        mediaPlayer.Open(new Uri(openedFilesPath[0]));
                        mediaPlayer.Play();
                        media.Play();
                        playlist.SelectedIndex = 0;

                    }
                    else
                    {
                        MessageBox.Show("You have not selected any songs!");
                    }



                }
            }

        }


        #endregion

        #region stop button

        
        private void stop_click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            media.Stop();
        }


        #endregion

        #region pause button

        private void pause_click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            pauza = mediaPlayer.Position;
            media.Stop();
            PauseFlag = true;
        }


        #endregion

        #region mute button

        private void mute_click(object sender, RoutedEventArgs e)
        {
            //double currVolume = mediaPlayer.Volume;
            string currentPath = Directory.GetCurrentDirectory();
            Uri uri = new Uri($"{currentPath}\\GUI\\backward-48.ico", UriKind.RelativeOrAbsolute);
            ImageSource imgSource = new BitmapImage(uri);
            


            if (muteIsOn is false)
            {
                
                muteIsOn = true;
                mediaPlayer.Volume = 0;
                uri = new Uri($"{currentPath}\\GUI\\mute-48.ico", UriKind.RelativeOrAbsolute);
                imgSource = new BitmapImage(uri);
                muteIMG.Source = imgSource;

            }
            else
            {
                muteIsOn = false;
                mediaPlayer.Volume = 1;
                uri = new Uri($"{currentPath}\\GUI\\unmute-48.ico", UriKind.RelativeOrAbsolute);
                imgSource = new BitmapImage(uri);
                muteIMG.Source = imgSource;
            }
        }
        #endregion

        #endregion

        #region autoplay logic

        private void media_ended(object sender, EventArgs e)
        {
            try
            {
                int nowPlaying = getIndexOfSelectedSong + 1;
                mediaPlayer.Open(new Uri(openedFilesPath[nowPlaying]));
                mediaPlayer.Play();
                playlist.SelectedIndex = nowPlaying;
                
            }
            catch
            {
                mediaPlayer.Stop();
                media.Stop();
            }


            
        }
        #endregion

        #region update now playing

        private void media_opened(object sender, EventArgs e)
        {

            playlist.SelectedItem = getIndexOfSelectedSong;
            label1.Content = $"Now playing....  {playlist.SelectedItem}..";
        }

        #endregion



    }
}
