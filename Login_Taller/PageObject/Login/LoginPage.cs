using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Taller.PageObject.Login
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private readonly By _txtUsername = By.Id("username");
        private readonly By _txtPassword = By.Id("password");
        private readonly By _btnLogin = By.CssSelector("#login button");
        private readonly By _btnLogout = By.CssSelector(".button .icon-signout");

        public IWebElement username => _driver.FindElement(_txtUsername);
        public IWebElement password => _driver.FindElement(_txtPassword);
        public IWebElement botonLogin => _driver.FindElement(_btnLogin);
        public IWebElement botonLogout => _driver.FindElement(_btnLogout);

        public void IngresarCredenciales(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);

        }
        public void DarClickBotonLogin()
        {
            botonLogin.Click();
        }

        public bool ValidarBoton()
        {
            bool seMuestra = botonLogout.Displayed;
            return seMuestra;
        }



    }
}
