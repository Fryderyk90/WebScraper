using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Scraper
{
    public  class Program
    {
        static void Main(string[] args)
        {
            // InetScraper();

            var webhallen = new WebhallenScrap();
            var driver = webhallen.WebDriver();
            webhallen.NavigateToWebhallen(driver);
            webhallen.ScrollPage(driver);
            
            var webhallenProducts = webhallen.WebhallenProducts(driver);
            var productList = webhallen.WebhallenItemList(webhallenProducts);
            Console.WriteLine();


        }

        private static void InetScraper()
        {
            var inet = new InetScrap();

            var driver = inet.WebDriver();

            inet.NavigateToInet(driver);

            inet.ScrollPage(driver);

            var inetProducts = inet.InetProducts(driver);

            var productList = inet.InetItemList(inetProducts);

            inet.DisplayItems(productList);
        }
    }
}
