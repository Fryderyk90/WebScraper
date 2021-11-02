using System.Collections.Generic;
using Scraper.lib.Client;

namespace Scraper.lib.Webhallen.Interface
{
    public interface IData
    {
        List<Item> AllItems();
        List<Item> ItemsByName(string name);
    }
}
