using System.Collections.Generic;

namespace Scraper.lib.Webhallen.Interface
{
    public interface IData
    {
        List<Item> AllItems();
        List<Item> ItemsByName(string name);
    }
}
