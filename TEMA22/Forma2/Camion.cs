using PROYECTOCSHARP.TEMA22.Forma1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA22.Forma2
{
    public class Camion : Vehiculo
    {
        public double cargaMaxima;

        public Camion() { }

        public Camion(string marca, string modelo, int anio, double cargaMaxima) : base(marca, modelo, anio)
        {
            this.cargaMaxima = cargaMaxima;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine(";" + this.cargaMaxima);
        }

    }
}