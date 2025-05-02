using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIBibliotecaPrivada.Entidades;

namespace APIBibliotecaPrivada.Negocio
{
    public interface ILibroNegocio
    {
        Task<List<Libro>> listarLibros();
        Task<Boolean> guardarLibro(Libro libro);
        Task<Boolean> actualizarLibro(Libro libro);

    }
}
