using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Crud.Order.Types;

namespace PROYECTOCSHARP.TEMA20.ejemplo2
{
    class Principal
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("EJEMPLO 1: MOSTRAR JSON EN FORMA DE TABLA");
            Console.WriteLine("-----------------------------------------");
            string ruta_relativa = "data/Empleados.json";
            List<Empleado> empleados = ObtenerListaEmpleados(ruta_relativa);
            Empleado.Cabecera();
            foreach (Empleado empleado in empleados)
            {
                empleado.Cuerpo();
            }
            Console.WriteLine("EJEMPLO 2: BUSCAR EMPLEADOS CON HOBBI VIAJAR");
            Console.WriteLine("--------------------------------------------");
            Empleado.Cabecera();
            foreach (Empleado empleado in empleados)
            {
                foreach (string hobby in empleado.hobbies)
                {
                    if (hobby == "Viajar")
                    {
                        empleado.Cuerpo();
                    }
                }
            }
            Console.WriteLine("EJEMPLO 3: ESCRIBIR ARCHIVO JSON");
            Console.WriteLine("--------------------------------");
            string ruta_relativa1 = "data/Emepleados1.json";
            EscribirJson(ruta_relativa1);
            Console.WriteLine("EJEMPLO 4: CONVERTIR ARCHIVO CSV A JSON");
            Console.WriteLine("---------------------------------------");
            string ruta_relativa_escribir_json = "data/Emepleados2.json";
            string ruta_relativa_leer_csv = "data/Empleados.csv";
            ConvertirCsvToJson(ruta_relativa_leer_csv, ruta_relativa_escribir_json);
            Console.WriteLine("EJEMPLO 5: CONVERTIR ARCHIVO JSON A SQL");
            Console.WriteLine("---------------------------------------");
            string ruta_relativa_json = "data/Emepleados2.json";
            ConvertirJsonToSql(ruta_relativa_json);

        }

        public static List<Empleado> ObtenerListaEmpleados(string ruta_relativa)
        {
            List<Empleado> empleados = null;

            try
            {
                if (File.Exists(ruta_relativa))
                {
                    string json = File.ReadAllText(ruta_relativa);
                    //Console.WriteLine(json);
                    empleados = JsonConvert.DeserializeObject<List<Empleado>>(json);
                }
                else
                {
                    Console.WriteLine("ERROR: ARCHIVO NO EXISTE");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: LEER ARCHIVO");
            }
            return empleados;
        }

        public static void EscribirJson(string ruta_relativa)
        {
            List<Empleado> empleados = new List<Empleado>
            { // ABRI LISTA EMPLEADOS
                new Empleado
                {
                    idEmpleado = "E1",
                    nombre =  "Juan",
                    estatura = 1.72,
                    casado = true,
                    sexo = 'H',
                    direccion = new Direccion
                    {
                      calle = "Av. América",
                      numero = 123,
                      ciudad =  "Madrid"
                    },
                    hobbies = new List<string>  {"Fútbol","Pintura","Viajar"}
                },
                new Empleado
                {
                    idEmpleado = "E2",
                    nombre = "Carmen",
                    estatura = 1.71,
                    casado = false,
                    sexo = 'M',
                    direccion = new Direccion
                    {
                      calle = "Av. Ejercito",
                      numero = 566,
                      ciudad = "Sevilla",
                    },
                    hobbies = new List<string> { "Ajedrez", "Damas" }
                }
            }; //CERRAR LISTA EMPLEADOS
            string json = JsonConvert.SerializeObject(empleados, Formatting.Indented);
            try
            {
                File.WriteAllText(ruta_relativa, json); //ESCRITURA
                Console.WriteLine("OK: ESCRIBIR ARCHIVO JSON");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: ESCRIBIR ARCHIVO JSON " + ex.Message);
            }
        }

        public static void ConvertirCsvToJson(string ruta_relativa_leer_csv, string ruta_relativa_escribir_json)
        {
            List<Empleado> empleados = new List<Empleado>();
            try
            {
                string fila;
                string[] partes;
                string[] partesdireccion;
                string[] parteshobbies;
                using (StreamReader sr = new StreamReader(ruta_relativa_leer_csv))
                {
                    int i = 0;
                    while ((fila = sr.ReadLine()) != null)
                    {
                        if (i != 0)
                        {
                            partes = fila.Split(';');
                            string idEmpleado = partes[0];
                            string nombre = partes[1];

                            string caracter = ".";
                            partes[2] = partes[2].Replace(caracter, ",");

                            double estatura = double.Parse(partes[2]);

                            bool casado = bool.Parse(partes[3]);
                            char sexo = Convert.ToChar(partes[4]);

                            partesdireccion = partes[5].Split(',');
                            string calle = partesdireccion[0];
                            int numero = int.Parse(partesdireccion[1]);
                            string ciudad = partesdireccion[2];
                            Direccion direccion = new Direccion(calle, numero, ciudad);

                            parteshobbies = partes[6].Split(',');
                            List<string> hobbies = new List<string>();
                            foreach (string s in parteshobbies)
                            {
                                hobbies.Add(s);
                            }

                            Empleado empleado = new Empleado(idEmpleado, nombre, estatura, casado, sexo, direccion, hobbies);
                            empleados.Add(empleado);
                        }
                        i++;
                    }
                    string json = JsonConvert.SerializeObject(empleados, Formatting.Indented);
                    try
                    {
                        File.WriteAllText(ruta_relativa_escribir_json, json); //ESCRITURA
                        Console.WriteLine("OK: ESCRIBIR ARCHIVO JSON");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: ESCRIBIR ARCHIVO JSON" + ex.Message);
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: CONVERTIR CSV TO JSON " + ex.Message);
            }

        }

        public static void ConvertirJsonToSql(string ruta_relativa)
        {
            string database = "empleadosjson";
            string cadena_conexion = "Server=localhost;" +
                                     "Port=3307;" +
                                     "Database=" + database +
                                     ";Uid=root;" +
                                     "Pwd=12345678;";

            try
            {
                List<Empleado> empleados = ObtenerListaEmpleados(ruta_relativa);
                int i = 1;
                string query1 = "INSERT INTO Direccion(idDireccion,calle,numero,ciudad) VALUES (@idDireccion,@calle,@numero,@ciudad)";
                string query2 = "INSERT INTO Empleado(idEmpleado,nombre,estatura,casado,sexo,idDireccion) VALUES (@idEmpleado,@nombre,@estatura,@casado,@sexo,@idDireccion)";

                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                conexion.Open();
                MySqlCommand comando1 = conexion.CreateCommand();
                MySqlCommand comando2 = conexion.CreateCommand();

                comando1.CommandText = query1;
                comando1.Parameters.AddWithValue("@idDireccion", "");
                comando1.Parameters.AddWithValue("@calle", "");
                comando1.Parameters.AddWithValue("@numero", 0);
                comando1.Parameters.AddWithValue("@ciudad", "");

                comando2.CommandText = query2;
                comando2.Parameters.AddWithValue("@idEmpleado", "");
                comando2.Parameters.AddWithValue("@nombre", "");
                comando2.Parameters.AddWithValue("@estatura", 0.0);
                comando2.Parameters.AddWithValue("@casado", false);
                comando2.Parameters.AddWithValue("@sexo", "");
                comando2.Parameters.AddWithValue("@idDireccion", "");



                foreach (Empleado empleado in empleados)
                {
                    string idEmpleado = empleado.idEmpleado;
                    string nombre = empleado.nombre;
                    double estatura = empleado.estatura;
                    bool casado = empleado.casado;
                    char sexo = empleado.sexo;
                    Direccion direccion = empleado.direccion;
                    string idDireccion = "D" + i;
                    // INSERT TABLA DIRECCION
                    comando1.Parameters["@idDireccion"].Value = idDireccion;
                    comando1.Parameters["@calle"].Value = direccion.calle;
                    comando1.Parameters["@numero"].Value = direccion.numero;
                    comando1.Parameters["@ciudad"].Value = direccion.ciudad;

                    int n = comando1.ExecuteNonQuery();
                    if (n == 1)
                    {
                        Console.WriteLine("OK: INSERT");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: INSERT");
                    }
                    // INSERT TABLA EMPLEADO
                    comando2.Parameters["@idEmpleado"].Value = idEmpleado;
                    comando2.Parameters["@nombre"].Value = nombre;
                    comando2.Parameters["@estatura"].Value = estatura;
                    comando2.Parameters["@casado"].Value = casado;
                    comando2.Parameters["@sexo"].Value = sexo;
                    comando2.Parameters["@idDireccion"].Value = idDireccion;

                    n = comando2.ExecuteNonQuery();
                    if (n == 1)
                    {
                        Console.WriteLine("OK: INSERT");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: INSERT");
                    }

                    i++;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: CONVERTIR JSON TO SQL " + ex.Message);
            }

        }
    }
}






