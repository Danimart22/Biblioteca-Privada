namespace APIBibliotecaPrivada.DAO
{
    public class ClienteDAOHelper
    {
        public static string listarClientes = "SELECT ID, Nombre, Email, Clave, Saldo FROM BibliotecaPrivada.Cliente";
        public static string obtenerClientePorId = "SELECT ID, Nombre, Email, Clave, Saldo FROM BibliotecaPrivada.Cliente WHERE ID = @ID";
        public static string crearCliente = "INSERT INTO BibliotecaPrivada.Cliente (Nombre, Email, Clave, Saldo) VALUES (@Nombre, @Email, @Clave, @Saldo)";
        public static string actualizarCliente = "UPDATE BibliotecaPrivada.Cliente SET Nombre = @Nombre, Email = @Email, Clave = @Clave, Saldo = @Saldo WHERE ID = @ID";
        public static string eliminarCliente = "DELETE FROM BibliotecaPrivada.Cliente WHERE ID = @ID";
    }
}
