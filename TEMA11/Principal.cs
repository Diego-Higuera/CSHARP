using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA11
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
                Console.WriteLine("[1] MOSTRAR TODAS LAS CATEGORIAS");
                Console.WriteLine("[2] MOSTRAR LOS TRATAMIENTOS POR CATEGORIA");
                Console.WriteLine("[3] MOSTRAR TODAS LAS ESTETECISTAS");
                Console.WriteLine("[4] MOSTRAR EL DINERO GENERADO POR CADA ESTETICISTA");
                Console.WriteLine("[5] MOSTRAR EL DINERO GENERADO POR CADA MES");
                Console.WriteLine("[6] MOSTRAR EL TRATAMIENTO CON MAYOR DEMANDA");
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
                    case "6":
                        Cls();
                        Opcion6();
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
            Console.WriteLine("[1] MOSTRAR TODAS LAS CATEGORIAS");
            Console.WriteLine("--------------------------------");
            SortedSet<string> categorias = new SortedSet<string>();

            string rutaRelativa = "data/Estetica.csv";
            string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
            //Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);
            string fila = "";
            using (StreamReader sr = new StreamReader(rutaAbsoluta))//ABRIR
            {
                while ((fila = sr.ReadLine()) != null)
                {//LEER
                    string[] partes = fila.Split(';');
                    categorias.Add(partes[2]);
                }
                sr.Close();//CERRAR
                foreach (String s in categorias)
                {
                    if (s != "CATEGORIA")
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            Pause();
        }

        static void Opcion2()
        {
            Console.WriteLine("[2] MOSTRAR LOS TRATAMIENTOS POR CATEGORIA");
            Console.WriteLine("------------------------------------------");
            SortedSet<string> tratamientos = new SortedSet<string>();

            Console.WriteLine("Ingrese nombre categoría? ");
            string categoria = Console.ReadLine();

            string rutaRelativa = "data/Estetica.csv";
            string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
            //Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);
            string fila = "";
            using (StreamReader sr = new StreamReader(rutaAbsoluta))//ABRIR
            {
                while ((fila = sr.ReadLine()) != null)
                {//LEER
                    string[] partes = fila.Split(';');
                    if (partes[2] != categoria)
                    {
                        tratamientos.Add(partes[3]);
                    }
                }
                sr.Close();//CERRAR
                foreach (String s in tratamientos)
                {
                    if (s != "TRATAMIENTO")
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            Pause();
        }

        static void Opcion3()
        {
            Console.WriteLine("[3] MOSTRAR TODAS LAS ESTETECISTAS");
            Console.WriteLine("----------------------------------");
            SortedSet<string> esteticistas = new SortedSet<string>();

            string rutaRelativa = "data/Estetica.csv";
            string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
            //Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);
            string fila = "";
            using (StreamReader sr = new StreamReader(rutaAbsoluta))//ABRIR
            {
                while ((fila = sr.ReadLine()) != null)
                {//LEER
                    string[] partes = fila.Split(';');
                    esteticistas.Add(partes[4]);
                }
                sr.Close();//CERRAR
                foreach (String s in esteticistas)
                {
                    if (s != "ESTETICISTA")
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            Pause();
        }

        static void Opcion4()
        {
            Console.WriteLine("[4] MOSTRAR EL DINERO GENERADO POR CADA ESTETICISTA");
            Console.WriteLine("---------------------------------------------------");
            SortedSet<string> esteticistas = new SortedSet<string>();

            string rutaRelativa = "data/Estetica.csv";
            string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
            //Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);
            string fila = "";
            using (StreamReader sr = new StreamReader(rutaAbsoluta))//ABRIR
            {
                while ((fila = sr.ReadLine()) != null)
                {//LEER
                    string[] partes = fila.Split(';');
                    esteticistas.Add(partes[4]);
                }
                sr.Close();//CERRAR

                foreach (String s in esteticistas)
                {
                    if (s != "ESTETICISTA")
                    {
                        Console.WriteLine(s + "  " + montoTotal(s, rutaAbsoluta));
                    }
                }
            }

            Pause();
        }

        static double montoTotal(string esteticista, string rutaAbsoluta)
        {
            string fila = "";
            double monto = 0.0;
            using (StreamReader sr = new StreamReader(rutaAbsoluta))//ABRIR
            {
                while ((fila = sr.ReadLine()) != null)
                {//LEER
                    string[] partes = fila.Split(';');
                    if (partes[4] == esteticista)
                    {
                        monto = monto + double.Parse(partes[5]);
                    }
                }
                sr.Close();//CERRAR

            }
            return monto;
        }

        static void Opcion5()
        {
            Console.WriteLine("[5] MOSTRAR EL DINERO GENERADO POR CADA MES");
            Console.WriteLine("-------------------------------------------");
            try
            {
                SortedSet<string> meses = new SortedSet<string>();

                string rutaRelativa = "data/Estetica1.csv";
                string rutaAbsoluta = Path.GetFullPath(rutaRelativa);

                string fila = "";
                int i = 0;
                using (StreamReader sr = new StreamReader(rutaAbsoluta))//ABRIR
                {
                    while ((fila = sr.ReadLine()) != null)
                    {//LEER
                        if (i != 0)
                        {
                            string[] partes = fila.Split(';');
                            string mes = partes[1].ToString().Substring(5, 2);
                            meses.Add(mes);
                        }
                        i++;
                    }
                    sr.Close();//CERRAR

                    foreach (String mes in meses)
                    {
                        Console.WriteLine("{0,3} {1,12}", mes, montoTotal5(mes, rutaAbsoluta));
                    }
                }
                Pause();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: LECTURA");
                Pause();
            }
        }
        static double montoTotal5(string mes, string rutaAbsoluta)
        {
            string fila = "";
            double monto = 0.0;
            int i = 0;
            using (StreamReader sr = new StreamReader(rutaAbsoluta))//ABRIR
            {
                while ((fila = sr.ReadLine()) != null) //LEER
                {
                    if (i != 0)
                    {
                        string[] partes = fila.Split(';');
                        string[] fecha = partes[1].Split('-');
                        if (fecha[1] == mes)
                        {
                            monto = monto + double.Parse(partes[5]);
                        }
                    }
                    i++;
                }
                sr.Close();//CERRAR
            }
            return monto;
        }

        static void Opcion6()
        {
            Console.WriteLine("[6] MOSTRAR EL TRATAMIENTO CON MAYOR DEMANDA");
            Console.WriteLine("--------------------------------------------");
            //PARA OBTENER LOS TRATAMIENTOS DISTINTOS
            SortedSet<string> tratamientos = new SortedSet<string>();

            string rutaRelativa = "data/Estetica.csv";
            string rutaAbsoluta = Path.GetFullPath(rutaRelativa);

            string fila = "";
            int i = 0;
            using (StreamReader sr = new StreamReader(rutaAbsoluta))//ABRIR
            {
                while ((fila = sr.ReadLine()) != null) //LEER
                {
                    if (i != 0)
                    {
                        string[] partes = fila.Split(';');
                        tratamientos.Add(partes[3]);
                    }
                    i++;
                }
                sr.Close();//CERRAR
            }
            //PASAR LA COLECCION SORETEDSET A UN VECTOR TRATAMIENTOS DISTINTOS Y NUESTRO VECTOR CONTADOR DE CADA TRATAMIENTO
            int j = 0;
            string[] tratamientosDistintos = new string[tratamientos.Count];
            int[] contador = new int[tratamientos.Count];
            foreach (string t in tratamientos)
            {
                tratamientosDistintos[j] = t;
                j++;

            }
            //CREAR UN ARRAY DE CADENAS PARA GUARDAR LOS TRATAMIENTOS
            for (int k = 0; k < tratamientosDistintos.Length; k++)
            {
                i = 0;
                using (StreamReader sr1 = new StreamReader(rutaAbsoluta))//ABRIR
                {
                    while ((fila = sr1.ReadLine()) != null) //LEER
                    {
                        if (i != 0)
                        {
                            string[] partes = fila.Split(';');
                            if (tratamientosDistintos[k] == partes[3])
                            {
                                contador[k] = contador[k] + 1;
                            }
                        }
                        i++;
                    }
                    sr1.Close();//CERRAR
                }
            }//FIN FOR
             //MOSTRAR EL RESULTADO DEL VECTOR CONTADOR POR CADA TRATAMIENTO
            for (int k = 0; k < tratamientosDistintos.Length; k++)
            {
                Console.WriteLine("{0,-40} {1,0}", tratamientosDistintos[k], contador[k]);
            }
            //CALCULAR EL TRATAMIENTO CON LA MAYOR DEMANDA
            int mayor = contador[0];
            int posicion = 0;
            for (int m = 0; m < contador.Length; m++)
            {
                if (contador[m] > mayor)
                {
                    mayor = contador[m];
                    posicion = m;
                }
            }
            Console.WriteLine("TRATIMIENTO CON MAYOR DEMANDA: " + tratamientosDistintos[posicion] + "\t" + mayor);
            int s = 0;
            for (int m = 0; m < contador.Length; m++)
            {
                s = s + contador[m];
            }
            Console.WriteLine("Numero total de transacciones: " + s);
            Pause();

        }

    }
}
