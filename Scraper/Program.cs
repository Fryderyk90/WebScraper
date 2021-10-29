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
            //InetScraper();

            //WebhallenScrap();

            //KomplettScrap();

            lib.Inet.IData inetData = new lib.Inet.Aggregation.Data();
            lib.Webhallen.IData wehallenData = new lib.Webhallen.Aggregation.Data();
            lib.Komplett.IData komplettData = new lib.Komplett.Aggregation.Data();

            var inetList = inetData.AllItems();
            var webhallenList = wehallenData.AllItems();
            var komplettList = komplettData.AllItems();

            ScraperClient client = new ScraperClient();

            Console.WriteLine("<<<<<<<<<<<<<INET>>>>>>>>>>>");
            client.DisplayItems(inetList);
            Console.WriteLine("<<<<<<<<<<<<<WEBHALLEN>>>>>>>>>>>");
            client.DisplayItems(webhallenList);
            Console.WriteLine("<<<<<<<<<<<<<KOMPLETT>>>>>>>>>>>");
            client.DisplayItems(komplettList);
        }

       
    }
}
