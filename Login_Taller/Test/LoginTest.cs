using Login_Taller.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using static System.Net.WebRequestMethods;

namespace Login_Taller.Test
{
    public class Tests
    {
        public IWebDriver driver = new ChromeDriver();
        public LoginPage login;
        public String baseURL = "https://the-internet.herokuapp.com/login";

        [SetUp]
        public void IniciarNavegador()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
            login = new LoginPage(driver);

        }
        [TearDown]
        public void CerrarNavegador()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void IngresoCorrecto()
        {
            login.IngresarCredenciales();

        }
        [Test]
        public void IngresoIncorrecto()
        {
            login.IngresarCredenciales();
        }
    }
}