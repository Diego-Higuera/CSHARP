using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA20.ejemplo1
{
    class Circulo1
    {
        //1. ATRIBUTOS (CAMPOS)
        private double radio; //ENTRADA

        private double area;        //SALIDA
        private double perimetro;   //SALIDA

        //2. CONSTRUCTOR
        public Circulo1()
        {
            this.radio = 0.0;
        }

        public Circulo1(double radio)
        {
            this.radio = radio;
        }

        //3. SET Y GET
        public double GetRadio()
        {
            return this.radio;
        }

        public void SetRadio(double radio)
        {
            this.radio = radio;
        }

        //4. MOSTRAR TODOS LOS ATRIBUTOS
        public override string ToString()
        {
            return "Circulo{" + "radio=" + this.radio + "," +
                                "area=" + this.GetArea() + "," +
                                "perimetro=" + this.GetPerimetro() + "}";
        }

        public string MiToStringCsv()
        {
            return this.radio + ";" + this.GetArea() + ";" + this.GetPerimetro();
        }

        public void MiToStringTabla()
        {
            Console.WriteLine("{0,10} {1,10} {2,10}", "RADIO", "AREA", "PERIMETRO");
            Console.WriteLine("{0,10} {1,10} {2,10}", "-----", "----", "---------");
            Console.WriteLine("{0,10:0.00} {1,10:0.00} {2,10:0.00}", this.radio, this.GetArea(), this.GetPerimetro());
        }

        public static void Cabecera(int x)
        {
            if (x == 0)
            {
                Console.WriteLine("{0,10} {1,10} {2,10}", "RADIO", "AREA", "PERIMETRO");
                Console.WriteLine("{0,10} {1,10} {2,10}", "-----", "----", "---------");
            }
            if (x == 1)
            {
                Console.WriteLine("{0,10} {1,10} {2,10} {3,10}", "NUMERO", "RADIO", "AREA", "PERIMETRO");
                Console.WriteLine("{0,10} {1,10} {2,10} {3,10}", "------", "-----", "----", "---------");
            }

        }

        public void Cuerpo(int x, int i)
        {
            if (x == 0)
            {
                Console.WriteLine("{0,10:0.00} {1,10:0.00} {2,10:0.00}", this.radio, this.GetArea(), this.GetPerimetro());
            }
            if (x == 1)
            {
                Console.WriteLine("{0,10} {1,10:0.00} {2,10:0.00} {3,10:0.00}", i, this.radio, this.GetArea(), this.GetPerimetro());
            }

        }

        //5. CALCULO
        public double GetArea()
        {
            this.area = Math.PI * Math.Pow(this.radio, 2);
            return this.area;
        }

        public double GetPerimetro()
        {
            this.perimetro = 2 * Math.PI * this.radio;
            return this.perimetro;

        }

    }

    class Circulo2
    {
        //1. ATRIBUTOS (CAMPOS)
        public double radio { get; set; }    //ENTRADA

        private double area;        //SALIDA
        private double perimetro;   //SALIDA

        //2. CONSTRUCTOR
        public Circulo2()
        {
            this.radio = 0.0;
        }

        public Circulo2(double radio)
        {
            this.radio = radio;
        }

        //3. SET Y GET
        //OMITE

        //4. MOSTRAR TODOS LOS ATRIBUTOS
        public override string ToString()
        {
            return "Circulo{" + "radio=" + this.radio + "," +
                                "area=" + this.GetArea() + "," +
                                "perimetro=" + this.GetPerimetro() + "}";
        }

        public string MiToStringCsv()
        {
            return this.radio + ";" + this.GetArea() + ";" + this.GetPerimetro();
        }

        public void MiToStringTabla()
        {
            Console.WriteLine("{0,10} {1,10} {2,10}", "RADIO", "AREA", "PERIMETRO");
            Console.WriteLine("{0,10} {1,10} {2,10}", "-----", "----", "---------");
            Console.WriteLine("{0,10:0.00} {1,10:0.00} {2,10:0.00}", this.radio, this.GetArea(), this.GetPerimetro());
        }

        public static void Cabecera()
        {
            Console.WriteLine("{0,10} {1,10} {2,10}", "RADIO", "AREA", "PERIMETRO");
            Console.WriteLine("{0,10} {1,10} {2,10}", "-----", "----", "---------");
        }

        public void Cuerpo()
        {
            Console.WriteLine("{0,10:0.00} {1,10:0.00} {2,10:0.00}", this.radio, this.GetArea(), this.GetPerimetro());
        }

        //5. CALCULO
        public double GetArea()
        {
            this.area = Math.PI * Math.Pow(this.radio, 2);
            return this.area;
        }

        public double GetPerimetro()
        {
            this.perimetro = 2 * Math.PI * this.radio;
            return this.perimetro;

        }

    }

    class Circulo3
    {
        //1. ATRIBUTOS (CAMPOS)
        public int idCirculo { get; set; } //ENTRADA
        public double radio { get; set; }  //ENTRADA

        private double area;        //SALIDA
        private double perimetro;   //SALIDA

        //2. CONSTRUCTOR
        public Circulo3(int idCirculo, double radio)
        {
            this.idCirculo = idCirculo;
            this.radio = radio;
        }

        //4. MOSTRAR TODOS LOS ATRIBUTOS
        public override string ToString()
        {
            return "Circulo{" + "idCirculo" + this.idCirculo + "," +
                                "radio=" + this.radio + "," +
                                "area=" + this.GetArea() + "," +
                                "perimetro=" + this.GetPerimetro() + "}";
        }

        public static void Cabecera()
        {
            Console.WriteLine("{0,10} {1,10} {2,10} {3,10}", "NUMERO", "RADIO", "AREA", "PERIMETRO");
            Console.WriteLine("{0,10} {1,10} {2,10} {3,10}", "------", "-----", "----", "---------");
        }

        public void Cuerpo()
        {
            Console.WriteLine("{0,10} {1,10:0.00} {2,10:0.00} {3,10:0.00}", this.idCirculo, this.radio, this.GetArea(), this.GetPerimetro());
        }

        //5. CALCULO
        public double GetArea()
        {
            this.area = Math.PI * Math.Pow(this.radio, 2);
            return this.area;
        }

        public double GetPerimetro()
        {
            this.perimetro = 2 * Math.PI * this.radio;
            return this.perimetro;

        }

        public Dictionary<string, object> GetDiccionario()
        {
            Dictionary<string, object> diccionario_circulo = new Dictionary<string, object>();

            diccionario_circulo["idCirculo"] = this.idCirculo;
            diccionario_circulo["radio"] = this.radio;
            diccionario_circulo["area"] = this.GetArea();
            diccionario_circulo["perimetro"] = this.GetPerimetro();

            return diccionario_circulo;
        }

        public string GetCsv()
        {
            return this.idCirculo + ";" + this.radio + ";" + this.GetArea() + ";" + this.GetPerimetro();
        }

    }
}