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
        public List<T> ReadJson<T>(String nombreJson, String jsonKey)
        {
            /// <summary>
            /// Metodo que lee el json con una estructura generica
            /// </summary>
            /// <returns>el archivo json deserializado</returns>
            try
            {
                var json = JsonConvert.DeserializeObject<Dictionary<String, List<T>>>(File.ReadAllText($@"..\..\..\Data\{nombreJson}.json"));
                return json[jsonKey];
            }
            catch (FileNotFoundException)
            {
                throw new Exception($"No se encontro el archivo json en la ruta: Data/{nombreJson}");
            }
            catch(JsonException ex)
            {
                throw new JsonException($"El archivo json esta corrupto: {ex}");
            }
        }
    }
}
