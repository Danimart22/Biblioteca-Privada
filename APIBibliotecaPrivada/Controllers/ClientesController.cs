using APIBibliotecaPrivada.Entidades;
using APIBibliotecaPrivada.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIBibliotecaPrivada.Controllers
{
    [ApiController]
    [Route("Clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteNegocio _clienteNegocio;
        private readonly ILogger<WeatherForecastController> _logger;

        public ClientesController(IClienteNegocio clienteNegocio, ILogger<WeatherForecastController> logger)
        {
            _clienteNegocio = clienteNegocio;
            _logger = logger;
        }

        [HttpGet]
        [Route("Listar")]
        public Task<List<Cliente>> Get()
        {
            return _clienteNegocio.listarClientes();
        }

        [HttpGet]
        [Route("Obtener/{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _clienteNegocio.obtenerClientePorId(id);
            if (cliente == null)
            {
                return NotFound($"Cliente con ID {id} no encontrado");
            }
            return cliente;
        }

        [HttpPost]
        [Route("Nuevo")]
        public IActionResult Post(Cliente cliente)
		{
			Task<bool> result = _clienteNegocio.guardarCliente(cliente);
			Console.WriteLine("Cliente insertado");
			_logger.LogInformation(" Insertado Exitosamente ");
			return Ok();
		}

		[HttpPut]
        [Route("Actualizacion")]
        public IActionResult Actualizar(Cliente cliente)
		{
			Task<bool> result = _clienteNegocio.actualizarCliente(cliente);
			Console.WriteLine(" Cliente Actualizado ");
			return Ok();
		}

		[HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool result = await _clienteNegocio.eliminarCliente(id);
            if (result)
            {
                _logger.LogInformation($"Cliente con ID {id} eliminado exitosamente");
                return Ok($"Cliente con ID {id} eliminado exitosamente");
            }
            return NotFound($"Cliente con ID {id} no encontrado o error al eliminar");
        }
    }
}