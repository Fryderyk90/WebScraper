﻿using HtmlAgilityPack;
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

            //WebhallenScrap();


        }

        private static void WebhallenScrap()
        {
            var webhallenScraper = new WebhallenScrap();
            var productList = webhallenScraper.GetCards().Where(p => p.Name.Contains("3080")).ToList();
            webhallenScraper.DisplayItems(productList);

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