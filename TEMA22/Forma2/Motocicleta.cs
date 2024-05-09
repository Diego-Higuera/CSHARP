using PROYECTOCSHARP.TEMA22.Forma1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA22.Forma2
{
    public class Motocicleta : Vehiculo
    {
        public string tipo;

        public Motocicleta() { }

        public Motocicleta(string marca, string modelo, int anio, string tipo) : base(marca, modelo, anio)
        {
            this.tipo = tipo;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine(";" + this.tipo);
        }
    }
}