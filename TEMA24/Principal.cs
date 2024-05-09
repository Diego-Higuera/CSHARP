using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA24
{
    class Principal
    {
        static void Main1(string[] args)
        {
            CuentaBancaria cuenta1 = new CuentaBancaria("111111", "Luis", 500);
            CuentaBancaria cuenta2 = new CuentaBancaria("222222", "Miguel", 0);

            Console.WriteLine("CUENTA LUIS");
            Console.WriteLine("-----------");
            cuenta1.Depositar(100);
            cuenta1.Retirar(400);
            Console.WriteLine(cuenta1);
            cuenta1.Retirar(1000);
            cuenta1.Depositar(2500);
            cuenta1.Retirar(1000);
            Console.WriteLine(cuenta1);
        }

    }

    public class CuentaBancaria
    {
        //ATRIBUTOS
        private string numeroCuenta;
        private string titular;
        private double saldo;

        public CuentaBancaria() { }

        public CuentaBancaria(string nc, string titular, double saldoInicial)
        {
            this.numeroCuenta = nc;
            this.titular = titular;
            this.saldo = saldoInicial;
        }

        public void Depositar(double dineroDeposito)
        {
            if (dineroDeposito > 0)
            {
                this.saldo += dineroDeposito; //this.saldo = this.saldo + dineroDeposito;
                Console.WriteLine("Se ha depositado " + dineroDeposito + " euros");
            }
            else
            {
                Console.WriteLine("Cantidad Dinero debe ser mayor a cero");
            }
        }

        public void Retirar(double dineroRetiro)
        {
            if (dineroRetiro > 0 && dineroRetiro <= this.saldo)
            {
                this.saldo -= dineroRetiro;
                Console.WriteLine("Cantidad retirada " + dineroRetiro + " euros");
            }
            else
            {
                Console.WriteLine("No hay suficiente saldo");
            }
        }

        public override string ToString()
        {
            return this.numeroCuenta + ";" +
                   this.titular + ";" +
                   this.saldo;
        }



    }
}