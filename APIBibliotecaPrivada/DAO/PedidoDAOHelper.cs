namespace APIBibliotecaPrivada.DAO
{
    public class PedidoDAOHelper
    {//HOLa
        public static string listarPedidos = "SELECT ID, IDCliente, Libros, Total, Fecha, Estado FROM BibliotecaPrivada.Pedido";
        public static string guardarPedidos = "Insert into BibliotecaPrivada.Pedido (IDCliente, Libros, Total, Fecha, Estado) values (@IdCliente,@Libros,@Total,@Fecha,@Estado)";
        public static string actualizarPedidos = "UPDATE BibliotecaPrivada.Pedido set IDCliente = @IdCliente, Libros = @Libros, Total = @Total, Fecha = @Fecha, Estado = @Estado where ID = @Id";
        public static string eliminarPedidos = "DELETE FROM BibliotecaPrivada.Pedido WHERE ID = @Id";
    }
}
