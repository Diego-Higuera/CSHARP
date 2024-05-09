using PROYECTOCSHARP.TEMA07;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA20.ejemplo1
{
    class Principal2
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("EJEMPLO 1");
            Console.WriteLine("---------");
            Circulo2 c1 = new Circulo2();
            c1.radio = 3;
            Circulo2.Cabecera();
            c1.Cuerpo();
            Console.WriteLine("EJEMPLO 2");
            Console.WriteLine("---------");
            Circulo2 c2 = new Circulo2();
            c2.radio = 10;
            Console.WriteLine("Radio: " + c2.radio);

        }
    }
}