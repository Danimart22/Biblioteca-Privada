using APIBibliotecaPrivada.Negocio;
using APIBibliotecaPrivada.Entidades;
using Microsoft.AspNetCore.Mvc;
namespace APIBibliotecaPrivada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LibrosController : ControllerBase
    {
        private readonly ILibroNegocio _libroNegocio;
        private readonly ILogger<WeatherForecastController> _logger;
        public LibrosController(ILibroNegocio libroNegocio,  ILogger<WeatherForecastController> logger)
        {
            _libroNegocio = libroNegocio;
            _logger = logger;
        }
        [HttpGet]
        [Route("Listar")]
        public Task<List<Libro>> Get()
        {
            return _libroNegocio.listarLibros();
        }
        [HttpPost]
        [Route("Nuevo")]
        public async Task<IActionResult> Post([FromBody] Libro libro)
        {
            try
            {
                bool result = await _libroNegocio.guardarLibro(libro);
                if (result)
                {
                    _logger.LogInformation("Libro insertado exitosamente");
                    return Ok();
                }
                else
                {
                    _logger.LogWarning("No se pudo insertar el libro");
                    return BadRequest("No se pudo insertar el libro");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al insertar el libro: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
        [HttpPut]
        [Route("Actualización")]
        public IActionResult Actualizar(Libro libro)
        {
            Task<bool> result = _libroNegocio.actualizarLibro(libro);
            Console.WriteLine(" Libro Actualizado ");
            return Ok();
        }
    }
}

