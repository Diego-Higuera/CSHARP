using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA14
{
    class Calculo
    {
        public static string restaurante = "MERCADONA";
        //ATRIBUTOS
        //const double IVA = 0.15;
        readonly double IVA;
        double compra;


        //CONSTRUCTOR
        public Calculo(double valorCompra, double valoriva)
        {
            compra = valorCompra;
            IVA = valoriva;
        }

        //METODOS
        public double montoPagar()
        {
            return compra + compra * IVA;
        }

        public static string mensaje()
        {
            return "GRACIAS POR SU COMPRA";
        }

        private void clave()
        {
            string x = "123456";
        }
    }
}