using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Privada.DAO
{
    public interface ILibroDAO
    {
        Task<List<Libro>> listarLibros();
        Task<Boolean> guardarLibro(Libro libro);
        Task<Boolean> actualizarLibro(Libro libro);  
    }
}
