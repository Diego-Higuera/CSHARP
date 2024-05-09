using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA22.Forma2
{
    public class Vehiculo
    {
        public string marca;
        public string modelo;
        public int anio;

        public Vehiculo() { }

        public Vehiculo(string marca, string modelo, int anio)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.anio = anio;
        }

        public virtual void MostrarInformacion()
        {
            Console.Write(this.marca + ";" + this.modelo + ";" + this.anio);
        }

    }
}