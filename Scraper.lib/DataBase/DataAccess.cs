using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Scraper.lib.DataBase
{
    public class DataAccess
    {
        private const string  collectionName = "Products";
        private const string dataBaseName = "ScraperData";
        private const string connectionString = "mongodb://localhost:27017/?readPreference=primary&appname=mongodb-vscode%200.6.14&directConnection=true&ssl=false";
        
        public IMongoDatabase ScraperData()
        {       
            var client = new MongoClient(connectionString);
            var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);

            return client.GetDatabase(dataBaseName);
            
        }

        public IMongoCollection<Item> ProductCollection()
        {
            
            return ScraperData().GetCollection<Item>(collectionName);
        }

        public async Task<List<Item>> AddDataAsync(List<Item> items)
        {
            await ProductCollection().InsertManyAsync(items);

            return null;
        }

        public void DropCollection()
        {
            ScraperData().DropCollection(collectionName);
        }


    }
}