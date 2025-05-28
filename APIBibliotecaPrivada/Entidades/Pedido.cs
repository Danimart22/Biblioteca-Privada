using System;

namespace APIBibliotecaPrivada.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Libros { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
