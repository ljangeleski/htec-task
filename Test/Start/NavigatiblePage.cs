using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HTEC_Task.Start
{
    public abstract class NavigatablePage : Page
    {
        protected NavigatablePage(IWebDriver driver) : base(driver)
        {
        }
        public abstract string Url { get; }
        public void GoTo() => _driver.Navigate().GoToUrl(Url);
        public void Refresh() => _driver.Navigate().Refresh();
        public void Maximize() => _driver.Manage().Window.Maximize();
        public void LoadPageWait() => _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
    }
}
