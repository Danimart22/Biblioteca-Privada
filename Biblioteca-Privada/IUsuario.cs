using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Privada
{
     public interface IUsuario
    {
        void verLibros();
        Boolean verificarContraseña(string Contraseña);

    }
}