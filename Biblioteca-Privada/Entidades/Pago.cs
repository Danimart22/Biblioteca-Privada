using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Privada.Entidades
{
    internal class Pago
    {
        private int ID;
        private string pedido;
        private double monto;
        private string metodoPago;
        private DateTime fecha;
        private string numeroTarjeta; 

        
        public Pago(int ID, string pedido, double monto, string metodoPago, string numeroTarjeta = "")
        {
            this.ID = ID;
            this.pedido = pedido;
            this.monto = monto;
            this.metodoPago = metodoPago;
            fecha = DateTime.Now;
            this.numeroTarjeta = numeroTarjeta;
        }
        public double getMonto() => monto;
        public string getMetodoPago() => metodoPago;
        public DateTime getFecha() => fecha;


        //Aqui ira el metodo del algoritmo de luhn cuando entienda como funciona :)
    }
}
