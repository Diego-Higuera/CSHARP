using PROYECTOCSHARP.TEMA07;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA14
{
    class Principal
    {
        static void Main1(string[] args)
        {
            double compra;

            Console.WriteLine("Ingrese María la compra en dinero? ");
            compra = double.Parse(Console.ReadLine());

            Calculo calculo1 = new Calculo(compra, 0.18);
            Console.WriteLine("TIENES QUE PAGAR: " + calculo1.montoPagar());
            Console.WriteLine(Calculo.mensaje() + " " + Calculo.restaurante);

            Console.WriteLine("Ingrese Juan la compra en dinero? ");
            compra = double.Parse(Console.ReadLine());

            Calculo calculo2 = new Calculo(compra, 0.21);
            Console.WriteLine("TIENES QUE PAGAR: " + calculo2.montoPagar());
            Console.WriteLine(Calculo.mensaje() + " " + Calculo.restaurante);


            Calculo.restaurante = "LIDER";
            Console.WriteLine(Calculo.restaurante);



        }


    }
}