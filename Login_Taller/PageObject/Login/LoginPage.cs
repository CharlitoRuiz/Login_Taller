using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Taller.PageObject.Login
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private readonly By _txtUsername = By.Id("username");
        private readonly By _txtPassword = By.Id("password");
        private readonly By _btnLogin = By.CssSelector("#login button");

        public IWebElement username => _driver.FindElement(_txtUsername);
        public IWebElement password => _driver.FindElement(_txtPassword);
        public IWebElement botonLogin => _driver.FindElement(_btnLogin);

        public void IngresarCredenciales(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            botonLogin.Click();
        }

    }
}
