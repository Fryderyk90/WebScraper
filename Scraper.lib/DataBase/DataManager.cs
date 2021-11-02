using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Scraper.lib.Client;
using Scraper.lib.DataBase.Interface;
using Scraper.lib.Webhallen;
using Scraper.lib.Webhallen.Interface;


namespace Scraper.lib.DataBase
{
    public class DataManager : IDataManager
    {
        private IDataAccess DataAccess = new DataAccess();
        public async void  LoadDataAsync(List<Item> items)
        {
            IDataAccess dataAccess = new DataAccess();
            
            await DataAccess.ProductCollection().InsertManyAsync(items);
        }

        public void LoadAllData()
        {
            var allData = new List<Item>();
            IData wehallenData = new Data();
            Inet.Interface.IData inetData = new Inet.Data();
            Komplett.Interface.IData komplettData = new Komplett.Data();
            
            allData.AddRange(wehallenData.AllItems());
            allData.AddRange(inetData.AllItems());
            allData.AddRange(komplettData.AllItems());
            
            
            LoadDataAsync(allData);
            
        }

        public async Task<List<Item>> AllItemsAsync()
        {
            return await DataAccess.ProductCollection().Find(new BsonDocument()).ToListAsync();
        }

        public async void DropCollectionAsync()
        {
            
           await DataAccess.ScraperData().DropCollectionAsync("Products");
        }

        public Task<List<Item>> AllItemsInStock()
        {
            var itemsInStock = DataAccess.ProductCollection().Find(i => i.Stock > 0).ToListAsync();

            return itemsInStock;
        }
    }
}