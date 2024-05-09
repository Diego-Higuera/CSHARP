using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PROYECTOCSHARP.TEMA19
{
    class Principal3
    {
        static void Main1(string[] args)
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            Dictionary<string, object> persona_dic;


            persona_dic = new Dictionary<string, object>();
            persona_dic["nombre"] = "Luis";
            persona_dic["edad"] = 23;
            persona_dic["estatura"] = 1.72;
            persona_dic["casado"] = true;
            persona_dic["sexo"] = "H";

            data.Add(persona_dic);

            persona_dic = new Dictionary<string, object>();
            persona_dic["nombre"] = "Miguel";
            persona_dic["edad"] = 21;
            persona_dic["estatura"] = 1.71;
            persona_dic["casado"] = false;
            persona_dic["sexo"] = "H";

            data.Add(persona_dic);

            Console.WriteLine("Datos:");
            foreach (var item in data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item, Formatting.Indented));
            }

            string ruta_relativa = @"data/data.json";

            using (StreamWriter sw = new StreamWriter(ruta_relativa))
            {
                sw.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
            }

            Console.WriteLine("OK: ESCRIBIR");

        }


    }
}
