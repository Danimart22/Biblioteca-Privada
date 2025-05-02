using APIBibliotecaPrivada.Negocio;
using APIBibliotecaPrivada.Entidades;
using Microsoft.AspNetCore.Mvc;
namespace APIBibliotecaPrivada.Controllers
{
    [ApiController]
    [Route("Libros")]

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
        public IActionResult Post(Libro libro)
        {
            Task<bool> result = _libroNegocio.guardarLibro(libro);
            Console.WriteLine("Libro insertado");
            _logger.LogInformation(" Insertado Exitosamente ");
            return Ok();
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

