using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Login_Taller
{
    public class Tests
    {

        [Test]
        public void IngresoCorrecto()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            Thread.Sleep(500);
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector("#login button")).Click();
            Thread.Sleep(500);

            driver.Close();
            driver.Quit();
        }
        [Test]
        public void IngresoIncorrecto()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys("tomsmith1");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("#login button")).Click();

            driver.Close();
            driver.Quit();
        }
    }
}