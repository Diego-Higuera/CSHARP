using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA18
{
    class Principal1
    {
        static void Main1(string[] args)
        {
            string ruta_relativa2 = "data/Estetica.csv";
            string ruta_absoluta2 = Path.GetFullPath(ruta_relativa2);

            if (File.Exists(ruta_absoluta2))
            {
                Console.WriteLine("SI EXISTE CSV");
                List<string> estetica = obtenerTodasFilasArchivo(ruta_absoluta2);//Leer archivo
                bool bandera = insertarRegistrosTabla(estetica);//Insertar archivo en sqlite
                if (bandera == false)
                {
                    Console.WriteLine("ERROR: INSERT");
                }

            }
            else
            {
                Console.WriteLine("NO EXISTE SQLITE/CSV");
            }
        }

        static List<string> obtenerTodasFilasArchivo(String ruta_absoluta)
        {
            List<string> estetica = new List<string>();
            StreamReader sr = new StreamReader(ruta_absoluta);
            string fila = "";
            int i = 0;
            while ((fila = sr.ReadLine()) != null)
            {
                if (i != 0)
                {
                    estetica.Add(fila);
                }
                i++;
            }
            return estetica;
        }

        static bool insertarRegistrosTabla(List<string> estetica)
        {
            bool bandera = true;
            try
            {

                //PARAMETROS DE CONEXION CON MYSQL
                string server = "localhost"; //127.0.0.1
                string database = "centrobelleza";
                string uid = "root";
                string password = "12345678";
                int port = 3306; // Puerto MySQL predeterminado
                                 //CONSTRUIR LA CADENA DE CONEXION
                string cadena_conexion = $"Server={server};" +
                                          $"Port={port};" +
                                          $"Database={database};" +
                                          $"Uid={uid};" +
                                          $"Pwd={password};";

                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                conexion.Open();
                MySqlCommand comando = conexion.CreateCommand();
                string query = "INSERT INTO Estetica(id,fecha,categoria,tratamiento,esteticista,precio,descuento) " +
                               "VALUES (@id,@fecha,@categoria,@tratamiento,@esteticista,@precio,@descuento)";
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@id", "");
                comando.Parameters.AddWithValue("@fecha", "");
                comando.Parameters.AddWithValue("@categoria", "");
                comando.Parameters.AddWithValue("@tratamiento", "");
                comando.Parameters.AddWithValue("@esteticista", "");
                comando.Parameters.AddWithValue("@precio", "");
                comando.Parameters.AddWithValue("@descuento", "");
                foreach (string fila in estetica)
                {
                    //Console.WriteLine(fila);
                    string[] partes = fila.Split(';');
                    comando.Parameters["@id"].Value = partes[0];
                    comando.Parameters["@fecha"].Value = partes[1];
                    comando.Parameters["@categoria"].Value = partes[2];
                    comando.Parameters["@tratamiento"].Value = partes[3];
                    comando.Parameters["@esteticista"].Value = partes[4];
                    comando.Parameters["@precio"].Value = partes[5];
                    comando.Parameters["@descuento"].Value = partes[6];
                    int n = comando.ExecuteNonQuery();
                    if (n == 1)
                    {
                        Console.WriteLine("OK: INSERT " + n);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: INSERT " + n);
                    }

                }
            }
            catch (Exception ex)
            {
                bandera = false;
            }
            //conexion.Close();
            return bandera;
        }
    }
}

/*
 
CREATE TABLE Estetica(
  id          INTEGER PRIMARY KEY,
  fecha       TEXT,
  categoria   TEXT,
  tratamiento TEXT,
  esteticista TEXT,
  precio      REAL,
  descuento   REAL
);
*/