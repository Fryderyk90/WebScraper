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
        private readonly IDataAccess _dataAccess;


        public ScraperService(IDataManager dataManager, IDataAccess dataAccess)
        {
            _dataManager = dataManager;
            _dataAccess = dataAccess;
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
        

    }
}