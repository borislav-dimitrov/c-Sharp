using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TO_Bot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            KillScripts();
            CleanTempFile();
        }

        private void KillScripts()
        {
            foreach (var process in Process.GetProcessesByName("AutoHotkey"))
            {

                try
                {
                    process.Kill();
                }
                catch
                { }
            }
        }
        
        private void CleanTempFile()
        {
            string counterFile = Path.GetTempPath() + @"\1.txt";
            if(File.Exists(counterFile))
            {
                File.Delete(counterFile);
            }

        }
    }
}
