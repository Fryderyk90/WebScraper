﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.lib.Inet
{
    public interface IData
    {
        List<Item> AllItems();
    }
}
