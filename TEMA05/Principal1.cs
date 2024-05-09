using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA05
{
    class Principal1
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("ARRAY DE UNA DIMENSION: VECTOR"); //6 serie
            int[] vector = { 5, 8, 9, 1 };
            for (int i = 0; i < vector.Length; i++)
            {
                Console.WriteLine($"vector[{i}] = {vector[i]}");
            }


            Console.WriteLine("ARRAY DE DOS DIMENSIONES: MATRIZ"); //2x4 filasxcolumnas
            int[][] matriz =
            {
               new int[] { 5, 8, 9, 1 },
               new int[] { 8, 1, 2, 4 }
            };

            for (int i = 0; i < matriz.Length; i++) //Número Filas
            {
                for (int j = 0; j < matriz[i].Length; j++) //Número Columnas
                {
                    Console.WriteLine($"matriz[{i}][{j}] = {matriz[i][j]}");
                }
            }


            Console.WriteLine("ARRAY DE TRES DIMENSIONES: CUBO"); //2x2x4  numeromatriz x filas x columnas
            int[][][] cubo =
            {
                new int[][]
                {
                   new int[] { 5, 8, 9, 1 },
                   new int[] { 8, 1, 2, 4 }
                },
                new int[][]
                {
                   new int[] { 5, 1, 9, 5 },
                   new int[] { 8, 2, 2, 4 }
                }
            };

            for (int i = 0; i < cubo.Length; i++) //Número de matrices
            {
                for (int j = 0; j < cubo[i].Length; j++) //Número filas
                {
                    for (int k = 0; k < cubo[i][j].Length; k++) //Número columnas
                    {
                        Console.WriteLine($"cubo[{i}][{j}][{k}] = {cubo[i][j][k]}");
                    }
                }
            }

        }
    }
}