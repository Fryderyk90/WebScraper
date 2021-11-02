using System.Collections.Generic;

namespace Scraper.lib.DataBase.Interface
{
    public interface IDataManager
    {
        List<Item> LoadData(List<Item> items);
        
    }
}