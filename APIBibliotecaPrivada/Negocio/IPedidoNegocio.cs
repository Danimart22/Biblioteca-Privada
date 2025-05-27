using APIBibliotecaPrivada.Entidades;

namespace APIBibliotecaPrivada.Negocio
{
    public interface IPedidoNegocio
    {
        Task<List<Pedido>> listarPedidos();
        Task<Boolean> guardarPedidos(Pedido pedido);
        Task<Boolean> actualizarPedidos(Pedido pedido);
        Task<Boolean> eliminarPedidos(int id);

    }
}
