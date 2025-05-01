using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Privada.Entidades
{
    public interface IUsuario
    {
        void verLibros();
        bool verificarContraseña(string Contraseña);

    }
}
