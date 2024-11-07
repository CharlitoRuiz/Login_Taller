using Login_Taller.Genericos;
using Login_Taller.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Collections;
using static System.Net.WebRequestMethods;

namespace Login_Taller.Test
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver driver;
        public LoginPage login;
        public LeerJson json;
        public String baseURL = "https://the-internet.herokuapp.com/login";


        [SetUp]
        public void IniciarNavegador()
        {
            driver = new ChromeDriver();
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

        public static IEnumerable TestData
        {
            get
            {
                var json = new LeerJson();
                return json.login_data().Select(data => new TestCaseData(data.username, data.password));
            }
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public void IngresoCorrecto(String user, String pass)
        {
            var data = json.login_data();
            //String user = data.username;
            //String pass = data.password;

            login.IngresarCredenciales(user, pass);
        }
    }
}