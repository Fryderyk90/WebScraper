using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    public class WebhallenScrap : ScraperClient
    {

        public IWebDriver NavigateToWebhallen(IWebDriver _driver)
        {
            _driver.Navigate().GoToUrl("https://www.webhallen.com/se/category/4684-GeForce-GTXRTX?page=4&f=attributes%5E110-1-NVIDIA%2BGeForce%2BRTX%2B3080~NVIDIA%2BGeForce%2BRTX%2B3070");



            return _driver;
        }

        public ReadOnlyCollection<IWebElement> WebhallenProducts(IWebDriver driver)
        {
            return driver.FindElements(By.XPath("//div[@class='show-buy-btn panel-body']"));

        }

        public List<Item> WebhallenItemList(ReadOnlyCollection<IWebElement> webhallenProducts)
        {
            var itemList = new List<Item>();

            foreach (var product in webhallenProducts)
            {
                var item = new Item
                {
                    Name = product.FindElement(By.XPath(".//span[@class='fixed-lines product-list-item-title title-height']/a")).Text,
                    Price = product.FindElement(By.XPath(".//div[@class='price-value _right']/span")).Text,
                    Stock = product.FindElement(By.Id("web_stock")).GetAttribute("title").ToString()
                };
                itemList.Add(item);
            }


            return itemList;
        }


    }
        
}

