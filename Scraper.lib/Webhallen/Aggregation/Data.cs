using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.lib.Webhallen.Aggregation
{
    public class Data : IData
    {
        public List<Item> AllItems()
        {
            var webhallenScraper = new WebhallenScrap();
            return webhallenScraper.GetCards().Where(p => p.Name.Contains("3080")).ToList();
        }
    }
}
