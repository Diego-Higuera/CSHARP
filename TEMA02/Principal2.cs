using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA02
{
    class Principal2
    {
        static void Main1(string[] args)
        {
            string nombre;
            double estatura;
            int edad;
            char sexo;
            bool casado;
            int casado1;

            Console.Write("Ingresar nombre? ");
            nombre = Console.ReadLine();

            Console.Write("Ingresar estatura? ");
            estatura = double.Parse(Console.ReadLine());

            Console.Write("Ingresar edad? ");
            edad = int.Parse(Console.ReadLine());

            Console.Write("Ingresar sexo? ");
            sexo = char.Parse(Console.ReadLine());

            Console.Write("Ingresar si es casado 1/0? ");
            casado1 = int.Parse(Console.ReadLine());

            casado = casado1 == 1 ? true : false; //Operador condicional ternario


            /*
            if (casado1 == 1) 
            {
                casado = true;
            }else
            {
                casado = false;
            }
            */

            Console.WriteLine("{0,6} {1,8} {2,4} {3,4} {4,6}", "NOMBRE", "ESTATURA", "EDAD", "SEXO", "CASADO");
            Console.WriteLine("{0,6} {1,8} {2,4} {3,4} {4,6}", "------", "--------", "----", "----", "------");
            Console.WriteLine("{0,-6} {1,8:0.00} {2,4} {3,4} {4,6}", nombre, estatura, edad, sexo, casado);

        }
    }
}