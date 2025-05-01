using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Privada.Utilidades
{
    internal class Inventario
    {
        private List<Libro> libros;

        public Inventario()
        {
            libros = new List<Libro>();
        }

       
        public void agregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        
        public void eliminarLibro(Libro libro)
        {
            libros.Remove(libro);
        }
        public Libro buscarLibro(string titulo)
        {
            foreach (Libro libro in libros)
            {
                if (libro.getTitulo().Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return libro;
                }
            }
            return null;
        }

        public void actualizarStock(Libro libro, int nuevoStock)
        {
            Libro libroEncontrado = buscarLibro(libro.getTitulo());
            if (libroEncontrado != null)
            {
                libroEncontrado.setStock(nuevoStock);
            }
        }

   
        public void mostrarLibros()
        {
            foreach (Libro libro in libros)
            {
                Console.WriteLine(libro.ObtenerDetalles());
            }
        }
    }
}
