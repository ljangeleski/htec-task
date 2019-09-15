using HTEC_Task.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Pages
{
    class PeoplePOM : PlaygroundPOM
    {
        public PeoplePOM(IWebDriver driver) : base(driver) { }

        public IWebElement CreatePersonLink => _driver.FindElement(By.ClassName("btn-text"));

        public void CreatePerson()
        {
            CreatePersonLink.Click();
        }
    }
}
