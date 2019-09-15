using HTEC_Task.Start;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace HTEC_Task.Pages
{
    class PlaygroundPOM : NavigatablePage
    {

        public PlaygroundPOM(IWebDriver driver) : base(driver) { }

        public IWebElement ProjectsLink => _driver.FindElement(By.Id("test0"));
        public IWebElement TeamsLink => _driver.FindElement(By.Id("test1"));
        public IWebElement PeopleLink => _driver.FindElement(By.Id("test2"));
        public IWebElement SenioritiesLink => _driver.FindElement(By.Id("test3"));
        public IWebElement TechnologiesLink => _driver.FindElement(By.Id("test1"));

        public override string Url => "https://qa-sandbox.apps.htec.rs/projects";

        public void GotoProjectsPage()
        {
            ProjectsLink.Click();
        }

        public void GotoTeamsPage()
        {
            TeamsLink.Click();
        }

        public void GotoPeoplePage()
        {
            PeopleLink.Click();
        }

        public void GotoSenioritiesPage()
        {
            SenioritiesLink.Click();
        }

        public void GotoTechnologiesPage()
        {
            TechnologiesLink.Click();
        }
    }
}
