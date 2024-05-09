using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA25
{
    class Principal
    {
        static void Main(string[] args)
        {
            int[] vector = { 8, 9, 1, 3, 4, 5, 6 };
            double[] vector1 = { 1.2, 2.3, 4.1 };

            ICalculoVector td = new TareaDesarrollada();

            Console.WriteLine("Suma     Vector: " + td.sumaVector(vector));
            Console.WriteLine("Mayor    Vector: " + td.mayorVector(vector));
            Console.WriteLine("Promedio Vector: " + td.promedioVector(vector1));
        }
    }
}