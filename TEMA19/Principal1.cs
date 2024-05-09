using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA19
{
    internal class Principal1
    {
        static void Main1(string[] args)
        {
            string ruta_relativa = @"data/persona.json";
            using(StreamReader sr = new StreamReader(ruta_relativa))
            {
                string json = sr.ReadToEnd();
                dynamic datos = JObject.Parse(json);
                string nombre = datos.nombre;
                int edad = datos.edad;
                double estatura = datos.estatura;
                bool casado = datos.casado;
                char sexo =Convert.ToChar(datos.sexo);
                Console.WriteLine(nombre + " " + edad + " " + estatura + " " + casado + " " + sexo );
            }
        }
    }
}
