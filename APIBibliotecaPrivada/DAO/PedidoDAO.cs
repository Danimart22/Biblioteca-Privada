using Microsoft.EntityFrameworkCore;
using APIBibliotecaPrivada.Entidades;
using APIBibliotecaPrivada.Controllers;
using MySql.Data.MySqlClient;
using APIBibliotecaPrivada.Utilidades;
using Dapper;
namespace APIBibliotecaPrivada.DAO
{
    internal class PedidoDAO : IPedidoDAO
    {
        private readonly MySQLConfiguration _connectionString;
        private readonly ILogger<PedidosController> _logger;
        public PedidoDAO(MySQLConfiguration connectionString, ILogger<PedidosController> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<List<Pedido>> listarPedidos()
        {
            List<Pedido> result = new List<Pedido>();
            try
            {
                var db = dbConnection();
                IEnumerable<Pedido> lista = await db.QueryAsync<Pedido>(PedidoDAOHelper.listarPedidos, new { });
                _logger.LogInformation("Consulta de Pedidos exitosa");
                return lista.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al ller cliente de la base de datos " + ex);
                Console.WriteLine("Error: "+ex.Message);
            }
            return result;
        }
        public async Task<Boolean> guardarPedidos(Pedido pedido)
        {
            int result = 0;
            try
            {
                var db = dbConnection();
                result = await db.ExecuteAsync(PedidoDAOHelper.guardarPedidos, new { pedido.Id, pedido.Usuario, pedido.Libros, pedido.Total, pedido.Fecha });
                _logger.LogInformation("Pedido insertado exitosamente");
                return result > 0;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error al insertar pedido en la base de datos: " + ex);
                Console.WriteLine("Error: "+ex.Message );
            }
            return result > 0;
        }
        public async Task<Boolean> actualizarPedidos(Pedido pedido)
        {
            int result = 0;
            try
            {
                var db = dbConnection();
                result = await db.ExecuteAsync(ClienteDAOHelper.actualizarCliente, new {pedido.Id, pedido.Usuario, pedido.Libros, pedido.Total, pedido.Fecha });
                _logger.LogInformation($"Pedido con ID {pedido.Id} actualizado correctamente");
                return result > 0;  
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error al actualizar el pedido con ID: {pedido.Id}: "+ex);
                Console.WriteLine("Error: "+ex.Message);

            }
            return result > 0;
        }
        public async Task<Boolean> eliminarPedidos(int id)
        {
            int result = 0;
            try
            {
                var db = dbConnection();
                result = await db.ExecuteAsync(PedidoDAOHelper.eliminarPedidos, new { ID = id });
                _logger.LogInformation($"Cliente con ID {id} eliminado exitosamente");
                return result > 0;  
            }
            catch( Exception ex )
            {
                _logger.LogError($"Error al eliminar cliente con ID {id}: " + ex);
                Console.WriteLine("Error: "+ex.Message );
            }
            return result > 0;
        }
    }
}
