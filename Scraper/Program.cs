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
using Scraper.lib.Client;
using Scraper.lib.Inet.Interface;
using Scraper.lib.Webhallen;
using Data = Scraper.lib.Inet.Data;


namespace Scraper
{
    public class Program
    {

        static void Main(string[] args)
        {



            IData inetData = new Data();
            // lib.Webhallen.IData wehallenData = new lib.Webhallen.Aggregation.Data();
            // lib.Komplett.IData komplettData = new lib.Komplett.Aggregation.Data();
            // lib.DataBase.DataAccess dataAccess = new();

            var inetList = inetData.AllItems();
            // var webhallenList = wehallenData.AllItems();
             //var komplettList = komplettData.AllItems();

            ScraperClient client = new();

            Console.WriteLine("<<<<<<<<<<<<<INET>>>>>>>>>>>");
            client.DisplayItems(inetList);

            // // Console.WriteLine("<<<<<<<<<<<<<WEBHALLEN>>>>>>>>>>>");
            // // client.DisplayItems(webhallenList);
            // //
            //  Console.WriteLine("<<<<<<<<<<<<<KOMPLETT>>>>>>>>>>>");
            //  client.DisplayItems(komplettList);
            // //
            // // await dataAccess.AddDataAsync(inetList);
            // // await dataAccess.AddDataAsync(webhallenList);
            // // await dataAccess.AddDataAsync(komplettList);
        }


    }
}
