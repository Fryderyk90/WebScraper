using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Scraper
{
    public class KomplettScrap : ScraperClient
    {
        public IWebDriver NavigateToKomplett(IWebDriver _driver)
        {
            _driver.Navigate().GoToUrl("https://www.komplett.se/category/10412/datorutrustning/datorkomponenter/grafikkort?nlevel=10000%C2%A728003%C2%A710412&cnet=Grafikprocessor_A00247%20%20%C2%A7NVIDIA%20GeForce%20RTX%203080&cnet=Grafikprocessor_A00247%20%20%C2%A7NVIDIA%20GeForce%20RTX%203070%20Ti&cnet=Grafikprocessor_A00247%20%20%C2%A7NVIDIA%20GeForce%20RTX%203080%20Ti");
            CookieConsent(_driver);
            return _driver;
        }

        public ReadOnlyCollection<IWebElement> KomplettProducts(IWebDriver _driver)
        {
          //  Lazy<ReadOnlyCollection<IWebElement>> lazyList = new Lazy<ReadOnlyCollection<IWebElement>>();
           // lazyList = _driver.FindElements(By.ClassName("responsive-content-wrapper"));
            return _driver.FindElements(By.ClassName("product-list-item"));           
        }

        public List<Item> KomplettItemList(ReadOnlyCollection<IWebElement> productList)
        {
            var itemList = new List<Item>();
            
            foreach (var product in productList)
            {
                var item = new Item
                {
                    Name = product.FindElement(By.XPath(".//div[@class='text-content']")).Text,
                    Price = FindPrice(product),
                    Stock = IsInStock(product),                  
                    Store = "Komplett"
                };
                itemList.Add(item);

            }

            return itemList;
        }

        private string FindPrice(IWebElement product)
        {
            try
            {
                return product.FindElement(By.XPath(".//span[@class='product-price-now']")).Text;
            }
            catch (Exception)
            {
                return "No Price";
            }                        
        }

        private void CookieConsent(IWebDriver _driver)
        {
            var cookie = _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div/div/div[2]/form/div/div[1]/button"));
            cookie.Click();
        }
        private string IsInStock(IWebElement product)
        {
            try
            {
                return product.FindElement(By.XPath(".//span[@class'stockstatus-stock-details']")).Text;
            }
            catch (Exception)
            {
                return "Out Of Stock";
            }


        }
    }
}