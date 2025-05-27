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
        private readonly ILogger<WeatherForecastController> _logger;
        public PedidosController(IPedidoNegocio pedidoNegocio, ILogger<WeatherForecastController> logger)
        {
            _PedidoNegocio = pedidoNegocio;
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
        public IActionResult Post(Pedido pedido)
        {
            Task<bool> result = _PedidoNegocio.guardarPedidos(pedido);
            Console.WriteLine("Pedido insertado");
            _logger.LogInformation(" Insertado Exitosamente ");
            return Ok();
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
