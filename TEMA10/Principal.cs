using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA10
{
    class Principal
    {
        static void Main1(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Magenta;
            do
            {
                Cls();
                Console.WriteLine("MENU");
                Console.WriteLine("----");
                Console.WriteLine("[1] SUMAR DOS NUMEROS");
                Console.WriteLine("[2] MOSTRAR LA LONGITUD DE UNA CADENA");
                Console.WriteLine("[3] CONVERTIR CADENA A MAYUSCULA");
                Console.WriteLine("[4] PEDIR UN TEXTO Y CONTAR LA CANTIDAD DE VOCALES");
                Console.WriteLine("[5] CONTAR CANTIDAD DE CONSONANTES, VOCALES Y OTROS DE UN TEXTO EN ARCHIVO");
                Console.WriteLine("[0] SALIR");

                Console.Write("\nINGRESE OPCION? ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Cls();
                        Opcion1();
                        break;
                    case "2":
                        Cls();
                        Opcion2();
                        break;
                    case "3":
                        Cls();
                        Opcion3();
                        break;
                    case "4":
                        Cls();
                        Opcion4();
                        break;
                    case "5":
                        Cls();
                        Opcion5();
                        break;
                    case "0":
                        Cls();
                        Console.WriteLine("GRACIAS POR SU VISITA");
                        Pause();
                        Cls();
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }

        static void Cls()
        {
            Console.Clear();
        }

        static void Pause()
        {
            Console.Write("Presione una tecla para continuar...");
            Console.Read();
        }

        static void Opcion1()
        {
            Console.WriteLine("[1] SUMAR DOS NUMEROS");
            Console.WriteLine("---------------------");
            double numero1, numero2, suma;

            try
            {
                Console.Write("Ingresar número 1? ");
                numero1 = double.Parse(Console.ReadLine());
                Console.Write("Ingresar número 2? ");
                numero2 = double.Parse(Console.ReadLine());
                suma = numero1 + numero2;
                Console.WriteLine("Suma: " + suma);
            }
            catch (Exception e)
            {
                Console.WriteLine("ENTRADA INCORRECTA");
            }
            Pause();
        }

        static void Opcion2()
        {
            Console.WriteLine("[2] MOSTRAR LA LONGITUD DE UNA CADENA");
            Console.WriteLine("-------------------------------------");
            string texto;
            Console.Write("Ingresar cadena? ");
            texto = Console.ReadLine();
            Console.WriteLine("Longitud cadena: " + texto.Length);
            Pause();
        }

        static void Opcion3()
        {
            Console.WriteLine("[3] CONVERTIR CADENA A MAYUSCULA");
            Console.WriteLine("--------------------------------");
            string texto;
            Console.Write("Ingresar cadena? ");
            texto = Console.ReadLine();
            Console.WriteLine("Convertir cadena a mayuscula: " + texto.ToUpper());
            Pause();
        }

        static void Opcion4()
        {
            Console.WriteLine("[4] PEDIR UN TEXTO Y CONTAR LA CANTIDAD DE VOCALES");
            Console.WriteLine("--------------------------------------------------");
            string texto;
            Console.Write("Ingresar un texto? ");
            texto = Console.ReadLine();//La geopoliticA es la politica global
            texto = texto.ToLower();
            int[] contadorVector = new int[5];//0=a, 1=e, 2=i, 3=o, 4=u
            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] == 'a')
                {
                    contadorVector[0] = contadorVector[0] + 1;
                }
                if (texto[i] == 'e')
                {
                    contadorVector[1] = contadorVector[1] + 1;
                }
                if (texto[i] == 'i')
                {
                    contadorVector[2] = contadorVector[2] + 1;
                }
                if (texto[i] == 'o')
                {
                    contadorVector[3] = contadorVector[3] + 1;
                }
                if (texto[i] == 'u')
                {
                    contadorVector[4] = contadorVector[4] + 1;
                }
            }
            Console.WriteLine($"Cantidad Vocal a es {contadorVector[0]}");
            Console.WriteLine($"Cantidad Vocal e es {contadorVector[1]}");
            Console.WriteLine($"Cantidad Vocal i es {contadorVector[2]}");
            Console.WriteLine($"Cantidad Vocal o es {contadorVector[3]}");
            Console.WriteLine($"Cantidad Vocal u es {contadorVector[4]}");
            Pause();
        }

        static void Opcion5()
        {
            Console.WriteLine("[5] CONTAR CANTIDAD DE CONSONANTES, VOCALES Y OTROS DE UN TEXTO EN ARCHIVO");
            Console.WriteLine("--------------------------------------------------------------------------");
            // LEER TEXTO DEL ARCHIVO
            string rutaRelativa = "data/archivo.txt";
            string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
            Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);
            string fila = "";
            string texto = "";
            using (StreamReader sr = new StreamReader(rutaAbsoluta))//ABRIR
            {
                while ((fila = sr.ReadLine()) != null)
                {//LEER
                    texto = texto + fila;
                }
                sr.Close();//CERRAR
            }
            Console.WriteLine(texto);
            //EXPRESIONES REGULARES
            string patronAlfabeto = "[a-zA-ZñÑáéíóú]"; //Alfabeto Español
            string patronVocal = "[aeiouAEIOUáéíóú]";  //Vocal Español
            bool correctoAlfabeto, correctoVocal;
            int[] vectorContador = new int[3];//0=consonantes 1=vocales 2=otros
            for (int i = 0; i < texto.Length; i++)
            {
                correctoAlfabeto = Regex.IsMatch(texto[i].ToString(), patronAlfabeto);
                if (correctoAlfabeto)
                {
                    correctoVocal = Regex.IsMatch(texto[i].ToString(), patronVocal);
                    if (correctoVocal)
                    {
                        vectorContador[1] = vectorContador[1] + 1;
                    }
                    else
                    {
                        vectorContador[0] = vectorContador[0] + 1;
                    }
                }
                else
                {
                    vectorContador[2] = vectorContador[2] + 1;
                }

                //Console.WriteLine(correcto);
                //Pause();
            }
            Console.WriteLine("Cantidad Consonantes: " + vectorContador[0]);
            Console.WriteLine("Cantidad Vocales    : " + vectorContador[1]);
            Console.WriteLine("Cantidad Otros      : " + vectorContador[2]);

            Pause();
        }
    }
}