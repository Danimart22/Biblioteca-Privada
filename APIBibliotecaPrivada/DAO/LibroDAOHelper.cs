using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBibliotecaPrivada.DAO
{
    public class LibroDAOHelper
    {
        public static string listarLibros = " Select id, titulo, autor, precio, stock from BibliotecaPrivada.dbo.Libro ";
        public static string crearLibro = " insert into BibliotecaPrivada.dbo.Libro (Titulo, Precio, Stock) values (@Titulo, @Autor, @Precio, @Stock)";
        public static string actualizarLibros = " update BibliotecaPrivada.dbo.Libro set Titulo = @Titulo, Precio = @Precio, Stock = @Stock, Autor = @Autor where ID = @ID ";
    }
}
