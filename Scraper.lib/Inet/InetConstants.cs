using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    public static class InetConstants
    {
        public const string Root = "https://www.inet.se/kategori/167/geforce-gtx-rtx";
        // public const string ExpandCategory = "/html/body/div[1]/div[3]/div/div[1]/div/div[2]/ol/li[3]/div[1]/button";
        // public const string GoToCategory = "/html/body/div[1]/div[3]/div/div[1]/div/div[2]/ol/li[3]/ol/li[3]/div[1]/button";
        // public const string GoToGeforceCategory = "/html/body/div[1]/div[3]/div/div[1]/div/div[2]/ol/li[3]/ol/li[3]/ol/li[3]/div[1]/a";

        public const string ProductList = "//div[@class='product-list product-list-size-default']/ul/li";

        public const string ProductNameTag = "h4";
        public const string ProductPriceCss = "span[class='price']";
        public const string ProductStockXpath = ".//div[@class='stock']/div/span[2]";
        public const string ProductLink = ".//div[@class='product-text']/a[1]";
        public static string ReducedPrice = ".//span[@class='campaign-price']";
    }
}
