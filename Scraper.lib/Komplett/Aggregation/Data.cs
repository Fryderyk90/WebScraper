using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraper.lib.Client;

namespace Scraper.lib.Komplett.Aggregation
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
