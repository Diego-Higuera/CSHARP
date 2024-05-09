using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA06
{
    class Principal
    {
        static void Main1(string[] args)
        {
            {
                Console.WriteLine("DOUBLE A INT");
                double x = 1.73; //PEQUEÑO
                int y = (int)x; //Cast
                Console.WriteLine(y);
            }
            {
                Console.WriteLine("LONG A INT");
                //long x = 1234567899999999999; //NO LO HACE
                long x = 1234;//PEQUEÑO
                int y = (int)x; //Cast
                Console.WriteLine(y);
            }
            {
                Console.WriteLine("INT A FLOAT");
                int x1 = 5; //PEQUEÑO
                int x2 = 3;
                float y = x1 / (float)x2;
                Console.WriteLine(y);
            }
            {
                Console.WriteLine("INT A DOUBLE");
                int x1 = 5; //PEQUEÑO
                int x2 = 3;
                double y = x1 / (double)x2;
                Console.WriteLine(y);
            }
            {
                Console.WriteLine("CHAR A STRING");
                char x = 'A';
                string y = x.ToString();
                Console.WriteLine(y);
            }
            {
                Console.WriteLine("STRING A CHAR");
                string x = "A";
                char y = x.ToCharArray()[0];
                Console.WriteLine(y);
            }
            {
                Console.WriteLine("STRING A VECTOR TIPO CHAR");
                string x = "HOLA";
                char[] y = x.ToCharArray();//{'H','O','L','A' }
                foreach (char c in y)
                {
                    Console.Write(c + "  ");
                }
            }
            {
                Console.WriteLine("VECTOR TIPO CHAR A STRING");
                char[] x = { 'H', 'O', 'L', 'A' };
                string y = new string(x);
                Console.WriteLine(y);
            }

        }
    }
}