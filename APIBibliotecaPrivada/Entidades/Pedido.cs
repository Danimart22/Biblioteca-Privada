using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Privada.Entidades
{
    internal class Pedido
    {
        private int id;
        private IUsuario usuario;
        private List<Libro> libros;
        private double total;
        private DateTime fecha;

        public Pedido(int id, IUsuario usuario, List<Libro> libros, double total, DateTime fecha)
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
        internal IUsuario Usuario { get => usuario; set => usuario = value; }
    }
}
