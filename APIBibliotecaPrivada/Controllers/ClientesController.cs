using APIBibliotecaPrivada.Entidades;
using APIBibliotecaPrivada.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIBibliotecaPrivada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteNegocio _clienteNegocio;
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(IClienteNegocio clienteNegocio, ILogger<ClientesController> logger)
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

        [HttpGet("{id}")]
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
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            _logger.LogInformation($"Intentando registrar cliente: {cliente.Email}");
            try
            {
                var result = await _clienteNegocio.guardarCliente(cliente);
                if (result)
                {
                    _logger.LogInformation("Cliente registrado exitosamente");
                    return Ok(new { message = "Cliente registrado exitosamente" });
                }
                _logger.LogWarning("Error al registrar el cliente");
                return BadRequest(new { message = "Error al registrar el cliente" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al registrar cliente: {ex.Message}");
                return StatusCode(500, new { message = "Error interno del servidor" });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            _logger.LogInformation($"Intentando login para: {loginRequest.Email}");
            try
            {
                var cliente = await _clienteNegocio.obtenerClientePorEmail(loginRequest.Email);
                if (cliente == null)
                {
                    _logger.LogWarning($"Cliente no encontrado: {loginRequest.Email}");
                    return Unauthorized(new { message = "Credenciales inválidas" });
                }

                if (cliente.Clave != loginRequest.Clave)
                {
                    _logger.LogWarning($"Contraseña incorrecta para: {loginRequest.Email}");
                    return Unauthorized(new { message = "Credenciales inválidas" });
                }

                var response = new LoginResponse
                {
                    Id = cliente.Id,
                    Token = "dummy-token"
                };

                _logger.LogInformation($"Login exitoso para: {loginRequest.Email}");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en login: {ex.Message}");
                return StatusCode(500, new { message = "Error interno del servidor" });
            }
        }

        [HttpPut]
        [Route("Actualización")]
        public IActionResult Actualizar(Cliente cliente)
        {
            Task<bool> result = _clienteNegocio.actualizarCliente(cliente);
            Console.WriteLine(" Libro Actualizado ");
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clienteNegocio.eliminarCliente(id);
            if (result)
            {
                return Ok();
            }
            return NotFound($"Cliente con ID {id} no encontrado");
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public int Id { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}