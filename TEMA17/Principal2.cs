using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace PROYECTOCSHARP.TEMA17
{
    class Principal2
    {
        static void Main1(string[] args)
        {
            //1. DEFINIR LA RUTA DE LA BASE DATOS(ARCHIVO)
            string ruta_absoluta = "C:\\sqlite3\\probando.db";
            //string ruta_absoluta = "C:/sqlite3/probando.db";
            if (File.Exists(ruta_absoluta))
            {
                Console.WriteLine("SI EXISTE");

                try
                {
                    string cadena_conexion = $"Data Source={ruta_absoluta};Version=3";
                    SQLiteConnection conexion = new SQLiteConnection(cadena_conexion);
                    conexion.Open();
                    Console.WriteLine("OK: CONEXION ");
                    MostrarTodosRegistrosTabla(conexion);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: CONEXION " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("NO EXISTE");
            }
        }

        static void MostrarTodosRegistrosTabla(SQLiteConnection conexion)
        {
            SQLiteCommand comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM TABLA1";
            SQLiteDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    string id = lector.GetString(0);
                    string nombre = lector.GetString(1);
                    Console.WriteLine("{0,4}        {1,-10}", id, nombre);
                }
            }
            else
            {
                Console.WriteLine("AVISO: TABLA VACIA");
            }

        }
    }
}