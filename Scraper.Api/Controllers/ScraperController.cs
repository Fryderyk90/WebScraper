using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Scraper.lib.Client;
using Scraper.lib.DataBase.Interface;

namespace Scraper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperService : ControllerBase
    {
        private readonly IDataManager _dataManager;
        private readonly IAggregator _aggregator;


        public ScraperService(IDataManager dataManager, IAggregator aggregator)
        {
            _dataManager = dataManager;
            _aggregator = aggregator;
        }

        [Route("/LoadData")]
        [HttpGet]
        public ActionResult LoadData()
        {
            try
            {
                _dataManager.LoadAllData();

                return Ok("Data Loaded");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/DeleteAllData")]
        [HttpDelete]
        public ActionResult DeleteAllData()
        {
            try
            {
                _dataManager.DropCollectionAsync();
                return Ok("Collection Dropped");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/AllItems")]
        [HttpGet]
        public ActionResult<List<Item>> AllItems()
        {
            try
            {
                var allItems = _dataManager.AllItemsAsync().GetAwaiter().GetResult();
                
                return Ok(allItems);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/AllItemsInStock")]
        [HttpGet]
        public ActionResult<List<Item>> AllItemsInStock()
        {
            try
            {
                var itemsInStock = _dataManager.AllItemsInStock().Result;
                return Ok(itemsInStock);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/AscendingStock")]
        [HttpGet]
        public ActionResult AscendingStock()
        {
            try
            {
                var itemsInStock = _dataManager.AllItemsInStock().Result;
                return Ok(_aggregator.AscendingStock(itemsInStock));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("/DescendingStock")]
        [HttpGet]
        public ActionResult DescendingStock()
        {
            try
            {
                var itemsInStock = _dataManager.AllItemsInStock().Result;
                return Ok(_aggregator.DescendingStock(itemsInStock));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("/AscendingPrice")]
        [HttpGet]
        public ActionResult AscendingPrice()
        {
            try
            {
                var itemsInStock = _dataManager.AllItemsInStock().Result;
                return Ok(_aggregator.AscendingPrice(itemsInStock));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("/DescendingPrice")]
        [HttpGet]
        public ActionResult DescendingPrice()
        {
            try
            {
                var itemsInStock = _dataManager.AllItemsInStock().Result;
                return Ok(_aggregator.DescendingPrice(itemsInStock));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/ItemsByName")]
        [HttpGet]
        public ActionResult ItemsByName(string name)
        {
            try
            {
                var itemList = _dataManager.AllItemsInStock().Result;
                var itemsInStock = _aggregator.DescendingStock(itemList);
                return Ok(_aggregator.ItemsByName(itemsInStock, name));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/ItemsByStoreName")]
        [HttpGet]
        public ActionResult ItemsByStoreName(string name)
        {
            try
            {
                var itemList = _dataManager.AllItemsInStock().Result;
                var itemsInStock = _aggregator.DescendingStock(itemList);
                return Ok(_aggregator.ItemsByStoreName(itemsInStock, name));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}