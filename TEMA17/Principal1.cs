using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PROYECTOCSHARP.TEMA17
{
    class Principal1
    {
        static void Main1(string[] args)
        {
            string rutaarchivo = "C:/sqlite3/probando.db"; //RUTA ABSOLUTA
            string cadena_conexion = $"Data Source={rutaarchivo};Version=3";
            /*
            CREATE TABLE TABLA1(ID TEXT, NOMBRE TEXT);
            INSERT INTO TABLA1(ID,NOMBRE) VALUES ('A1','Luis');
            INSERT INTO TABLA1(ID,NOMBRE) VALUES ('A2','Migueo');
            INSERT INTO TABLA1(ID,NOMBRE) VALUES ('A3','Carlos');
            INSERT INTO TABLA1(ID,NOMBRE) VALUES ('A4','Carla');
            INSERT INTO TABLA1(ID,NOMBRE) VALUES ('A5','María');
            SELECT * FROM TABLA1;

            CREATE TABLE TABLA2(ID VARCHAR(4), NOMBRE VARCHAR(20));
            INSERT INTO TABLA2(ID,NOMBRE) VALUES ('A1','Luis');
            INSERT INTO TABLA2(ID,NOMBRE) VALUES ('A2','Migueo');
            INSERT INTO TABLA2(ID,NOMBRE) VALUES ('A3','Carlos');
            INSERT INTO TABLA2(ID,NOMBRE) VALUES ('A4','Carla');
            INSERT INTO TABLA2(ID,NOMBRE) VALUES ('A5','María');
            */

            string query = "SELECT * FROM TABLA1";

            SQLiteConnection conexion = new SQLiteConnection(cadena_conexion);

            conexion.Open();

            SQLiteCommand comando = conexion.CreateCommand();


            comando.CommandText = query;

            SQLiteDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    string id = lector.GetString(0);
                    string nombre = lector.GetString(1);
                    Console.WriteLine("{0,4} {1, -10}", id, nombre);
                }
            }
            else
            {
                Console.WriteLine("TABLA VACIA");
            }
        }
    }
}