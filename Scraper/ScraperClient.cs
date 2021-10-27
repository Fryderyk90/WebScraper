using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scraper
{
    public class ScraperClient
    {
        private readonly IWebDriver _driver;

        public IWebDriver WebDriver()
        {
            IWebDriver _driver = new FirefoxDriver();


            return _driver;
        }

        public void Close(WebDriver _driver)
        {
            _driver.Close();
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
                    Thread.Sleep(1000);

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
                Console.WriteLine($"Product Name: {item.Name}\nProduct Price: {item.Price}\nProduct stock: {item.Stock}");
                Console.WriteLine();
            }
        }
        
    }
}
