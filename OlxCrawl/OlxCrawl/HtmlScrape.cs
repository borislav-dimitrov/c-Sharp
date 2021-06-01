using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Windows;

namespace OlxCrawl
{
    public static class HtmlScrape
    {
        public static string output = "" ;

        public static async void HTML_Scrape(string url, string keywords, string minPrice, string maxPrice)
        {
            List<string> offers = new List<string>();
            List<string> offersLinks = new List<string>();
            List<string> offersPostDate = new List<string>();


            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            
            var offersHtml = htmlDocument.DocumentNode.Descendants("table")
                .Where(node => node.GetAttributeValue("id","")
                .Equals("offers_table")).ToList();

            #region GetOffers

            var offersListItems = offersHtml[0].Descendants("strong").ToList();

            foreach (var offersListItem in offersListItems)
            {
                offers.Add(offersListItem.InnerText);
            }

            #endregion

            #region GetOffersPostDate

            var offersPostDateList = offersHtml[0].Descendants("span").ToList();
            foreach(var item in offersPostDateList)
            {
                if(item.InnerHtml.Length > 0)
                {
                    if (item.InnerHtml.Contains("location-filled") || item.InnerHtml.Contains("clock"))
                    {
                        string[] splitForTimeAndLocation = item.InnerHtml.Split('>');
                        int counter = splitForTimeAndLocation.Length - 1;
                        offersPostDate.Add(splitForTimeAndLocation[counter]);

                    }
                }
            }

            #endregion

            #region GetLinks

            string lookingForLinks = offersHtml[0].InnerHtml.ToString();
            string[] splittedLookingForLinks = lookingForLinks.Split('=');

            foreach (var item in splittedLookingForLinks)
            {
                if (item.Contains("https://www.olx.bg/ad/"))
                {
                    var tmpLink = item.Remove(0, 1);
                    string[] splittedTmpLink = tmpLink.Split(';');
                    offersLinks.Add(splittedTmpLink[0].ToString());
                }
            }

            offersLinks = ClearDublicatesInAList(offersLinks);

            #endregion

            ArrangeOutput(offers, offersLinks, offersPostDate, keywords, minPrice, maxPrice);

            Console.WriteLine();
        }

        public static void ArrangeOutput(List<string> listOffers, List<string> listLinks, List<string> listWhenAndWhere, string keywords, string minPrice, string maxPrice)
        {
            int counterForLinks = 0;

            output += "<br><hr><hr><hr><br>";
            output += $"Looking for: \"{keywords}\" with min price {minPrice} and max price {maxPrice}<br>";
            output += "<br><hr><hr><hr><br>";

            foreach (var item in listOffers)
            {

                if (item.Contains("лв"))
                {
                    int currentItemCount = listOffers.IndexOf(item);
                    output += item + "<br>";
                    output += listWhenAndWhere[currentItemCount - 1] + "<br>";
                    output += listWhenAndWhere[currentItemCount] + "<br>";
                    output += "Link: " + listLinks[counterForLinks].ToString() + "<br><br><hr><br>";
                    counterForLinks++;
                }
                else
                {
                    output += item + "<br>";
                }
            }

            
            

        }

        public static List<string> ClearDublicatesInAList(List<string> list)
        {
            List<string> uniqueList = list.Distinct().ToList();

            return uniqueList;
        }
       
    }
}
