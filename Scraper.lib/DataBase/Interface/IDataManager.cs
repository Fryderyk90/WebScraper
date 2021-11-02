using System.Collections.Generic;
using Scraper.lib.Client;

namespace Scraper.lib.DataBase.Interface
{
    public interface IDataManager
    {
        List<Item> LoadData(List<Item> items);
        
    }
}