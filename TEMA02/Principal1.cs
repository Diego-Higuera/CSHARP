using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA02
{
    class Principal1
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("TIPOS DE DATOS");
            Console.WriteLine("--------------");
            string nombre = "Arturo";
            double estatura = 1.72;
            int edad = 32;
            char sexo = 'H';
            bool casado = false; //true

            Console.WriteLine("Nombre  : " + nombre);
            Console.WriteLine("Estatura: " + estatura);
            Console.WriteLine("Edad    : " + edad);
            Console.WriteLine("Sexo    : " + sexo);
            Console.WriteLine("Casado  : " + casado);

            Console.Read();
        }
    }
}
