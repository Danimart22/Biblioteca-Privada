using Microsoft.EntityFrameworkCore;
using APIBibliotecaPrivada.Entidades;
using APIBibliotecaPrivada.Controllers;
using MySql.Data.MySqlClient;
using APIBibliotecaPrivada.Utilidades;
using Dapper;
namespace APIBibliotecaPrivada.DAO
{
    
		internal class ClienteDAO : IClienteDAO
		{
			private readonly MySQLConfiguration _connectionString;
			private readonly ILogger<WeatherForecastController> _logger;

			public ClienteDAO(MySQLConfiguration connectionString, ILogger<WeatherForecastController> logger)
			{
				_connectionString = connectionString;
				_logger = logger;
			}

			protected MySqlConnection dbConnection()
			{
				return new MySqlConnection(_connectionString.ConnectionString);
			}

			public async Task<List<Cliente>> listarClientes()
			{
				List<Cliente> result = new List<Cliente>();
				try
				{
					var db = dbConnection();
					IEnumerable<Cliente> lista = await db.QueryAsync<Cliente>(ClienteDAOHelper.listarClientes, new { });
					_logger.LogInformation("Consulta de clientes exitosa");
					return lista.ToList();
				}
				catch (Exception ex)
				{
					_logger.LogError("Error al leer clientes de la base de datos: " + ex);
					Console.WriteLine("Error: " + ex.Message);
				}
				return result;
			}

			public async Task<Cliente> obtenerClientePorId(int id)
			{
				Cliente cliente = null;
				try
				{
					var db = dbConnection();
					cliente = await db.QueryFirstOrDefaultAsync<Cliente>(ClienteDAOHelper.obtenerClientePorId, new { ID = id });
					_logger.LogInformation($"Consulta de cliente con ID {id} exitosa");
				}
				catch (Exception ex)
				{
					_logger.LogError($"Error al obtener cliente con ID {id}: " + ex);
					Console.WriteLine("Error: " + ex.Message);
				}
				return cliente;
			}

			public async Task<Boolean> guardarCliente(Cliente cliente)
			{
				int result = 0;
				try
				{
					var db = dbConnection();
					result = await db.ExecuteAsync(ClienteDAOHelper.crearCliente, new { cliente.Nombre, cliente.Email, cliente.Clave, cliente.Saldo });
					_logger.LogInformation("Cliente insertado exitosamente");
					return result > 0;
				}
				catch (Exception ex)
				{
					_logger.LogError("Error al insertar cliente en la base de datos: " + ex);
					Console.WriteLine("Error: " + ex.Message);
				}
				return result > 0;
			}

			public async Task<Boolean> actualizarCliente(Cliente cliente)
			{
				int result = 0;
				try
				{
					var db = dbConnection();
					result = await db.ExecuteAsync(ClienteDAOHelper.actualizarCliente, new {cliente.Nombre, cliente.Email, cliente.Clave, cliente.Saldo });
					_logger.LogInformation($"Cliente con ID {cliente.Id} actualizado exitosamente");
					return result > 0;
				}
				catch (Exception ex)
				{
					_logger.LogError($"Error al actualizar cliente con ID {cliente.Id}: " + ex);
					Console.WriteLine("Error: " + ex.Message);
				}
				return result > 0;
			}

			public async Task<Boolean> eliminarCliente(int id)
			{
				int result = 0;
				try
				{
					var db = dbConnection();
					result = await db.ExecuteAsync(ClienteDAOHelper.eliminarCliente, new { ID = id });
					_logger.LogInformation($"Cliente con ID {id} eliminado exitosamente");
					return result > 0;
				}
				catch (Exception ex)
				{
					_logger.LogError($"Error al eliminar cliente con ID {id}: " + ex);
					Console.WriteLine("Error: " + ex.Message);
				}
				return result > 0;
			}
		}
}
