using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace seleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PrinterCounters();
        }

        static void PrinterCounters()
        {
            List<string> exclusions = new List<string>();
            exclusions.Add("enable-automation");
            exclusions.Add("enable-logging");
            

            try
            {
                // Google search test
                //string url_printer_1 = "https://www.google.com";
                //IWebDriver driver = new ChromeDriver(options);
                //var accept_cookies = driver.FindElement(By.XPath("//*[contains(text(), 'Приемам')]"));
                //accept_cookies.Click();
                //
                //var search_box = driver.FindElement(By.Name("q"));
                //search_box.SendKeys("selenium");
                //search_box.SendKeys(Keys.Return);

                main(exclusions, "http://172.30.4.60/wcd/system_counter.xml", "172_30_4_60");
                main(exclusions, "http://172.30.4.15/cgi-bin/dynamic/printer/config/reports/deviceinfo.html", "172_30_4_15");
                main(exclusions, "http://172.30.4.84/wcd/system_counter.xml", "172_30_4_84");
                main(exclusions, "http://172.30.4.78/cgi-bin/dynamic/printer/config/reports/deviceinfo.html", "172_30_4_78");
                main(exclusions, "http://172.30.4.28/wcd/system_counter.xml", "172_30_4_28");
                main(exclusions, "http://172.30.4.85/cgi-bin/dynamic/printer/config/reports/deviceinfo.html", "172_30_4_85");
                main(exclusions, "http://172.30.4.76/main/main.html", "172_30_4_76");
                //main(exclusions, "https://172.30.4.45", "172_30_4_45"); // Remont v staqta printera e offline
                main(exclusions, "http://172.30.4.82/cgi-bin/dynamic/printer/config/reports/deviceinfo.html", "172_30_4_82");
                main(exclusions, "http://172.30.4.51/main/main.html", "172_30_4_51");
                main(exclusions, "http://172.30.4.62/cgi-bin/dynamic/printer/config/reports/deviceinfo.html", "172_30_4_62");
                main(exclusions, "http://172.30.4.59/deviceIndex/index.dhtml", "172_30_4_59");
                main(exclusions, "http://172.30.4.83", "172_30_4_83");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void main(List<string> exclusions ,string url, string ssFileName) 
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArguments(exclusions);

            IWebDriver driver = new ChromeDriver(options);

            OpenUrl(driver, url);

            SolvingProblemsForDifferentPrinters(url, driver);

            ScreenShot(ssFileName, driver);

            driver.Close();
        }

        static void OpenUrl(IWebDriver driver, string url)
        {
            driver.Url = url;
        }

        static void ScreenShot(string fileName, IWebDriver driver)
        {
            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
            sc.SaveAsFile($"C://Users//incess.W500//Desktop//tonerful//{fileName}.png", ScreenshotImageFormat.Png);
        }

        static void SolvingProblemsForDifferentPrinters(string url, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            if (url.Contains("172.30.4.28") || url.Contains("172.30.4.84"))
            {
                IWebElement waitToShow = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Total (Copy + Print)')]")));
            }

            if (url.Contains("172.30.4.60"))
            {
                try
                {
                    var authentication_error = driver.FindElement(By.XPath("//*[contains(text(), 'Authentication is invalid or session expired. Please update connection.')]"));

                    if(authentication_error != null)
                    {
                        var okBtn = driver.FindElement(By.XPath("//input[@type='button']"));
                        okBtn.Click();

                        try
                        {
                            IWebElement waitToShow = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Total (Copy + Print)')]")));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Retrying..");
                            
                            driver.Navigate().GoToUrl("http://172.30.4.60/wcd/system_counter.xml");

                            IWebElement waitToShow2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Total (Copy + Print)')]")));
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }

            }

            if (url.Contains("172.30.4.59/deviceIndex/index.dhtml"))
            {
                Thread.Sleep(1000);

                driver.SwitchTo().Frame("Body Frame: Contains feature information and settings.");
                
                var selectBillingInformation = driver.FindElements(By.XPath("//*[contains(text(), 'Billing Information')]"));
                
                foreach(IWebElement element in selectBillingInformation)
                {
                    if (element.Text.ToLower().Contains("billing information"))
                    {
                        element.Click();
                    }
                }

                Thread.Sleep(1000);

                driver.SwitchTo().Frame("Body Frame: Contains feature information and settings.");

                IWebElement waitToShow2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Total Impressions:')]")));
            }

            if (url.Contains("172.30.4.83"))
            {
                var selSysManagerMode = driver.FindElement(By.Id("i0012A"));
                selSysManagerMode.Click();

                var selLoginBtn = driver.FindElement(By.Id("submitButton"));
                selLoginBtn.Click();

                var selStatusMonitor = driver.FindElement(By.XPath("//*[contains(text(), 'Status Monitor/Cancel')]"));
                selStatusMonitor.Click();

                var selCheckCounter = driver.FindElement(By.XPath("//*[contains(text(), 'Check Counter')]"));
                selCheckCounter.Click();
            }
        }


    }
}
