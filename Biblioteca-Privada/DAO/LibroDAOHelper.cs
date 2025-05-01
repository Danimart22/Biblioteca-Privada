using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Privada.DAO
{
    public class LibroDAOHelper
    {
        public static string listarLibros = " Select idLibro, titulo, autor, precio, stock from BibliotecaPrivada.Libro ";

    }
}
