using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TO_Bot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool trackHpMp = false;
        public int playerHP;
        public int playerMP;


        public MainWindow()
        {
            InitializeComponent();
            SetBG();
            Timer();
        }

        private void SetBG()
        {
            string BgPath = Directory.GetCurrentDirectory() + @"\assets\Art\bg.png";
            BitmapImage bmp = new BitmapImage(new Uri(BgPath));
            bgImg.ImageSource = bmp;
        }

        #region ScriptBtns

        private void runScriptBtn_Click(object sender, RoutedEventArgs e)
        {
            logTB.Text += "Press \"F5\" to start the script" + Environment.NewLine;
            logTB.Text += "Press \"F6\" to stop the script" + Environment.NewLine;
            logTB.Text += Environment.NewLine;
            logTB.ScrollToEnd();
            StartBotScript();
        }

        private void StartBotScript()
        {
            string combatScriptPath = Directory.GetCurrentDirectory() + @"\assets\Scripts\Combat.ahk";
            
            Process.Start(combatScriptPath);
        }

        private void closeScriptBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseBotScript();
        }

        private void CloseBotScript()
        {
            foreach (var process in Process.GetProcessesByName("AutoHotkey"))
            {
                logTB.Text += Environment.NewLine + "Closing TO_script.ahk" + Environment.NewLine;
                logTB.ScrollToEnd();

                try
                {
                    process.Kill();
                    logTB.Text += "\"TO_script.ahk\" closed successfully" + Environment.NewLine;
                    logTB.Text += Environment.NewLine;
                    logTB.ScrollToEnd();
                }
                catch (Exception e)
                {

                    logTB.Text += Environment.NewLine + e.Message;
                    logTB.Text += Environment.NewLine;
                    logTB.ScrollToEnd();
                }
            }
        }

        private void editScriptBtn_Click(object sender, RoutedEventArgs e)
        {
            string scriptFile = Directory.GetCurrentDirectory() + @"\assets\Scripts\Combat.ahk";

            Process.Start("notepad.exe", scriptFile);
        }

        #endregion

        #region MemoryRead

        private void MemRead()
        {
            string gameName = "client";

            Process pname = Process.GetProcessesByName(gameName).FirstOrDefault();
            VAMemory proc = new VAMemory(gameName);

            if (pname != null && proc != null)
            {
                ReadPlayerHpFromMemory(gameName, pname, proc);
                ReadPlayerMpFromMemory(gameName, pname, proc);
            }
            else
            {
                playerHPLBL.Content = "Game is not started.";
                playerMPLBL.Content = "Game is not started.";
                foreach (var process in Process.GetProcessesByName("AutoHotkey"))
                {
                    process.Kill();
                }
                return;
            }
        }

        private void ReadPlayerHpFromMemory(string gname, Process gproc, VAMemory procVam)
        {


            IntPtr baseAddress = gproc.MainModule.BaseAddress + 0x00C36464;


            IntPtr base1 = IntPtr.Add((IntPtr)procVam.ReadInt32(baseAddress), 0x2c);
            IntPtr base2 = IntPtr.Add((IntPtr)procVam.ReadInt32(base1), 0x8);
            IntPtr base3 = IntPtr.Add((IntPtr)procVam.ReadInt32(base2), 0x24);
            IntPtr base4 = IntPtr.Add((IntPtr)procVam.ReadInt32(base3), 0x64);
            IntPtr base5 = IntPtr.Add((IntPtr)procVam.ReadInt32(base4), 0x8);
            IntPtr base6 = IntPtr.Add((IntPtr)procVam.ReadInt32(base5), 0x88C);
            IntPtr base7 = IntPtr.Add((IntPtr)procVam.ReadInt32(base6), 0x3B8);

            var pHP = procVam.ReadInt32(base7);

            playerHP = Convert.ToInt32(pHP.ToString());

            playerHPLBL.Content = "HP: " + pHP.ToString();

            if (setLowHPTB.Text.Length > 0 && setLowHPTB.Text != null)
            {
                int lowHpTreshold = Convert.ToInt32(setLowHPTB.Text);
                if (pHP < lowHpTreshold && pHP > 5)
                {
                    logTB.Text += "!!! Your HP is low !!!" + Environment.NewLine;
                    logTB.Text += "!!! Your HP is low !!!" + Environment.NewLine;
                    logTB.ScrollToEnd();
                    DrinkPotion("hp", playerHP);
                }
            }
        }

        private void ReadPlayerMpFromMemory(string gname, Process gproc, VAMemory procVam)
        {


            IntPtr baseAddress = gproc.MainModule.BaseAddress + 0x00D1EB7C;


            IntPtr base1 = IntPtr.Add((IntPtr)procVam.ReadInt32(baseAddress), 0x30);
            IntPtr base2 = IntPtr.Add((IntPtr)procVam.ReadInt32(base1), 0x20);
            IntPtr base3 = IntPtr.Add((IntPtr)procVam.ReadInt32(base2), 0x44);
            IntPtr base4 = IntPtr.Add((IntPtr)procVam.ReadInt32(base3), 0x30);
            IntPtr base5 = IntPtr.Add((IntPtr)procVam.ReadInt32(base4), 0x4C);
            IntPtr base6 = IntPtr.Add((IntPtr)procVam.ReadInt32(base5), 0x4);
            IntPtr base7 = IntPtr.Add((IntPtr)procVam.ReadInt32(base6), 0x324);

            var pMP = procVam.ReadInt32(base7);

            playerMP = Convert.ToInt32(pMP.ToString());

            playerMPLBL.Content = "MP: " + pMP.ToString();

            if (setLowMPTB.Text.Length > 0 && setLowHPTB.Text != null)
            {
                int lowHpTreshold = Convert.ToInt32(setLowHPTB.Text);
                if (pMP < lowHpTreshold && pMP > 5)
                {
                    logTB.Text += "!!! Your MP is low !!!" + Environment.NewLine;
                    logTB.Text += "!!! Your MP is low !!!" + Environment.NewLine;
                    logTB.ScrollToEnd();
                    DrinkPotion("mp", playerMP);
                }
            }
        }

        #endregion

        #region StatsUpdating

        private void Timer()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcherTimer.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            string gameName = "client";

            Process pname = Process.GetProcessesByName(gameName).FirstOrDefault();
            VAMemory proc = new VAMemory(gameName);

            if (pname != null && proc != null)
            {
                CloseAhkIfPlayerIsDead();
                MemRead();
                CombatScriptLoopCoutner();
            }
            
        }

        private void DrinkPotion(string lowResource, int resourceValue)
        {
            if (lowResource == "hp" || lowResource == "mp")
            {
                if (lowResource == "hp")
                    HealUp();
            }
        }

        private void HealUp()
        {
            string bottingScriptPath = Directory.GetCurrentDirectory() + @"\assets\Scripts\Combat.ahk";
            string autoStartBottingScriptPath = Directory.GetCurrentDirectory() + @"\assets\Scripts\autoStartBot.vbs";
            string emergencyScriptPath = Directory.GetCurrentDirectory() + @"\assets\Scripts\emergencyHP.ahk";
            Process emergencyScript;

            foreach (var process in Process.GetProcessesByName("AutoHotkey"))
            {
                process.Kill();
            }

            emergencyScript = Process.Start(emergencyScriptPath);
            emergencyScript.WaitForExit();

            Process.Start(bottingScriptPath);
            Process.Start(autoStartBottingScriptPath);
        }

        private void CombatScriptLoopCoutner()
        {
            string line;
            string counterFile = System.IO.Path.GetTempPath() + @"\1.txt";
            if (!File.Exists(counterFile))
            {
                counterlbl.Content = "0";
                return;
            }

            var fileStream = new FileStream(counterFile, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream))
            {
                
                while ((line = streamReader.ReadLine()) != null)
                {
                    counterlbl.Content = line.ToString();
                }
            }
        }

        private void CloseAhkIfPlayerIsDead()
        {
            if(playerHP < 1)
            {
                foreach (var process in Process.GetProcessesByName("AutoHotkey"))
                {
                    process.Kill();
                }
            }
        }
        #endregion

        #region TBinputFilter

        private void setLowHPTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void setLowMPTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }


        private void textBox_PreviewExecutedHP(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void textBox_PreviewExecutedMP(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region MeleeOrCaster

        private void Caster(object sender, RoutedEventArgs e)
        {
            HideorShowCasterSection(true);
        }

        private void Mele(object sender, RoutedEventArgs e)
        {
            HideorShowCasterSection(false);
        }

        private void HideorShowCasterSection(bool show)
        {
            if (show)
            {
                setLowMPTB.Visibility = Visibility.Visible;
                playerMPLBL.Visibility = Visibility.Visible;
                setLowMPlbl.Visibility = Visibility.Visible;
            }
            if(!show)
            {
                setLowMPTB.Visibility = Visibility.Hidden;
                playerMPLBL.Visibility = Visibility.Hidden;
                setLowMPlbl.Visibility = Visibility.Hidden;
            }
        }
        #endregion

    }
}
