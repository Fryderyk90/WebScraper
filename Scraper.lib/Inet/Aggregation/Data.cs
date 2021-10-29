using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.lib.Inet.Aggregation
{
    public class Data : IData
    {     
        public List<Item> AllItems(IWebDriver driver)
        {
            var inet = new InetScrap();
           // var driver = inet.WebDriver();
            inet.NavigateToInet(driver);
            inet.ScrollPage(driver);
            var inetProducts = inet.InetProducts(driver);
            return inet.InetItemList(inetProducts);
        }
    }
}
