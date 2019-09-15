using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Pages
{
    class EditPersonPOM : PeoplePOM
    {
        public EditPersonPOM(IWebDriver driver) : base(driver) { }

        public IWebElement FullNameInput => _driver.FindElement(By.Name("people_name"));
        public IWebElement TechnologiesInput => _driver.FindElement(By.CssSelector("input[placeholder='Select technologies']"));
        public IWebElement SeniorityInput => _driver.FindElement(By.CssSelector("input[placeholder='Select seniority']"));
        public IWebElement TeamInput => _driver.FindElement(By.CssSelector("input[placeholder='Select team']"));
        public IWebElement SubmitBtn => _driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement DeleteBtn => _driver.FindElement(By.CssSelector("button[aria-label='delete-button']"));
        
        public void AddNewPerson(string fullname, string technologies, string seniority, string team)
        {
            FullNameInput.SendKeys(fullname);
            TechnologiesInput.SendKeys(technologies);
            SeniorityInput.SendKeys(seniority);
            TeamInput.SendKeys(team);
            SubmitBtn.Click();
        }

        public void EditPerson(string fullname, List<string> technologies, string seniority, string team)
        {
            if(fullname != null)
            {
                FullNameInput.Click();
                FullNameInput.Clear();
                FullNameInput.SendKeys(fullname);
            }
            if(technologies != null)
            {
                TechnologiesInput.Click();
                foreach (var item in technologies)
                {
                    _driver.FindElement(By.CssSelector("span[aria-label='" + item + "']")).Click();
                }
                FullNameInput.Click();
            }
            if (seniority != null)
            {
                SeniorityInput.Click();
                _driver.FindElement(By.CssSelector("span[aria-label='" + seniority + "']")).Click();
            }
            if (team != null)
            {
                TeamInput.Click();
                _driver.FindElement(By.CssSelector("span[aria-label='" + team + "']")).Click();
            }
            SubmitBtn.Click();
        }

        public void DeletePerson()
        {
            DeleteBtn.Click();
            _driver.FindElement(By.CssSelector("button.btn.btn-lg.btn-danger")).Click();
        }
    }

    
    
}
