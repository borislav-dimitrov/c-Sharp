using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OldReportingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            UltimateDecision();
        }

        static int CheckUserInput()
        {
            int checkedInput = 0;
            Regex checkInput = new Regex("^[1-2]+$");

            while (true)
            {

                string uInput = Console.ReadLine();

                if (checkInput.IsMatch(uInput))
                {
                    checkedInput = Convert.ToInt32(uInput);
                    return checkedInput;
                }
                else
                {
                    Console.WriteLine("Valid input is only 1 and 2 !");
                }
            }
        }

        static void UltimateDecision()
        {
            Console.WriteLine("Enter 1 to use the OLD old Reporting (1.68)");
            Console.WriteLine("Enter 2 to use the NEW old Reporting (1.49)");
            int uInput = CheckUserInput();

            if (uInput == 1)
                ChangeToOLDold();
            if (uInput == 2)
                ChangeToNEWold();
        }

        static void ChangeToOLDold()
        {
            string currUser = Environment.UserName.ToString();

            if (File.Exists($@"C:\Users\{currUser}\.jorgachim\client.properties"))
                ChangeToOLDOldReportingIpFromNonVDI();
            else if (File.Exists($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties"))
                ChangeToOLDOldReportingIpFromVDI();
            else
            {
                Console.WriteLine("Path not found :( ..\nPress key to exit..");
                Console.ReadKey();
            }

        }

        static void ChangeToNEWold()
        {

            string currUser = Environment.UserName.ToString();

            if (File.Exists($@"C:\Users\{currUser}\.jorgachim\client.properties"))
                ChangeToNEWOldReportingIpFromNonVDI();
            else if (File.Exists($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties"))
                ChangeToNEWOldReportingIpFromVDI();
            else
            {
                Console.WriteLine("Path not found :( ..\nPress key to exit..");
                Console.ReadKey();
            }
        }

        #region ChangeToOLDoldReporting

        private static void ChangeToOLDOldReportingIpFromNonVDI()
        {
            string currUser = Environment.UserName.ToString();
            string replace = "";

            try
            {
                using (StreamReader sr = new StreamReader
                                                ($@"C:\Users\{currUser}\.jorgachim\client.properties"))
                {
                    do
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("url.endpoint=http"))
                        {
                            replace += @"url.endpoint=http\://172.30.1.68\:8080/JRepServices" + Environment.NewLine;
                        }
                        else
                            replace += line + Environment.NewLine;
                    } while (sr.EndOfStream == false);
                }
                System.IO.File.WriteAllText($@"C:\Users\{currUser}\.jorgachim\client.properties", replace);
                replace = string.Empty;
                Console.WriteLine("Done...");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch
            {

                Console.WriteLine("Something went wrong :(");
                Console.ReadKey();
            }
        }

        private static void ChangeToOLDOldReportingIpFromVDI()
        {
            string currUser = Environment.UserName.ToString();
            string replace = "";

            try
            {
                using (StreamReader sr = new StreamReader
                                                ($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties"))
                {
                    do
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("url.endpoint=http"))
                        {
                            replace += @"url.endpoint=http\://172.30.1.68\:8080/JRepServices" + Environment.NewLine;
                        }
                        else
                            replace += line + Environment.NewLine;
                    } while (sr.EndOfStream == false);
                }
                System.IO.File.WriteAllText($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties", replace);
                replace = string.Empty;
                Console.WriteLine("Done...");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch
            {

                Console.WriteLine("Something went wrong :(");
                Console.ReadKey();
            }
        }
        #endregion

        #region ChangeToNEWoldReporting


        static void ChangeToNEWOldReportingIpFromNonVDI()
        {
            string currUser = Environment.UserName.ToString();
            string replace = "";

            try
            {
                using (StreamReader sr = new StreamReader
                                                    ($@"C:\Users\{currUser}\.jorgachim\client.properties"))
                {
                    do
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("url.endpoint=http"))
                        {
                            replace += @"url.endpoint=http\://172.30.1.49\:8080/JRepServices" + Environment.NewLine;
                        }
                        else
                            replace += line + Environment.NewLine;
                    } while (sr.EndOfStream == false);
                }
                System.IO.File.WriteAllText($@"C:\Users\{currUser}\.jorgachim\client.properties", replace);
                replace = string.Empty;
                Console.WriteLine("Done...");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Something went wrong :(");
                Console.ReadKey();
            }
        }

        static void ChangeToNEWOldReportingIpFromVDI()
        {
            string currUser = Environment.UserName.ToString();
            string replace = "";

            try
            {
                using (StreamReader sr = new StreamReader
                                                    ($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties"))
                {
                    do
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("url.endpoint=http"))
                        {
                            replace += @"url.endpoint=http\://172.30.1.49\:8080/JRepServices" + Environment.NewLine;
                        }
                        else
                            replace += line + Environment.NewLine;
                    } while (sr.EndOfStream == false);
                }
                System.IO.File.WriteAllText($@"\\orgachim.bg\users\desktops\{currUser}\.jorgachim\client.properties", replace);
                replace = string.Empty;
                Console.WriteLine("Done...");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Something went wrong :(");
                Console.ReadKey();
            }
        }
        #endregion
    }
}
