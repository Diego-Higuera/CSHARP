using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA04
{
    class Principal3
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("WHILE INFINITO");
            int numero;
            while (true)
            {
                Console.Write("Ingrese número entero? ");
                numero = int.Parse(Console.ReadLine());
                if (numero == 0)
                {
                    break;
                }
            }
            Console.WriteLine("ADIOS");
        }
    }
}