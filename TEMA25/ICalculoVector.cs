using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA25
{
    public interface ICalculoVector //QUE ES LO QUE TENGO QUE HACER
    {
        int sumaVector(int[] vector); //EL COMO LO HAGO YO
        int mayorVector(int[] vector);
        double promedioVector(double[] vector);
    }
}