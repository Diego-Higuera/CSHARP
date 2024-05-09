using PROYECTOCSHARP.TEMA22.Forma1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA22.Forma2
{
    class Principal
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("EJEMPLO 1");
            Console.WriteLine("---------");
            Automovil automovil1 = new Automovil("Toyota", "Corolla", 2022, 4);
            Camion camion1 = new Camion("Ford", "F-150", 2021, 2.5);
            Motocicleta motocicleta1 = new Motocicleta("Honda", "CBR500R", 2023, "Deportiva");

            automovil1.MostrarInformacion();
            camion1.MostrarInformacion();
            motocicleta1.MostrarInformacion();

            Console.WriteLine("EJEMPLO 2");
            Console.WriteLine("---------");
            Automovil automovil2 = new Automovil
            {
                marca = "Toyota",
                modelo = "Corolla",
                anio = 2022,
                cantidadPuertas = 4
            };
            Camion camion2 = new Camion
            {
                marca = "Ford",
                modelo = "F-150",
                anio = 2021,
                cargaMaxima = 2.5
            };
            Motocicleta motocicleta2 = new Motocicleta
            {
                marca = "Honda",
                modelo = "CBR500R",
                anio = 2023,
                tipo = "Deportiva"
            };
            automovil1.MostrarInformacion();
            camion1.MostrarInformacion();
            motocicleta1.MostrarInformacion();
            Console.WriteLine("EJEMPLO 3");
            Console.WriteLine("---------");
            Automovil automovil3 = new Automovil();
            automovil3.marca = "Toyota";
            automovil3.modelo = "Corolla";
            automovil3.anio = 2022;
            automovil3.cantidadPuertas = 4;
            Camion camion3 = new Camion();
            camion3.marca = "Ford";
            camion3.modelo = "F-150";
            camion3.anio = 2021;
            camion3.cargaMaxima = 2.5;
            Motocicleta motocicleta3 = new Motocicleta();
            motocicleta3.marca = "Honda";
            motocicleta3.modelo = "CBR500R";
            motocicleta3.anio = 2023;
            motocicleta3.tipo = "Deportiva";

            automovil3.MostrarInformacion();
            camion3.MostrarInformacion();
            motocicleta3.MostrarInformacion();

            Console.WriteLine("EJEMPLO 4");
            Console.WriteLine("---------");

            List<Vehiculo> list_vehiculos = new List<Vehiculo>();

            list_vehiculos.Add(automovil1);
            list_vehiculos.Add(camion1);
            list_vehiculos.Add(motocicleta1);
            list_vehiculos.Add(motocicleta2);
            list_vehiculos.Add(motocicleta3);

            foreach (Vehiculo objeto in list_vehiculos)
            {
                objeto.MostrarInformacion();
            }

        }

    }
}