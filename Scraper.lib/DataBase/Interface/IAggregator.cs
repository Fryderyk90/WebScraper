using System.Collections.Generic;
using System.Threading.Tasks;
using Scraper.lib.Client;

namespace Scraper.lib.DataBase.Interface
{
    public interface IAggregator
    {
        List<Item> AscendingPrice(List<Item> itemList);
        List<Item> DescendingPrice(List<Item> itemList);
        List<Item> AscendingStock(List<Item> itemList);
        List<Item> DescendingStock(List<Item> itemList);
        List<Item> ItemsWithName(List<Item> itemList, string name);

    }
}