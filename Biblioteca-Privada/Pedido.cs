using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Privada
{
    internal class Pedido
    {
        private int id;
        private Usuario usuario;
        private List<Libro> libros;
        private double total;
        private DateTime fecha;

        public Pedido(int id, Usuario usuario, List<Libro> libros, double total, DateTime fecha)
        {
            this.id = id;
            this.usuario = usuario;
            this.libros = libros;
            this.total = total;
            this.fecha = fecha;
        }

        public int Id { get => id; set => id = value; }
        public List<Libro> Libros { get => libros; set => libros = value; }
        public double Total { get => total; set => total = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        internal Usuario Usuario { get => usuario; set => usuario = value; }
    }
}
