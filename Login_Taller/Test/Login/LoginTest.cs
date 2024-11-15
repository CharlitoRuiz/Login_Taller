using Login_Taller.Genericos;
using Login_Taller.PageObject.Login;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Collections;
using static System.Net.WebRequestMethods;

namespace Login_Taller.Test.Test
{
    [TestFixture]
    public class Tests : BaseTest
    {

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
        public void IngresoCorrecto(string user, string pass)
        {
            var data = json.login_data();
            //String user = data.username;
            //String pass = data.password;
            try
            {
                login.IngresarCredenciales(user, pass);
                page.ElementoEsVisible(login.botonLogin);
                login.DarClickBotonLogin();
                // Assertions
                Assert.That(driver.Url.Equals("https://the-internet.herokuapp.com/secure"));
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"No se encontro el elemento: {ex.Message}");
                Assert.Fail("Cayo en el catch");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la ejecucion:{ex} ");
            }

        }
    }
}