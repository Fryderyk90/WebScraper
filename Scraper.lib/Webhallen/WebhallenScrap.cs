using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using OpenQA.Selenium;
using Scraper.lib.Client;

namespace Scraper.lib.Webhallen
{
    public class WebhallenScrap : ScraperClient
    {


        public List<Item> GetCards()
        {
            var client = new HttpClient();
            var itemList = new List<Item>();
            for (int i = 0; i < 15; i++)
            {
                var response = client.GetStringAsync($"https://www.webhallen.com/api/search?query%5BsortBy%5D=sales&query%5Bfilters%5D%5B0%5D%5Btype%5D=category&query%5Bfilters%5D%5B0%5D%5Bvalue%5D=4684&query%5BminPrice%5D=0&query%5BmaxPrice%5D=999999&page={i}").Result;

                var cards = WebhallenItem.FromJson(response).Products.ToList();
                foreach (var product in cards)
                {
                    var item = new Item
                    {
                        Name = product.Name,
                        ProductLink = "No Link",
                        Price = PriceNormalizer(product.Price.PricePrice.ToString()),
                        Stock = int.Parse(product.Stock.Web.ToString()),
                        Store = "Webhallen"
                    };
                    itemList.Add(item);
                }
            }



            return itemList;
        }





        public List<Item> WebhallenItemList(List<Product> cards)
        {
            var itemList = new List<Item>();

            foreach (var product in cards)
            {
                var item = new Item
                {
                    Name = product.Name,
                    Price = PriceNormalizer(product.Price.ToString()),
                    Stock = int.Parse(product.Stock.Web.ToString())
                };
                itemList.Add(item);
            }


            return itemList;
        }


    }

}

