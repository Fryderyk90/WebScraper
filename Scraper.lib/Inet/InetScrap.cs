using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraper.lib.Client;

namespace Scraper
{
    public class InetScrap : ScraperClient
    {
        private string ROOT = InetConstants.Root;
        // private string CATEGORY = InetConstants.ExpandCategory;
        // private string SUBCATEGORY = InetConstants.GoToCategory;
        // private string GEFORCECATEGORY = InetConstants.GoToGeforceCategory;
        private string PRODUCTLIST = InetConstants.ProductList;
        private string PRODUCTNAME = InetConstants.ProductNameTag;
        private string PRODUCTLINK = InetConstants.ProductLink;
        private string PRODUCTPRICE = InetConstants.ProductPriceCss;
        private string PRODUCTSTOCK = InetConstants.ProductStockXpath;
        private string REDUCEDPRICE = InetConstants.ReducedPrice;

        public IWebDriver NavigateToInet(IWebDriver _driver)
        {
            
            _driver.Navigate().GoToUrl(ROOT);
            // var expandCategory = _driver.FindElement(By.XPath(CATEGORY));
            // expandCategory.Click();
            // var goToCategory = _driver.FindElement(By.XPath(SUBCATEGORY));
            // goToCategory.Click();
            // var geforceCategory = _driver.FindElement(By.XPath(GEFORCECATEGORY));
            // geforceCategory.Click();
                        
            return _driver;
        }
        public List<Item> InetItemList(ReadOnlyCollection<IWebElement> ProductList)
        {
            var itemList = new List<Item>();
            foreach (var product in ProductList)
            {

                Item item = new Item()
                {
                    Name = product.FindElement(By.TagName(PRODUCTNAME)).Text,
                    ProductLink = product.FindElement(By.XPath(PRODUCTLINK)).GetAttribute("href"),
                    Price = GetPrice(product), 
                    Stock = GetStock(product),
                    Store = "Inet"
                };
                itemList.Add(item);

            }
            return itemList;

            int GetStock(IWebElement product)
            {                                              
                var stockText = product.FindElement(By.XPath(PRODUCTSTOCK)).Text;
                int stock;
                if(stockText.Contains("slut") || stockText.Contains("Okänt"))
                {
                    return 0;
                }
                else
                    int.TryParse(stockText, out stock);
                    return stock;
            }
        }

        
        private double GetPrice(IWebElement product)
        {
            try
            {//if price throws exception, its because price has been reduced and is in other Html element.
                var unnormalizedPrice = product.FindElement(By.CssSelector(PRODUCTPRICE)).Text;
                return PriceNormalizer(unnormalizedPrice);    
            }
            catch (Exception)
            {
                
                var unnormalizedReducedPrice = product.FindElement(By.XPath(REDUCEDPRICE)).Text;
                return PriceNormalizer(unnormalizedReducedPrice);
            }
        }

        public ReadOnlyCollection<IWebElement> InetProducts(IWebDriver _driver)
        {
            return _driver.FindElements(By.XPath(PRODUCTLIST));
        }

         
    }
}
