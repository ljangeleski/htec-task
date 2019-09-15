using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HTEC_Task.Start
{
    public abstract class Page
    {
        protected Page(IWebDriver driver) => _driver = driver;
        protected IWebDriver _driver { get; }
    }
}
