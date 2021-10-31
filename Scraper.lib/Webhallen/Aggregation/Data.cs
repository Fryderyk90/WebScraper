using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraper.lib.Webhallen.Interface;

namespace Scraper.lib.Webhallen.Aggregation
{
    public class Data : IData
    {
        public List<Item> AllItems()
        {
            var webhallenScraper = new WebhallenScrap();
            return webhallenScraper.GetCards();
        }

        public List<Item> ItemsByName(string name)
        {
            return AllItems()
                .Where(item => item.Name.Contains(name))
                .ToList();
        }
    }
}
