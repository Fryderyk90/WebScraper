using MongoDB.Driver;
using Scraper.lib.Client;

namespace Scraper.lib.DataBase.Interface
{
    public interface IDataAccess
    {
        IMongoDatabase ScraperData();
        IMongoCollection<Item> ProductCollection();
    }
}