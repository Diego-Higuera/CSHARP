using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA21
{
    class Principal
    {
        static void Main1(string[] args)
        {
            //DICCIONARIO: TIPO DE DATO COLECCION (PARES)(CLAVE,VALOR)
            //CLAVE, VALOR = nombre, edad
            Dictionary<string, int> diccionario = new Dictionary<string, int>();
            // LLENAR DICCIONARIO (CLAVE,VALOR)
            diccionario["Juan"] = 30;
            diccionario["María"] = 25;
            diccionario["Pedro"] = 40;
            // ACCEDER A LOS ELEMENTOS DEL DICCIONARIO
            Console.WriteLine("Edad de Pedro: " + diccionario["Pedro"]);

            // DICCIONAR PARA GUARDAR TRADUCCION INGLES A ESPAÑOL 
            Dictionary<string, string> diccionario1 = new Dictionary<string, string>();
            diccionario1["one"] = "uno";
            diccionario1["two"] = "dos";
            diccionario1["one"] = "UNO";
            Console.WriteLine("La traduccion en español de one: " + diccionario1["one"]);

            //GUARDAR OBJETOS
            Dictionary<string, Alumno> diccionario2 = new Dictionary<string, Alumno>();
            diccionario2["A1"] = new Alumno("A1", "Luis", 23, new List<string> { "Física", "Lógica" });
            diccionario2["A2"] = new Alumno("A2", "Miguel", 22, new List<string> { "Matemática", "Historia" });
            Console.WriteLine("La edad de A1 es " + diccionario2["A1"].edad);
            Console.WriteLine("La Asignaturas de A2 es " + string.Join(", ", diccionario2["A2"].asignaturas));

            Console.WriteLine("RECORRER UN DICCIONAR CON UN FOREACH");
            foreach (KeyValuePair<string, Alumno> d in diccionario2)
            {
                Console.WriteLine("Clave: " + d.Key);
                Console.WriteLine("Valor: " + d.Value);
            }

        }
    }
}