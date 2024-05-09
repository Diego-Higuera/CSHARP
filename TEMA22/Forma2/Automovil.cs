using PROYECTOCSHARP.TEMA22.Forma1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA22.Forma2
{
    public class Automovil : Vehiculo
    {
        public int cantidadPuertas;

        public Automovil() { }

        public Automovil(string marca, string modelo, int anio, int cantidadPuertas) : base(marca, modelo, anio)
        {
            this.cantidadPuertas = cantidadPuertas;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine(";" + this.cantidadPuertas);
        }
    }
}