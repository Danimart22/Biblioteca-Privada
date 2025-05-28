using APIBibliotecaPrivada.Negocio;
using APIBibliotecaPrivada.Entidades;
using Microsoft.AspNetCore.Mvc;
namespace APIBibliotecaPrivada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PedidosController : ControllerBase
    {
        private readonly IPedidoNegocio _PedidoNegocio;
        private readonly IClienteNegocio _clienteNegocio;
        private readonly ILogger<WeatherForecastController> _logger;
        public PedidosController(IPedidoNegocio pedidoNegocio, IClienteNegocio clienteNegocio, ILogger<WeatherForecastController> logger)
        {
            _PedidoNegocio = pedidoNegocio;
            _clienteNegocio = clienteNegocio;
            _logger = logger;
        }
        [HttpGet]
        [Route("Listar")]
        public Task<List<Pedido>> Get()
        {
            return _PedidoNegocio.listarPedidos();
        }
        [HttpPost]
        [Route("Nuevo")]
        public async Task<IActionResult> Post([FromBody] Pedido pedido)
        {
            // Descontar saldo
            var descuento = await _clienteNegocio.DescontarSaldo(pedido.IdCliente, (decimal)pedido.Total);
            if (!descuento)
            {
                return BadRequest("No se pudo descontar el saldo del cliente");
            }
            pedido.Estado = "Comprado";
            var result = await _PedidoNegocio.guardarPedidos(pedido);
            if (result)
            {
                return Ok();
            }
            return BadRequest("No se pudo guardar el pedido");
        }
        [HttpPut]
        [Route("Actualización")]
        public IActionResult Actualizar(Pedido pedido)
        {
            Task<bool> result = _PedidoNegocio.actualizarPedidos(pedido);
            Console.WriteLine(" Libro Actualizado ");
            return Ok();
        }
        [HttpDelete]
        [Route("Borrar")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _PedidoNegocio.eliminarPedidos(id);
            if (result)
            {
                return Ok();
            }
            return NotFound($"Cliente con ID {id} no encontrado");
        }
    }
}
