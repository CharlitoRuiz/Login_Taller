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
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Login_Taller.Test
{
    public class BaseTest
    {
        public IWebDriver driver;
        public LoginPage login;
        public LeerJson json;
        public WebDriverWait wait;
        public BasePage page;
        public TomarCaptura captura;

        // reportes
        public static ExtentTest test;
        public static ExtentReports reports;

        [SetUp]
        public void IniciarNavegador()
        {
            // Se agrega lectura json para navegador
            json = new LeerJson();
            var configData = json.ReadJson<POCO.ConfigData>("config", "configuracion");
            String baseURL = configData[0].baseURL;
            String browser = configData[0].browser;
            int timeout = configData[0].timeout;
            driver = IniciarDriver(browser);


            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
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
            // Manejo de directorios
            String directorioActual = AppDomain.CurrentDomain.BaseDirectory;
            String directorioProyecto = Directory.GetParent(directorioActual).Parent.Parent.Parent.FullName;
            String directorioReporte = Path.Combine(directorioProyecto, "Reportes");
            String nombreReporte = Path.Combine(directorioReporte, "index.html");

            reports = new ExtentReports();
            ExtentSparkReporter htmlreporter = new ExtentSparkReporter(nombreReporte);
            reports.AttachReporter(htmlreporter);
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
        }

        [OneTimeTearDown]
        public void generarReporte()
        {
            reports.Flush();
        }

        private IWebDriver IniciarDriver(String browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(ConfigurarChromeOpciones()),
                "edge" => new EdgeDriver(ConfigurarEdgeOpciones()),
                "firefox" => new FirefoxDriver(ConfigurarFirefoxOpciones()),
                _ => throw new Exception($"El navegador: {browser} no es compatible")

            };
        }
        
        private ChromeOptions ConfigurarChromeOpciones()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            return options;
        }
        private FirefoxOptions ConfigurarFirefoxOpciones()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            return options;
        }
        private EdgeOptions ConfigurarEdgeOpciones()
        {
            var options = new EdgeOptions();
            options.AddArgument("headless");
            return options;
        }
    }
}
