using APIBibliotecaPrivada.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIBibliotecaPrivada.Entidades;
namespace APIBibliotecaPrivada.Negocio
{
    public class LibroNegocio : ILibroNegocio
    {
        private readonly ILibroDAO _libroDAO;
        public LibroNegocio(ILibroDAO libroDAO)
        {
            _libroDAO = libroDAO;
        }
        public async Task<List<Libro>> listarLibros()
        {
            List<Libro> result = await _libroDAO.listarLibros();
            return result;
        }
        public async Task<Boolean> guardarLibro(Libro libro)
        {
            return await _libroDAO.guardarLibro(libro);
        }
        public async Task<Boolean> actualizarLibro(Libro libro)
        {
            return await _libroDAO.actualizarLibro(libro);
        }
    }
}
