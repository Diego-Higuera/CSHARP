using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA19
{
    internal class Principal2
    {
        static void Main1(string[] args)
        {
            string ruta_relativa = @"data/personas.json";
            using (StreamReader sr = new StreamReader(ruta_relativa))
            {
                string json = sr.ReadToEnd();
                JArray personas = JArray.Parse(json);
                foreach(JObject persona in personas)
                {
                    string nombre = (string)persona["nombre"];
                    int edad = (int)persona["edad"];
                    double estatura = (double)persona["estatura"];
                    bool casado = (bool)persona["casado"];
                    char sexo = (char)persona["sexo"];
                    Console.WriteLine("{0,-10} {1,4} {2,6:0.00} {3,-6} {4,3}", nombre, edad, estatura, casado, sexo);
                }
            }
        }
    }
}
