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
        

        public ScraperService(IData inetData)
        {
            _inetData = inetData;
        }

        [HttpGet]
        public ActionResult<List<Item>> GetAllInetItems()
        {
            lib.Inet.IData inetData = new lib.Inet.Aggregation.Data();
            try
            {
                var firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArguments("--headless");
                IWebDriver _driver = new FirefoxDriver("C:\\Program Files\\Mozilla Firefox\\firefox.exe",firefoxOptions);
                
                var inetItems = inetData.AllItems(_driver);
                return Ok(inetItems);//inetItems;
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }


        }

    }
}
