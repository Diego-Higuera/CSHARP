using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA13
{
    class Principal
    {

        static void Main1(string[] args)
        {
            //PARAMETROS DE CONEXION CON MYSQL
            string server = "localhost"; //127.0.0.1
            string database = "instituto";
            string uid = "root";
            string password = "12345678";
            int port = 3307; // Puerto MySQL predeterminado
            //CONSTRUIR LA CADENA DE CONEXION
            string connectionString = $"Server={server};" +
                                      $"Port={port};" +
                                      $"Database={database};" +
                                      $"Uid={uid};" +
            $"Pwd={password};";
            MySqlConnection conexion = new MySqlConnection(connectionString);



            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Magenta;
            do
            {
                Cls();
                Console.WriteLine("MENU");
                Console.WriteLine("----");
                Console.WriteLine("[1] MOSTRAR TODOS LOS ALUMNOS DE UNA TABLA");
                Console.WriteLine("[2] BUSCAR UN ALUMNO POR SU ID");
                Console.WriteLine("[3] INSERTAR LOS DATOS DE UN ALUMNO");
                Console.WriteLine("[4] ELIMINAR UN ALUMNO POR SU ID");
                Console.WriteLine("[5] ACTUALIZAR LOS DATOS DE UN ALUMNO");
                Console.WriteLine("[6] MOSTRAR LAS ASIGNATURAS POR MODULO");
                Console.WriteLine("[0] SALIR");

                Console.Write("\nINGRESE OPCION? ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Cls();
                        Opcion1(conexion);
                        Pause();
                        break;
                    case "2":
                        Cls();
                        Opcion2(conexion);
                        Pause();
                        break;
                    case "3":
                        Cls();
                        Opcion3(conexion);
                        Pause();
                        break;
                    case "4":
                        Cls();
                        Opcion4(conexion);
                        Pause();
                        break;
                    case "5":
                        Cls();
                        Opcion5(conexion);
                        Pause();
                        break;
                    case "6":
                        Cls();
                        Opcion6(conexion);
                        Pause();
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

        static void Opcion1(MySqlConnection conexion)
        {
            Console.WriteLine("[1] MOSTRAR TODOS LOS ALUMNOS EN UNA TABLA");
            Console.WriteLine("------------------------------------------");
            try
            {
                conexion.Open();//ABRIR CONEXION
                string query = "SELECT * FROM Alumno";//DECLARAR LA QUERY
                MySqlCommand comando = new MySqlCommand(query, conexion);//PREPARAR LA QUERY
                MySqlDataReader leer = comando.ExecuteReader();//EJECUTAR LA QUERY
                Console.WriteLine("{0,10} {1,-10} {2,-10} {3,10} {4,10}", "IDLUMNO",
                                                                          "NOMBRE",
                                                                          "APELLIDO",
                                                                          "NACIMIENTO",
                                                                          "EXPEDIENTE");
                Console.WriteLine("{0,10} {1,-10} {2,-10} {3,10} {4,10}", "-------",
                                                                          "------",
                                                                          "--------",
                                                                          "----------",
                                                                          "----------");
                while (leer.Read())//RECUPERAR LOS REGISTROS
                {
                    Console.WriteLine("{0,10} {1,-10} {2,-10} {3,10} {4,10}", leer.GetInt32(0),
                                                                              leer.GetString(1),
                                                                              leer.GetString(2),
                                                                              leer.GetString(3),
                                                                              leer.GetString(4));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: LECTURA");
            }
            finally
            {
                conexion.Close(); // Cerrar la conexión
            }

        }
        static void Opcion2(MySqlConnection conexion)
        {
            Console.WriteLine("[2] BUSCAR UN ALUMNO POR SU ID");
            Console.WriteLine("------------------------------");

            try
            {
                conexion.Open();
                Console.Write("Ingrese id del alumno? ");
                int idAlumnoBuscar = int.Parse(Console.ReadLine());

                string query = "SELECT * FROM Alumno WHERE idAlumno = @idAlumnoBuscar";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idAlumnoBuscar", idAlumnoBuscar);
                MySqlDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {

                    while (lector.Read())
                    {
                        Console.WriteLine("{0,10} {1,-10} {2,-10} {3,10} {4,10}", lector.GetInt32(0),
                                                                          lector.GetString(1),
                                                                          lector.GetString(2),
                                                                          lector.GetString(3),
                                                                          lector.GetString(4));
                    }
                }
                else
                {
                    Console.WriteLine("AVISO: ALUMNO NO EXISTE");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: LECTURA");
            }
            finally
            {
                conexion.Close(); // Cerrar la conexión
            }

        }
        static void Opcion3(MySqlConnection conexion)
        {
            Console.WriteLine("[3] INSERTAR LOS DATOS DE UN ALUMNO");
            Console.WriteLine("-----------------------------------");
            try
            {
                conexion.Open();
                Console.Write("Ingrese el nombre del alumno: ");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese el apellido del alumno: ");
                string apellidos = Console.ReadLine();

                Console.Write("Ingrese fecha de nacimiento aaaa-mm-dd del alumno: ");
                string fechaNacimiento = Console.ReadLine();

                Console.Write("Ingrese número expediente A001 del alumno: ");
                string numeroExpediente = Console.ReadLine();

                string query = "INSERT INTO ALUMNO(nombre, apellidos, fecha_nacimiento, numeroExpediente) " +
                               "VALUES(@nombre, @apellidos, @fecha_nacimiento, @numeroExpediente)"; // DECLARAR LA QUERY
                MySqlCommand comando = new MySqlCommand(query, conexion); // PREPARAR LA QUERY
                comando.Parameters.AddWithValue("@nombre", nombre); // ASIGNAR VALORES PARAMETROS QUERY
                comando.Parameters.AddWithValue("@apellidos", apellidos);
                comando.Parameters.AddWithValue("@fecha_nacimiento", fechaNacimiento);
                comando.Parameters.AddWithValue("@numeroExpediente", numeroExpediente);
                int filasAfectadas = comando.ExecuteNonQuery(); // EJECUTAR LA QUERY
                if (filasAfectadas > 0)
                {
                    Console.WriteLine("AVISO: INSERCION OK");
                }
                else
                {
                    Console.WriteLine("AVISO: INSERCION ERROR");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: INSERTAR" + ex.Message);
            }
            finally
            {
                conexion.Close(); // Cerrar la conexión
            }
        }
        static void Opcion4(MySqlConnection conexion)
        {
            Console.WriteLine("[4] ELIMINAR UN ALUMNO POR SU ID");
            Console.WriteLine("--------------------------------");

            try
            {
                conexion.Open();
                Console.WriteLine("Ingresar id del alumno a eliminar? ");
                int idAlumnoEliminar = int.Parse(Console.ReadLine());

                string query = "DELETE FROM Alumno WHERE idAlumno = @idAlumnoEliminar"; //DECLARAR QUERY
                MySqlCommand comando = new MySqlCommand(query, conexion); // PREPARAR LA QUERY
                comando.Parameters.AddWithValue("@idAlumnoEliminar", idAlumnoEliminar);
                int filasAfectadas = comando.ExecuteNonQuery(); // EJECUTAR QUERY
                if (filasAfectadas > 0)
                {
                    Console.WriteLine("AVISO: DELETE OK");
                }
                else
                {
                    Console.WriteLine("AVISO: DELETE ERROR");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: ELIMINAR " + ex.Message);
            }
            finally
            {
                conexion.Close(); // Cerrar la conexión
            }
        }
        static void Opcion5(MySqlConnection conexion)
        {
            Console.WriteLine("[5] ACTUALIZAR LOS DATOS DE UN ALUMNO");
            Console.WriteLine("-------------------------------------");

            try
            {
                conexion.Open();
                Console.Write("Ingrese el ID del alumno que desea actualizar: ");
                int idAlumno = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nuevo nombre del alumno: ");
                string nuevoNombre = Console.ReadLine();

                Console.Write("Ingrese el nuevo apellido del alumno: ");
                string nuevoApellido = Console.ReadLine();

                Console.Write("Ingrese la nueva fecha de nacimiento del alumno: ");
                string nuevaFechaNacimiento = Console.ReadLine();

                Console.Write("Ingrese el nuevo número de expediente del alumno: ");
                string nuevoNumeroExpediente = Console.ReadLine();

                string query = "UPDATE Alumno SET nombre = @nuevoNombre, apellidos = @nuevoApellido," +
                               " fecha_nacimiento = @nuevaFechaNacimiento," +
                               " numeroExpediente = @nuevoNumeroExpediente WHERE idAlumno = @idAlumno";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                comando.Parameters.AddWithValue("@nuevoApellido", nuevoApellido);
                comando.Parameters.AddWithValue("@nuevaFechaNacimiento", nuevaFechaNacimiento);
                comando.Parameters.AddWithValue("@nuevoNumeroExpediente", nuevoNumeroExpediente);
                comando.Parameters.AddWithValue("@idAlumno", idAlumno);
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    Console.WriteLine("AVISO: UPDATE OK");
                }
                else
                {
                    Console.WriteLine("AVISO: UPDATE ERROR");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: UPDATE " + ex);
            }
            finally
            {
                conexion.Close(); // Cerrar la conexión
            }
        }

        static void Opcion6(MySqlConnection conexion)
        {
            Console.WriteLine("[6] MOSTRAR LAS ASIGNATURAS POR MODULO");
            Console.WriteLine("--------------------------------------");

            try
            {
                conexion.Open();//ABRIR CONEXION
                string query = "SELECT m.nombre, a.nombre " +
                               "FROM modulo m, asignatura a " +
                               "WHERE m.codigoModulo = a.codigoModulo;";//DECLARAR LA QUERY
                MySqlCommand comando = new MySqlCommand(query, conexion);//PREPARAR LA QUERY
                MySqlDataReader leer = comando.ExecuteReader();//EJECUTAR LA QUERY

                while (leer.Read())//RECUPERAR LOS REGISTROS
                {
                    Console.WriteLine("{0,-15} {1,-10}", leer.GetString(0), leer.GetString(1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: LECTURA " + ex);
            }
            finally
            {
                conexion.Close(); // Cerrar la conexión
            }

        }

    }
}