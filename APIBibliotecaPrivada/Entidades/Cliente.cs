using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBibliotecaPrivada.Entidades
{
    internal class Cliente : IUsuario
    {
        public Cliente(int id, string nombre, string email, string clave, double saldo)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Clave = clave;
            Saldo = saldo;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public double Saldo { get; set; }

        public void verLibros()
        {

        }
        public bool verificarContraseña(string C)
        {
            if (C.Equals(Clave))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
