using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    public class InetScrap : ScraperClient
    {
        private string ROOT = InetConstants.Root;
        private string CATEGORY = InetConstants.ExpandCategory;
        private string SUBCATEGORY = InetConstants.GoToCategory;
        private string GEFORCECATEGORY = InetConstants.GoToGeforceCategory;
        private string PRODUCTLIST = InetConstants.ProductList;
        private string PRODUCTNAME = InetConstants.ProductNameTag;
        private string PRODUCTPRICE = InetConstants.ProductPriceCss;
        private string PRODUCTSTOCK = InetConstants.ProductStockXpath;

        public IWebDriver NavigateToInet(IWebDriver _driver)
        {
            
            _driver.Navigate().GoToUrl(ROOT);
            var expandCategory = _driver.FindElement(By.XPath(CATEGORY));
            expandCategory.Click();
            var goToCategory = _driver.FindElement(By.XPath(SUBCATEGORY));
            goToCategory.Click();
            var geforceCategory = _driver.FindElement(By.XPath(GEFORCECATEGORY));
            geforceCategory.Click();
                        
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
                    Price = product.FindElement(By.CssSelector(PRODUCTPRICE)).Text,
                    Stock = product.FindElement(By.XPath(PRODUCTSTOCK)).Text,
                    Store = "Inet"
                };
                itemList.Add(item);
            }
            return itemList;
        }
        public ReadOnlyCollection<IWebElement> InetProducts(IWebDriver _driver)
        {
            return _driver.FindElements(By.XPath(PRODUCTLIST));
        }

         
    }
}
