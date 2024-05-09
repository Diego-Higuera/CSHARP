using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA05
{
    class Principal5
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("EJEMPLO 1: MATRIZ NO SIMETRICA");
            Console.WriteLine("------------------------------");
            int[][] matriz1 =
            {
               new int[] { 1 },
               new int[] { 1, 2 },
               new int[] { 1, 2, 3 },
               new int[] { 1, 2, 3, 4 }
            };

            Principal5 objeto = new Principal5();
            objeto.imprimirMatriz(1, matriz1);
            objeto.imprimirMatriz(2, matriz1);

            Console.WriteLine("EJEMPLO 2: MATRIZ NO SIMETRICA");
            Console.WriteLine("------------------------------");
            int[][] matriz2 = new int[4][];

            matriz2[0] = new int[] { 1 };
            matriz2[1] = new int[] { 1, 2 };
            matriz2[2] = new int[] { 1, 2, 3 };
            matriz2[3] = new int[] { 1, 2, 3, 4 };

            objeto.imprimirMatriz(1, matriz2);
            objeto.imprimirMatriz(2, matriz2);

            Console.WriteLine("EJEMPLO 3: SUMAR LAS DOS MATRICES ANTERIORES NO SIMETRICA");
            Console.WriteLine("---------------------------------------------------------");
            // DECLARAR LA MATRIZ3 DE LA MISMA DIMENSION DE LAS 2 ANTERIORES
            int[][] matriz3 = new int[4][];
            int k = 1;
            for (int i = 0; i < matriz3.Length; i++)
            {
                matriz3[i] = new int[k];
                k++;
            }

            for (int i = 0; i < matriz3.Length; i++) //Filas
            {
                for (int j = 0; j < matriz3[i].Length; j++) //Columnas
                {
                    matriz3[i][j] = matriz1[i][j] + matriz2[i][j];
                }
            }

            objeto.imprimirMatriz(1, matriz3);

        }

        public void imprimirMatriz(int forma, int[][] matriz)
        {
            if (forma == 1) //Recorrer por indice
            {
                Console.WriteLine("(1) RECORRER UNA MATRIZ POR INDICE");
                for (int i = 0; i < matriz.Length; i++) //Filas
                {
                    for (int j = 0; j < matriz[i].Length; j++) //Columnas
                    {
                        Console.Write("{0, 4}", matriz[i][j]);
                    }
                    Console.WriteLine();
                }
            }
            if (forma == 2) //Recorrer por elemento
            {
                Console.WriteLine("(2) RECORRER UNA MATRIZ POR ELEMENTO");
                foreach (int[] fila in matriz)
                {
                    foreach (int elemento in fila)
                    {
                        Console.Write("{0, 4}", elemento);
                    }
                    Console.WriteLine();
                }
            }
        }


    }
}