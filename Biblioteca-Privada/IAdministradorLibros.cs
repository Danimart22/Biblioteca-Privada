using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Privada
{
    public interface IAdministradorLibros
    {
        void DisplayBooks();
        void AddBook();
        void EditBook();
        void DeleteBook();
    }
}
