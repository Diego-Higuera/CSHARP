using PROYECTOCSHARP.TEMA07;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA20.ejemplo1
{
    class Principal1
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("EJEMPLO 1");
            Console.WriteLine("---------");
            Circulo1 c1 = new Circulo1();
            Console.WriteLine("Radio: " + c1.GetRadio());

            Circulo1 c2 = new Circulo1(5);
            Console.WriteLine("Radio: " + c2.GetRadio());

            Circulo1 c3 = new Circulo1();
            c3.SetRadio(10);
            Console.WriteLine("Radio: " + c3.GetRadio());

            Console.WriteLine("EJEMPLO 2");
            Console.WriteLine("---------");
            Circulo1 c4 = new Circulo1(12.5);
            Console.WriteLine("{0,-10} {1,10:0.00}", "Radio", c4.GetRadio());
            Console.WriteLine("{0,-10} {1,10:0.00}", "Area", c4.GetArea());
            Console.WriteLine("{0,-10} {1,10:0.00}", "Perimetro", c4.GetPerimetro());

            Console.WriteLine();

            Console.WriteLine(c4);
            Console.WriteLine(c4.ToString());
            Console.WriteLine(c4.MiToStringCsv());
            c4.MiToStringTabla();

            Console.WriteLine("EJEMPLO 3");
            Console.WriteLine("---------");
            List<Circulo1> list_circulos = new List<Circulo1>();
            list_circulos.Add(new Circulo1(5));
            list_circulos.Add(new Circulo1(5.3));
            list_circulos.Add(new Circulo1(7.8));
            list_circulos.Add(new Circulo1(9.2));
            list_circulos.Add(new Circulo1(10.2));

            Circulo1.Cabecera(0);
            foreach (Circulo1 c in list_circulos)
            {
                c.Cuerpo(0, 0);
            }

            Console.WriteLine("EJEMPLO 4");
            Console.WriteLine("---------");
            Circulo1 c5 = new Circulo1();
            c2.SetRadio(10);
            Console.WriteLine("Radio: " + c2.GetRadio());



            /*
            List<string> list_nombres = new List<string>();
            list_nombres.Add("Luis");
            list_nombres.Add("Carlos");
            foreach(string s in list_nombres)
            {
                Console.WriteLine(s);
            }
            */
        }
    }
}