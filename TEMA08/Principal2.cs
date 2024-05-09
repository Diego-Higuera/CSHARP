using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA08
{
    class Principal2
    {
        static void Main1(String[] args)
        {
            Console.WriteLine("EJEMPLO SPLIT");
            string registrocsv = "A1;Luis;32;1.72;true";
            string[] partes = registrocsv.Split(';');
            foreach (string x in partes)
            {
                Console.WriteLine(x);
            }
        }

    }
}