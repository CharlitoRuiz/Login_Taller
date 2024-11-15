using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Taller.PageObject
{
    public class BasePage
    {
        public IWebDriver _driver;
        public WebDriverWait _wait;

        public BasePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public bool ElementoEsVisible(IWebElement elemento)
        {
            try
            {
                _wait.Until(driver => elemento.Displayed);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool ElementoEsActivo(IWebElement elemento)
        {
            try
            {
                _wait.Until(driver => elemento.Enabled);
                return true;
            }
            catch (WebDriverTimeoutException)
            {

                return false;
            }

        }
        public bool ElementoNoVacio(IWebElement elemento)
        {
            _wait.Until(driver => !elemento.Equals(null));
            return true;
        }
    }
}
