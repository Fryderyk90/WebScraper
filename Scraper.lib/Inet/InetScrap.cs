using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Scraper.lib.Client;

namespace Scraper.lib.Inet
{
    public class InetScrap : ScraperClient
    {
        private const string Root = InetConstants.Root;
        private const string Productlist = InetConstants.ProductList;
        private const string Productname = InetConstants.ProductNameTag;
        private const string Productlink = InetConstants.ProductLink;
        private const string Productprice = InetConstants.ProductPriceCss;
        private const string Productstock = InetConstants.ProductStockXpath;
        private const string Reducedprice = InetConstants.ReducedPrice;

        public IWebDriver NavigateToInet(IWebDriver driver)
        {
            
            driver.Navigate().GoToUrl(Root);
           
                        
            return driver;
        }
        public List<Item> InetItemList(ReadOnlyCollection<IWebElement> productList)
        {
            var itemList = new List<Item>();
            foreach (var product in productList)
            {

                Item item = new Item()
                {
                    Name = product.FindElement(By.TagName(Productname)).Text,
                    ProductLink = product.FindElement(By.XPath(Productlink)).GetAttribute("href"),
                    Price = GetPrice(product), 
                    Stock = GetStock(product),
                    Store = "Inet"
                };
                itemList.Add(item);

            }
            return itemList;

            int GetStock(IWebElement product)
            {
                if (product == null) throw new ArgumentNullException(nameof(product));
                var stockText = product.FindElement(By.XPath(Productstock)).Text;
                int stock;
                if(stockText.Contains("Slutsåld") || stockText.Contains("Okänt"))
                {
                    return 0;
                }
                else
                {
                    int.TryParse(ExtractNumbers(stockText), out stock);
                    return stock;
                }
                    
            }
        }

        
        private double GetPrice(IWebElement product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            try
            {//if price throws exception, its because price has been reduced and is in other Html element.
                var unnormalizedPrice = product.FindElement(By.CssSelector(Productprice)).Text;
                return PriceNormalizer(unnormalizedPrice);    
            }
            catch (Exception)
            {
                
                var unnormalizedReducedPrice = product.FindElement(By.XPath(Reducedprice)).Text;
                return PriceNormalizer(unnormalizedReducedPrice);
            }
        }

        public ReadOnlyCollection<IWebElement> InetProducts(IWebDriver driver)
        {
            return driver.FindElements(By.XPath(Productlist));
        }

         
    }
}
