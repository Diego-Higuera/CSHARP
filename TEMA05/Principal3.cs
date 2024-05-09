using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA05
{
    class Principal3
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("MEDIA DEL VECTOR");
            int suma = 0;
            int[] vector = { 5, 8, 9, 1 };
            for (int i = 0; i < vector.Length; i++)
            {
                suma = suma + vector[i];
            }
            Console.WriteLine("Promedio: " + suma / (float)vector.Length); //4.0
        }


    }
}