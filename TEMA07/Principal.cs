using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA07
{
    class Principal
    {
        static void Main1(string[] args)
        {
            {
                Console.WriteLine("EJEMPLO 1");
                double radio = 5.1;
                double area = Math.PI * Math.Pow(radio, 2);
                Console.WriteLine("Area: " + (float)area);
            }
            {
                Console.WriteLine("EJEMPLO 2");
                float radio = 5.1f;
                Console.WriteLine("Area: " + area(radio));
            }
            {
                Console.WriteLine("EJEMPLO 3");
                float radio = 5.1f;
                Console.WriteLine("Area: " + Calculo.area(radio));
            }

            {
                Console.WriteLine("EJEMPLO 4");
                float radio = 5.1f;
                Console.WriteLine("Area: " + Circulo.area(radio));
            }
            {
                Console.WriteLine("EJEMPLO 5");
                float radio = 5.1f;
                Circulo circulo = new Circulo();
                Console.WriteLine("Area: " + circulo.areaCirculo(radio));
            }
        }
        public static float area(float radio)
        {
            float valorArea = (float)(Math.PI * Math.Pow(radio, 2));
            return valorArea;
        }
    }
    class Calculo
    {
        public static float area(float radio)
        {
            float valorArea = (float)(Math.PI * Math.Pow(radio, 2));
            return valorArea;
        }
    }
}