using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA21
{
    class Alumno
    {
        public string idAlumno { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public List<string> asignaturas { get; set; }

        public Alumno(string idAlumno, string nombre, int edad, List<string> asignaturas)
        {
            this.idAlumno = idAlumno;
            this.nombre = nombre;
            this.edad = edad;
            this.asignaturas = asignaturas;
        }

        public override string ToString()
        {
            return this.idAlumno + ";" + this.nombre + ";" + this.edad + ";" + string.Join(",", this.asignaturas);

        }
    }
}