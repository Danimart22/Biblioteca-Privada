namespace APIBibliotecaPrivada.DAO
{
    public class PedidoDAOHelper
    {
        public static string listarPedidos = "SELECT ID, IDCliente, Libros, Total, Fecha FROM BibliotecaPrivada.Pedido";
        public static string guardarPedidos = "Insert into BibliotecaPrivada.Pedido (ID, IDCliente, Libros, Total, Fecha) values (@Id,@IdCliente,@Libros,@Total,@Fecha)";
        public static string actualizarPedidos = "UPDATE BibliotecaPrivada.Pedido set IDCliente = @IdCliente, Libros = @Libros, Total = @Total, Fecha = @Fecha where ID = @Id";
        public static string eliminarPedidos = "DELETE FROM BibliotecaPrivada.Pedido WHERE ID = @Id";
    }
}
