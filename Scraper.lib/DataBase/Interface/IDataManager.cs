using System.Collections.Generic;
using System.Threading.Tasks;
using Scraper.lib.Client;

namespace Scraper.lib.DataBase.Interface
{
    public interface IDataManager
    {
        void LoadDataAsync(List<Item> items);
        void LoadAllData();
        Task<List<Item>> AllItemsAsync();
        void DropCollectionAsync();
        Task<List<Item>> AllItemsInStock();
    }
}