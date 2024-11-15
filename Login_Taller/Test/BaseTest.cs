using Login_Taller.Genericos;
using Login_Taller.PageObject.Login;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Login_Taller.PageObject;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Login_Taller.Test
{
    public class BaseTest
    {
        public IWebDriver driver;
        public LoginPage login;
        public LeerJson json;
        public string baseURL = "https://the-internet.herokuapp.com/login";
        public WebDriverWait wait;
        public BasePage page;
        public TomarCaptura captura;

        // reportes
        public static ExtentTest test;
        public static ExtentReports reports;

        [SetUp]
        public void IniciarNavegador()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
            login = new LoginPage(driver, wait);
            page = new BasePage(driver, wait);
            captura = new TomarCaptura();

        }
        [TearDown]
        public void CerrarNavegador()
        {
            driver.Close();
            driver.Quit();
        }
        [OneTimeSetUp]
        public void IniciarReporte()
        {
            reports = new ExtentReports();
            ExtentSparkReporter htmlreporter = new ExtentSparkReporter(@"..\..\Reportes\index.html");
            reports.AttachReporter(htmlreporter);
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
        }

        [OneTimeTearDown]
        public void generarReporte()
        {
            reports.Flush();
        }
    }
}
