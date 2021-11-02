using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scraper.lib.Client;
using Scraper.lib.DataBase.Interface;

namespace Scraper.lib.DataBase.Aggregation
{
    public class Aggregator : IAggregator
    {
        public List<Item> AscendingPrice(List<Item> itemList)
        {
            return itemList.OrderBy(item => item.Price).ToList();
        }

        public List<Item> DescendingPrice(List<Item> itemList)
        {
            return itemList.OrderByDescending(item => item.Price).ToList();
        }

        public List<Item> AscendingStock(List<Item> itemList)
        {
            return itemList.OrderBy(item => item.Stock).ToList();
        }

        public List<Item> DescendingStock(List<Item> itemList)
        {
            return itemList.OrderByDescending(item => item.Stock).ToList();
        }

        public List<Item> ItemsWithName(List<Item> itemList, string name)
        {
            return itemList.FindAll(n => n.Name.Contains(name));
        }
    }
}