using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Privada
{
    internal class Usuario
    {
        private int ID;
        private string Nombre;
        private string Email;
        private string Contraseña;

        public Usuario(int iD, string nombre, string email, string contraseña)
        {
            ID1 = iD;
            Nombre1 = nombre;
            Email1 = email;
            Contraseña1 = contraseña;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Contraseña1 { get => Contraseña; set => Contraseña = value; }

        private void VerificarContraseña(string ContraseñaIngresada)
        {
            if (ContraseñaIngresada.Equals(Contraseña1))
            {
                Console.WriteLine("La contraseña ingresada es correcta.");
            }
            else
            {
                Console.WriteLine("La contraseña ingresada NO es la correcta.");
            }
        }

    }
}