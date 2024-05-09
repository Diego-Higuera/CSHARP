using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA05
{
    class Principal4
    {
        static void Main1(string[] args)
        {
            int[][] matriz =
            {
               new int[] { 5, 8, 9, 1 },
               new int[] { 8, 1, 2, 4 },
               new int[] { 1, 2, 3, 5 },
               new int[] { 1, 3, 8, 9 }
            };

            Console.WriteLine("MATRIZ CUADRADA"); //4X4
            for (int i = 0; i < matriz.Length; i++) //Número Filas
            {
                for (int j = 0; j < matriz[i].Length; j++) //Número Columnas
                {
                    Console.Write("{0,1},{1,1}={2,1}  ", i, j, matriz[i][j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("DIAGONAL MATRIZ CUADRADA"); //4X4
            for (int i = 0; i < matriz.Length; i++) //Número Filas
            {
                for (int j = 0; j < matriz[i].Length; j++) //Número Columnas
                {
                    if (i == j)
                    {
                        Console.Write("{0,1},{1,1}={2,1}  ", i, j, matriz[i][j]);
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("NUMEROS DEBAJO DE LA DIAGONAL MATRIZ CUADRADA"); //4X4
            for (int i = 0; i < matriz.Length; i++) //Número Filas
            {
                for (int j = 0; j < matriz[i].Length; j++) //Número Columnas
                {
                    if (j < i)
                    {
                        Console.Write("{0,1},{1,1}={2,1}  ", i, j, matriz[i][j]);
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("NUMEROS ARRIBA DE LA DIAGONAL MATRIZ CUADRADA"); //4X4
            for (int i = 0; i < matriz.Length; i++) //Número Filas
            {
                for (int j = 0; j < matriz[i].Length; j++) //Número Columnas
                {
                    if (j > i)
                    {
                        Console.Write("{0,1},{1,1}={2,1}  ", i, j, matriz[i][j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}