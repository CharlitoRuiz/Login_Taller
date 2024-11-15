using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Taller.Genericos
{
    public class LeerJson
    {
        public List<POCO.LoginData> login_data()
        {
            try
            {
                var json = JsonConvert.DeserializeObject<Dictionary<String, List<POCO.LoginData>>>(File.ReadAllText(@"..\..\..\Data\login.json"));
                return json["credenciales"];
            }
            catch (FileNotFoundException)
            {
                throw new Exception("No se encontro el archivo json");
            }
            catch(JsonException ex)
            {
                throw new JsonException($"El archivo json esta corrupto: {ex}");
            }
        }
    }
}
