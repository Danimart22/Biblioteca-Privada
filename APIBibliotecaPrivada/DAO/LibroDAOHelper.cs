using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBibliotecaPrivada.DAO
{
    public class LibroDAOHelper
    {
        public static string listarLibros = " Select id, titulo, precio, stock, autor from BibliotecaPrivada.Libros";
        public static string crearLibro = " insert into BibliotecaPrivada.Libros (Titulo,Autor,Precio,Stock)  values (@Titulo,@Autor, @Precio, @Stock) ";
        public static string actualizarLibros = " update BibliotecaPrivada.Libros set  Titulo = @Titulo, precio = @Precio, stock = @stock, autor = @autor  where id = @id ";
    }
}
