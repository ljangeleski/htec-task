using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HTEC_Task.Pages;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Test.Pages;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class PlaygroundTests
    {
        IWebDriver driver;
        [TestInitialize]
        public void Setup()
        {
            string pathToDriver = "C:\\"; // Here goes path to chromedriver.exe
            driver = new ChromeDriver(@pathToDriver);
            Console.WriteLine("Opening browser...");
        }
        [TestMethod]
        public void CreatePerson()
        {
            PlaygroundPage();
            Console.WriteLine("Playground page...");

            PlaygroundPOM playground = new PlaygroundPOM(driver);
            playground.GotoPeoplePage();

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until<IWebElement>(d => d.FindElement(By.ClassName("btn-text")));
                Assert.IsNotNull(element, "Expected to find Create person link, but there is none.");
                Console.WriteLine("People page...");
            }
            catch (Exception)
            {
                throw;
            }

            PeoplePOM person = new PeoplePOM(driver);
            person.CreatePerson();

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until<IWebElement>(d => d.FindElement(By.Name("people_name")));
                Assert.IsNotNull(element, "Expected to find full name input, but there is none");
                Console.WriteLine("Create person...");
            }
            catch (Exception)
            {
                throw;
            }

            EditPersonPOM editPerson = new EditPersonPOM(driver);
            string name = "Marko Marković";
            editPerson.AddNewPerson(name, "", "", "");

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until<IWebElement>(d => d.FindElement(By.LinkText(name)));
                Assert.IsNotNull(element, "Expected to find " + name + ", but there is none.");
                Console.WriteLine("Created person " + name);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void EditPerson()
        {
            PlaygroundPage();
            Console.WriteLine("Playground page...");

            PlaygroundPOM playground = new PlaygroundPOM(driver);
            playground.GotoPeoplePage();

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until<IWebElement>(d => d.FindElement(By.ClassName("btn-text")));
                Assert.IsNotNull(element, "Expected to find Create person link, but there is none.");
                Console.WriteLine("People page...");
            }
            catch (Exception)
            {
                throw;
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string name = "Marko Marković";
            bool personExists = false;
            var people = driver.FindElements(By.CssSelector("a.list-group-item.list-group-item-action"));
            foreach (var person in people)
            {
                if (person.GetAttribute("innerHTML") == name)
                    personExists = true;
            }

            if (personExists)
            {
                driver.FindElement((By.LinkText(name))).Click();

                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    IWebElement element = wait.Until<IWebElement>(d => d.FindElement(By.Name("people_name")));
                    Assert.IsNotNull(element, "Expected to find full name input, but there is none");
                    Console.WriteLine("Edit person " + name);
                }
                catch (Exception)
                {
                    throw;
                }

                List<string> technologies = new List<string>();
                technologies.Add("Java");
                technologies.Add("PHP");
                string seniority = "medior";
                string team = "development team";

                EditPersonPOM editPerson = new EditPersonPOM(driver);

                editPerson.EditPerson(null, technologies, seniority, team);

                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    IWebElement element = wait.Until<IWebElement>(d => d.FindElement(By.ClassName("btn-text")));
                    Assert.IsNotNull(element, "Expected to find Create person link, but there is none.");
                    Console.WriteLine("Person " + name + " has been modified.");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                Console.WriteLine("Person " + name + " does not exist.");
            }
        }

        [TestMethod]
        public void DeletePerson()
        {
            PlaygroundPage();
            Console.WriteLine("Playground page...");

            PlaygroundPOM playground = new PlaygroundPOM(driver);
            playground.GotoPeoplePage();

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until<IWebElement>(d => d.FindElement(By.ClassName("btn-text")));
                Assert.IsNotNull(element, "Expected to find Create person link, but there is none.");
                Console.WriteLine("People page...");
            }
            catch (Exception)
            {
                throw;
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string name = "Marko Marković";
            bool personExists = false;
            var people = driver.FindElements(By.CssSelector("a.list-group-item.list-group-item-action"));
            foreach (var person in people)
            {
                if (person.GetAttribute("innerHTML") == name)
                    personExists = true;
            }
            
            if (personExists)
            {
                driver.FindElement((By.LinkText(name))).Click();

                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    IWebElement element = wait.Until<IWebElement>(d => d.FindElement(By.Name("people_name")));
                    Assert.IsNotNull(element, "Expected to find full name input, but there is none");
                    Console.WriteLine("Edit person " + name);
                }
                catch (Exception)
                {
                    throw;
                }

                EditPersonPOM editPerson = new EditPersonPOM(driver);
                editPerson.DeletePerson();

                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    IWebElement element = wait.Until<IWebElement>(d => d.FindElement(By.ClassName("btn-text")));

                    bool stillExists = false;
                    people = driver.FindElements(By.CssSelector("a.list-group-item.list-group-item-action"));
                    foreach (var person in people)
                    {
                        if (person.GetAttribute("innerHTML") == name)
                            stillExists = true;
                    }

                    Assert.IsFalse(stillExists, "Person " + name + " is not deleted.");
                    Console.WriteLine("Deleted person " + name);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                Console.WriteLine("Person " + name + " does not exist.");
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            Console.WriteLine("Browser is closed");
        }

        //method for logging in
        public void LoggingIn()
        {
            LoginPOM login = new LoginPOM(driver);
            login.GoTo();
            login.Maximize();
            login.LoadPageWait();
            Console.WriteLine("Logging in...");

            login.Login("ljiljana.angeleski@gmail.com", "c1v0kv1z");
            
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until<IWebElement>(d => d.FindElement(By.LinkText("Logout")));
                Assert.IsNotNull(element, "Expected to find logout link, but there is none. Login failed.");
            }
            catch (Exception)
            {
                throw;
            }
        }
        //method for entering playground page
        public void PlaygroundPage()
        {
            LoggingIn();
            DashboardPOM dashboard = new DashboardPOM(driver);
            
            dashboard.GotoPlaygroundPage();

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until<IWebElement>(d => d.FindElement(By.Id("test0")));
                Assert.IsNotNull(element, "Expected to find Playground table, but there is none.");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
