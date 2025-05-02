using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBibliotecaPrivada.DAO
{
    public class LibroDAOHelper
    {
        public static string listarLibros = " Select idLibro, titulo, autor, precio, stock from BibliotecaPrivada.Libro ";
        public static string crearLibro = " insert into BibliotecaPrivada.Libro (ID, Titulo, Precio, Stock) values (@ID, @Titulo, @Autor, @Precio, @Stock)";
        public static string actualizarLibros = " update BibliotecaPrivada.Libro set ID = @ID, Titulo = @Titulo, Precio = @Precio, Stock = @Stock where ID = @ID ";
    }
}
