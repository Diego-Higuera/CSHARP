using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA23
{
    class Principal
    {
        static void Main1()
        {
            List<FiguraGeometrica> list_figurasgeometricas = new List<FiguraGeometrica>();

            list_figurasgeometricas.Add(new Triangulo { base1 = 5, altura = 2.1 });
            list_figurasgeometricas.Add(new Circulo { radio = 3.1 });
            list_figurasgeometricas.Add(new Circulo { radio = 4.1 });
            list_figurasgeometricas.Add(new Circulo { radio = 5.1 });
            list_figurasgeometricas.Add(new Triangulo { base1 = 7.2, altura = 5.5 });

            foreach (FiguraGeometrica fg in list_figurasgeometricas)
            {
                Console.WriteLine(fg.Area());
            }
        }
    }

    public class FiguraGeometrica
    {

        public virtual double Area()
        {
            return 0;
        }

    }

    public class Triangulo : FiguraGeometrica
    {
        public double base1;
        public double altura;

        public override double Area()
        {
            return this.base1 * this.altura / 2;
        }

    }

    public class Circulo : FiguraGeometrica
    {
        public double radio;

        public override double Area()
        {
            return Math.PI * this.radio * this.radio;
        }
    }


}