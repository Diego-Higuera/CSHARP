using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA04
{
    class Principal2
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("WHILE");
            int numero;
            Console.Write("Ingrese número entero? ");
            numero = int.Parse(Console.ReadLine());
            while (numero != 0) // 5 != 0 vedadero repite   (false termina)
            {
                Console.Write("Ingrese número entero? ");
                numero = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("ADIOS");
        }
    }
}
