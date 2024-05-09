using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA08
{
    class Principal3
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("EJEMPLO SUBSTRING");
            string texto = "HOLA";
            for (int i = 0; i < texto.Length; i++)
            {
                Console.WriteLine(texto[i]);
            }

            Console.WriteLine("EJEMPLO SUBSTRING");
            texto = "COMPUTADORA";
            int k = 1;
            for (int i = 0; i < texto.Length; i++)
            {
                Console.WriteLine(texto.Substring(0, k));
                k++;
            }
            Console.WriteLine("EJEMPLO SUBSTRING");
            texto = "Hola Mundo-"; //Quitar el guion final
            string textoResultado = texto.Substring(0, texto.Length - 1);
            Console.WriteLine(texto);
            Console.WriteLine(textoResultado);
        }

    }
}