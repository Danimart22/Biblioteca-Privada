using APIBibliotecaPrivada.Entidades;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace APIBibliotecaPrivada.DAO
{
    public interface IPedidoDAO
    {
        Task<List<Pedido>> listarPedidos();
        Task<Boolean> guardarPedidos(Pedido pedido);
        Task<Boolean> actualizarPedidos(Pedido pedido);
        Task<Boolean> eliminarPedidos(int id);
    }
}
