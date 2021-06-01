using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORGPrintersForRent
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OpenExcelFile();
                ORGPrintersForRent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void OpenExcelFile()
        {
            if(File.Exists(@"\\orgachim.bg\share\Incess\Printers for Rent.xlsx"))
                Process.Start(@"\\orgachim.bg\share\Incess\Printers for Rent.xlsx");
            else
            {
                Console.WriteLine("Printers for rent file not found ! ");
            }
        }

        static void ORGPrintersForRent()
        {
            if (File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe"))
            {
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "172.30.4.84");
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "172.30.4.15");
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "172.30.4.60");
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "172.30.4.59");
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "172.30.4.78");
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "172.30.4.28");
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "172.30.4.85");
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "172.30.4.76");
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "172.30.4.45");
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "172.30.4.82");
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "172.30.4.51");
            }
            else
            {
                Console.WriteLine("No valid browsers found !");
                Console.WriteLine("Press any key to exit..");
                Console.ReadKey();
            }

        }
    }
}
