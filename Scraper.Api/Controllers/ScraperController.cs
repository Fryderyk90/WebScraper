using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Scraper.lib;
using Scraper.lib.Inet;
using System.Collections.Generic;

namespace Scraper.Api.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class ScraperService : ControllerBase
    {
        private readonly lib.Inet.IData _inetData;
        private readonly lib.Webhallen.IData _webhallenData;
        private readonly lib.Komplett.IData _komplettData;


        public ScraperService(IData inetData, lib.Webhallen.IData webhallenData, lib.Komplett.IData komplettData)
        {
            _inetData = inetData;
            _webhallenData = webhallenData;
            _komplettData = komplettData;
        }

        [Route("/GetAllInetItems")]
        [HttpGet]
        public ActionResult<List<Item>> GetAllInetItems()
        {
             try
             {
                 return Ok(_inetData.AllItems());
             }
             catch (System.Exception e)
             {

                 return BadRequest(e.Message);
             }


        }

        [Route("/GetAllWebhallenItems")]
        [HttpGet]
        public ActionResult<List<Item>> GetAllWebhallenItems()
        {
            try
            {
                return Ok(_webhallenData.AllItems());
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [Route("/GetAllKomplettItems")]
        [HttpGet]
        public ActionResult<List<Item>> GetAllKomplettItems()
        {
            try
            {
                return Ok(_komplettData.AllItems());
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
            

        }

        [Route("/GetWebhallenItemsByName")]
        [HttpGet]
        public ActionResult<List<Item>> GetWebhallenItemsByName(string name)
        {
            try
            {
                return Ok(_webhallenData.ItemsByName(name));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
