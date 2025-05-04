using System.ComponentModel.DataAnnotations;

namespace APIBibliotecaPrivada.Entidades
{
    public class Cliente : IUsuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public double Saldo { get; set; }

        // Constructor sin parámetros para deserialización
        public Cliente()
        {
        }

        public Cliente(int id, string nombre, string email, string clave, double saldo)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Clave = clave;
            Saldo = saldo;
        }

        public void verLibros()
        {
            // Implementación
        }

        public bool verificarContraseña(string C)
        {
            return C.Equals(Clave);
        }
    }
}
