using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA03
{
    class Principal
    {
        static Random rnd = new Random();
        static void Main1(string[] args)
        {
            Console.WriteLine("ALFABETO INGLES");
            Console.WriteLine("---------------");
            for (char i = 'A'; i <= 'Z'; i++)
            {
                Console.WriteLine(i + "\t" + (int)i);
            }

            Console.WriteLine("GENERAR 10 LETRAS ALEATORIAS");
            Console.WriteLine("----------------------------");

            for (int i = 0; i < 10; i++)
            {
                Console.Write((char)rnd.Next(65, 91) + "  ");
                //Console.Write((char)new Random().Next(65, 91) + "  ");
            }
            Console.WriteLine();

            Console.WriteLine("GENERAR 100 LETRAS ALEATORIOAS Y CONTAR CUANTAS VOCALES");
            Console.WriteLine("-------------------------------------------------------");
            string patron = "[aeiouAEIOU]";
            char letra;
            bool correcto;

            int c = 0;
            int k = 1;
            for (int i = 1; i <= 100; i++)
            {
                letra = ObtenerLetraAleatoria();
                correcto = Regex.IsMatch(letra.ToString(), patron);
                if (correcto)
                {
                    Console.WriteLine(letra + "\t" + correcto + "\t" + k++);
                }
                else
                {
                    Console.WriteLine(letra + "\t" + correcto);
                }
                if (correcto)
                {
                    c++; //c = c + 1,  c += 1
                }
            }
            Console.WriteLine("Cantidad Vocales: " + c);
        }

        public static char ObtenerLetraAleatoria()
        {
            char letra;
            // 65-90=A   97-122=a
            int grupo = rnd.Next(0, 2);
            if (grupo == 0)
            {
                letra = (char)rnd.Next(65, 91);
            }
            else
            {
                letra = (char)rnd.Next(97, 123);
            }
            return letra;
        }


    }
}