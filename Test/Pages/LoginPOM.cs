using HTEC_Task.Start;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTEC_Task.Pages
{
    class LoginPOM : NavigatablePage
    {
        public LoginPOM(IWebDriver driver) : base(driver) { }

        public IWebElement InputEmail => _driver.FindElement(By.Name("email"));
        public IWebElement InputPassword => _driver.FindElement(By.Name("password"));
        public IWebElement BtnLoginSubmit => _driver.FindElement(By.CssSelector("form > button"));

        public override string Url => "https://qa-sandbox.apps.htec.rs/login";

        public void Login(string email, string password)
        {
            InputEmail.SendKeys(email);
            InputPassword.SendKeys(password);
            BtnLoginSubmit.Click();
        }
    }
}
