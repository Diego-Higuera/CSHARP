using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA25
{
    public class TareaDesarrollada : ICalculoVector
    {
        int ICalculoVector.mayorVector(int[] vector)
        {
            int mayor = vector[0];
            foreach (int numero in vector)
            {
                if (numero > mayor)
                {
                    mayor = numero;
                }
            }
            return mayor;
        }

        double ICalculoVector.promedioVector(double[] vector)
        {
            double suma = 0;
            foreach (double numero in vector)
            {
                suma = suma + numero;
            }
            return suma / vector.Length;
        }

        int ICalculoVector.sumaVector(int[] vector)
        {
            int a = 0;
            foreach (int numero in vector)
            {
                a = a + numero;
            }
            return a;
        }

    }
}