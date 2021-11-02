using System;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Scraper.lib;
using Scraper.lib.Inet;
using System.Collections.Generic;
using System.Linq;
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
                var allitems = _dataManager.AllItemsAsync().GetAwaiter().GetResult();
                
                return Ok(allitems);
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
                return BadRequest();
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

        [Route("/ItemsWithName")]
        [HttpGet]
        public ActionResult ItemsWithName(string name)
        {
            try
            {
                var itemList = _dataManager.AllItemsInStock().Result;
                var itemsInStock = _aggregator.DescendingStock(itemList);
                return Ok(_aggregator.ItemsWithName(itemsInStock, name));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}