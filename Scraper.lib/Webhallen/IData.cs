using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scraper.lib.Client;

namespace Scraper.lib.Webhallen
{
    public interface IData
    {
        List<Item> AllItems();
        List <Item> ItemsByName(string name);
    }
}