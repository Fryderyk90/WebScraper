using System.Collections.Generic;
using Scraper.lib.Client;
using Scraper.lib.Inet.Interface;

namespace Scraper.lib.Inet
{
    public class Data : IData
    {     
        public List<Item> AllItems()
        {
            Client.ScraperClient client = new ScraperClient();
            var inet = new InetScrap();
            var driver = inet.WebDriver();
            inet.NavigateToInet(driver);
            inet.ScrollPage(driver);
            var inetProducts = inet.InetProducts(driver);
            
            return inet.InetItemList(inetProducts);
        }
    }
}
