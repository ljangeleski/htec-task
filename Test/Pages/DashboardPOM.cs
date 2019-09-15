using HTEC_Task.Start;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace HTEC_Task.Pages
{
    class DashboardPOM : NavigatablePage
    {

        public DashboardPOM(IWebDriver driver) : base(driver) { }

        public IWebElement ProfileCard => _driver.FindElement(By.CssSelector("a[href*='profile']"));
        public IWebElement UseCasesCard => _driver.FindElement(By.CssSelector("a[href*='use-cases']"));
        public IWebElement PlaygroundCard => _driver.FindElement(By.CssSelector("a[href*='projects']"));
        public IWebElement ReportingIssuesCard => _driver.FindElement(By.CssSelector("a[href*='reports']"));
               

        public override string Url => "https://qa-sandbox.apps.htec.rs/dashboard";

        public void GotoProfilePage()
        {
            ProfileCard.Click();
        }

        public void GotoUseCasesPage()
        {
            UseCasesCard.Click();
        }

        public void GotoPlaygroundPage()
        {
            PlaygroundCard.Click();
        }

        public void GotoReportingIssuesPage()
        {
            ReportingIssuesCard.Click();
        }
    }
}
