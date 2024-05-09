using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA04
{
    class Principal1
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("DO...WHILE");
            int numero;
            do
            {
                Console.Write("Ingrese número entero? ");
                numero = int.Parse(Console.ReadLine());
            } while (numero != 0); // 5 != 0 vedadero repite   (false termina)
            Console.WriteLine("ADIOS");
        }
    }
}