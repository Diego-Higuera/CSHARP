using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Crud.Order.Types;

namespace PROYECTOCSHARP.TEMA20.ejemplo2
{
    class Empleado
    {
        public string idEmpleado { get; set; }
        public string nombre { get; set; }
        public double estatura { get; set; }
        public bool casado { get; set; }
        public char sexo { get; set; }
        public Direccion direccion { get; set; }
        public List<string> hobbies { get; set; }
        public Empleado() { }

        public Empleado(string idEmpleado, string nombre, double estatura, bool casado, char sexo, Direccion direccion, List<string> hobbies)
        {
            this.idEmpleado = idEmpleado;
            this.nombre = nombre;
            this.estatura = estatura;
            this.casado = casado;
            this.sexo = sexo;
            this.direccion = direccion;
            this.hobbies = hobbies;
        }





        public static void Cabecera()
        {
            Console.WriteLine("{0,-10} {1,-10} {2,10} {3,-10} {4,-10} {5,-15} {6,10} {7,-10} {8,-30}", "IDEMPLEADO", "NOMBRE", "ESTATURA", "CASADO", "SEXO", "CALLE", "NUMERO", "CIUDAD", "HOBBIES");
            Console.WriteLine("{0,-10} {1,-10} {2,10} {3,-10} {4,-10} {5,-15} {6,10} {7,-10} {8,-30}", "----------", "------", "--------", "------", "----", "-----", "------", "------", "-------");
        }

        public void Cuerpo()
        {
            Console.WriteLine("{0,-10} {1,-10} {2,10} {3,-10} {4,-10} {5,-15} {6,10} {7,-10} {8,-30}", this.idEmpleado, this.nombre, this.estatura, this.casado, this.sexo, this.direccion.calle, this.direccion.numero, this.direccion.ciudad, string.Join(", ", this.hobbies));
        }

    }
}

