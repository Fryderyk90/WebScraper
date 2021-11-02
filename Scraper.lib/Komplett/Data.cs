using System.Collections.Generic;
using Scraper.lib.Client;
using Scraper.lib.Komplett.Interface;

namespace Scraper.lib.Komplett
{
    public class Data : IData
    {
        public List<Item> AllItems()
        {
            var komplett = new KomplettScrap();

            var driver = komplett.WebDriver();
            komplett.NavigateToKomplett(driver);
            komplett.ScrollPage(driver);

            var komplettProducts = komplett.KomplettProducts(driver);
            
            return komplett.KomplettItemList(komplettProducts);

            
        }
    }
}
