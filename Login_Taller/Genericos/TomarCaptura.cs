using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Taller.Genericos
{
    public class TomarCaptura
    {
        public String CapturarPantalla(IWebDriver driver)
        {
			String photo = "";
			try
			{
				ITakesScreenshot sreenshotdriver = driver as ITakesScreenshot;
				Screenshot screenshot = sreenshotdriver.GetScreenshot();
				photo = screenshot.AsBase64EncodedString;

				
            }
			catch (Exception ex)
			{

				Console.WriteLine($"No se pudo guardar la imagen:  {ex}");
			}
			return photo;
        }
    }
}
