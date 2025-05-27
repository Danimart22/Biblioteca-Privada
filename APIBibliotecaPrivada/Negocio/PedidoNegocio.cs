using APIBibliotecaPrivada.DAO;
using APIBibliotecaPrivada.Entidades;
namespace APIBibliotecaPrivada.Negocio
  
{
    public class PedidoNegocio : IPedidoNegocio
    {
        private readonly IPedidoDAO _pedidoDAO;
        public PedidoNegocio(IPedidoDAO pedidoDAO)
        {
            _pedidoDAO = pedidoDAO;
        }
        public async Task<List<Pedido>> listarPedidos()
        {
            return await _pedidoDAO.listarPedidos();
        }
        public async Task<Boolean> guardarPedidos(Pedido pedido)
        {
            return await _pedidoDAO.guardarPedidos(pedido);
        }
        public async Task<Boolean> actualizarPedidos(Pedido pedido)
        {
            return await _pedidoDAO.actualizarPedidos(pedido);
        }
        public async Task<Boolean> eliminarPedidos(int id)
        {
            return await _pedidoDAO.eliminarPedidos(id);
        }
    }
}
