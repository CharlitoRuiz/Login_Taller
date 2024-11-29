using AventStack.ExtentReports;
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
                var loginData = json.ReadJson<POCO.LoginData>("login", "credenciales");
                return loginData.Select(data => new TestCaseData(data.username, data.password));
            }
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public void IngresoCorrecto(string user, string pass)
        {
            test = reports.CreateTest("Validando ingreso correcto");

            try
            {
                // Paso 1:
                IngresarCredenciales(user, pass);

                // Paso 2:
                validarIngreso();

                // Paso 3:
                RealizarLogout();


            }
            catch (NoSuchElementException ex)
            {
                test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"No se encontró el elemento: {ex.Message}");
            }
            catch (AssertionException ex)
            {
                test.Log(Status.Fail, $"Fallo de aserción: {ex.Message}");
                test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"Fallo de aserción: {ex.Message}");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"Error en la ejecución del test: {ex.Message}");
                test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"Error en la ejecución del test: {ex.Message}");
                throw;
            }

        }
        private void IngresarCredenciales(String user, String pass)
        {
            login.IngresarCredenciales(user, pass);
            test.Log(Status.Pass, $"Se ingresaron las credenciales: {user}, {pass}");
            // diferentes esperas
            page.ElementoEsVisible(login.LoginButtom);
            page.ElementoEsActivo(login.LoginButtom);
            page.ElementoNoVacio(login.UsernameField);
            login.DarClickBotonLogin();
            test.Log(Status.Pass, "Se le dio click el boton login");
        }

        private void validarIngreso()
        {
            // Assertions
            Assert.That(driver.Url.Equals("https://the-internet.herokuapp.com/secure"), "La URL no corresponde a la pagina de inicio esperada");
            Assert.That(login.ValidarIngresoCorrecto(), "La validación de ingreso correcto falló.");
            Assert.That(login.LogoutButtom.Displayed, "El botón de logout no se mostró correctamente.");
            test.Log(Status.Pass, "Se ingreso correctamente");
        }
        private void RealizarLogout()
        {
            page.ElementoEsActivo(login.LogoutButtom);
            login.ClickBotonLogout();
            test.Log(Status.Pass, "Se dio click en el botón Logout");
        }
    }
}