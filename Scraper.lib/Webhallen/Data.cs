using System.Collections.Generic;
using System.Linq;
using Scraper.lib.Client;
using Scraper.lib.Webhallen.Interface;

namespace Scraper.lib.Webhallen
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
