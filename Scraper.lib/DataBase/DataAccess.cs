using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Scraper.lib.Client;

namespace Scraper.lib.DataBase
{
    public class DataAccess
    {
        private const string  CollectionName = "Products";
        private const string DataBaseName = "ScraperData";
        private const string ConnectionString = "mongodb://localhost:27017/?readPreference=primary&appname=mongodb-vscode%200.6.14&directConnection=true&ssl=false";
        
        public IMongoDatabase ScraperData()
        {       
            var client = new MongoClient(ConnectionString);
            var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);

            return client.GetDatabase(DataBaseName);
            
        }

        public IMongoCollection<Item> ProductCollection()
        {
            
            return ScraperData().GetCollection<Item>(CollectionName);
        }

        public async Task<List<Item>> AddDataAsync(List<Item> items)
        {
            await ProductCollection().InsertManyAsync(items);

            return null;
        }

        public void DropCollection()
        {
            ScraperData().DropCollection(CollectionName);
        }


    }
}