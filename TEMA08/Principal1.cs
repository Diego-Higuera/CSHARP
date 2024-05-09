using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA08
{
    class Principal1
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("EJEMPLO: REMPLACE TODAS LAS COINCIDENCIAS");
            string texto = "En un puerto italiano"; //Reemplazar todas las vocales por x

            string caracter = "o";
            string textoResultado1 = texto.Replace(caracter, "x");

            string er = "[aeiouAEIOU]";
            string textoResultado2 = Regex.Replace(texto, er, "x");

            Console.WriteLine(texto);
            Console.WriteLine(textoResultado1);
            Console.WriteLine(textoResultado2);

            Console.WriteLine("EJEMPLO LIMPIAR ESPACIOS ENTRE PALABRAS");
            texto = "En       un    puerto                   italiano";
            er = "\\s+";
            string textoResultado3 = Regex.Replace(texto, er, " ");
            Console.WriteLine(texto);
            Console.WriteLine(textoResultado3);
        }
    }
}