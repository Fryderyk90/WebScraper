using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Scraper.lib.Client
{
    public class ScraperClient
    {

        public IWebDriver WebDriver()
        {
            
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments("--headless");
            IWebDriver driver = new FirefoxDriver(firefoxOptions);
            return driver;
        }

        public void Close(WebDriver driver)
        {
            driver.Close();
        }
       
        public void ScrollPage(IWebDriver driver)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            try
            {
                long lastHeight = (long)javaScriptExecutor.ExecuteScript("return document.body.scrollHeight");

                while (true)
                {
                    javaScriptExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                    Thread.Sleep(2000);

                    long newHeight = (long)javaScriptExecutor.ExecuteScript("return document.body.scrollHeight");
                    if (newHeight == lastHeight)
                    {
                        break;
                    }
                    lastHeight = newHeight;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        
        public void DisplayItems(List<Item> itemList)
        {
            foreach (var item in itemList)
            {
                Console.WriteLine($"Product Name: {item.Name}\nProduct Price: {item.Price}\nProduct Link: {item.ProductLink}\nProduct stock: {item.Stock}\nStore: {item.Store}");
                Console.WriteLine();
            }
        }
        
        public double PriceNormalizer(string unnormalizedPrice)
        {
            string onlyNumbers = ExtractNumbers(unnormalizedPrice);

            double price;
            double.TryParse(onlyNumbers.Trim().ToCharArray(), out price);

            return price;
        }
        public int StockNormalizer(string unnormalizedStock)
        {
            var stock = 0;
            
            return stock;
        }
        public string ExtractNumbers(string textWithNumbers)
        {
            return Regex.Match(String.Concat(textWithNumbers
            .Where(c => !Char.IsWhiteSpace(c))), @"\d+").Value;
        }
    }
}
