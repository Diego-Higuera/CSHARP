using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA17
{
    class Principal4
    {
        static void Main1()
        {
            try
            {
                string ruta_relativa = "data/centrobelleza.sqlite";
                string ruta_absoluta = Path.GetFullPath(ruta_relativa);

                string cadena_conexion = $"Data Source={ruta_absoluta}";

                SQLiteConnection conexion = new SQLiteConnection(cadena_conexion);

                conexion.Open();

                SQLiteCommand comando = conexion.CreateCommand();

                Console.WriteLine("MONTO ACUMULADO POR CADA TRATAMIENTO");
                Console.WriteLine("------------------------------------");
                comando.CommandText = "SELECT tratamiento, sum(precio) " +
                                      "FROM Estetica " +
                                      "GROUP BY tratamiento";

                SQLiteDataReader lector;

                lector = comando.ExecuteReader();//Abrir lector

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        string tratamiento = lector.GetString(0);
                        double monto = lector.GetDouble(1);
                        Console.WriteLine("{0,-40} {1,10:0.00}", tratamiento, monto);
                    }
                }
                else
                {
                    Console.WriteLine("AVISO: TABLA VACIA");
                }
                lector.Close(); //Cerrar lector

                Console.WriteLine("EL TRATAMIENTO CON MAYOR RENDIMIENTO EN MONTO");
                Console.WriteLine("---------------------------------------------");
                comando.CommandText = "SELECT tratamiento, sum(precio) " +
                                      "FROM Estetica " +
                                      "GROUP BY tratamiento " +
                                      "HAVING sum(precio) = (SELECT sum(precio) AS MONTO " +
                                      "FROM Estetica " +
                                      "GROUP BY tratamiento " +
                                      "ORDER BY MONTO DESC " +
                                      "LIMIT 1)";

                lector = comando.ExecuteReader();//Abrir lector

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        string tratamiento = lector.GetString(0);
                        double monto = lector.GetDouble(1);
                        Console.WriteLine("{0,-40} {1,10:0.00}", tratamiento, monto);
                    }
                }
                else
                {
                    Console.WriteLine("AVISO: TABLA VACIA");
                }
                lector.Close(); //Cerrar lector

            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}