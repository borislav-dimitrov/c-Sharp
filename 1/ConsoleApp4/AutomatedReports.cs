using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;


namespace Incess_Reports
{
    public static class AutomatedReports
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);


        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;

        

        public static string output = "4 , 01-01-2020 , 10:10 , 10:20 , asd , asdasda ," +
            " 3 , 01-03-2021 , 10:00 , 12:00 , plamen.test , proba ," +
            " 5 , 02-01-2020 , 20:20 , 20:30 , asldasl , sdlldl ," +
            " 1 , 16-03-2021 , 10:10 , 10:25 , incess , test report 1@# ," +
            " 2 , 17-03-2021 , 12:00 , 12:15 , incess, creating app ," +
            " 6 , 17-03-2021 , 08:45 , 09:00 , pep , papappa ," +
            " 7 , 17-03-2021 , 09:30 , 10:00 , asdf , lslsl123123 ," +
            " 8 , 17-03-2021 , 9:45 , 9:55 , asd , asdasdasd ," +
            " 9 , 17-03-2021 , 9:10 , 9:30 , asd , q , ";

        public static List<Report> reportsList = new List<Report>();

        public static void Automate()
        {
            MouseClick(-1000, 320);
            Thread.Sleep(200);
            MouseClick(-1000, 320);
            Thread.Sleep(200);
            SendKey();
            //StoreReportsInList(5);
        }

        public static void StoreReportsInList(int columnNumber)
        {
            string[] splittedOutput = output.Split(',');
            
            int counter = 0;

            

            while (counter < splittedOutput.Length)
            {
                try
                {
                    Report newReport = new Report(
                    splittedOutput[counter], splittedOutput[counter + 1], splittedOutput[counter + 2],
                    splittedOutput[counter + 3], splittedOutput[counter + 4], splittedOutput[counter + 5]);

                    reportsList.Add(newReport);
                }
                catch 
                { }

                counter += columnNumber + 1;
            }
            
        }


        private static void MouseClick(int x, int y)
        {
            SetCursorPos(0, 0);
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private static void SendKey()
        {
            
        }

    }
}
