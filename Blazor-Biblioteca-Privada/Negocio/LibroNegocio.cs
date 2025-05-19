using System.Net.Http.Json;
using System.Text.Json;
using BlazorApp.Entidades;
namespace BlazorApp.Negocio
{
    public class LibroNegocio
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl = "api/Libros";
        private readonly ILogger<Libro> _logger;

        public LibroNegocio(HttpClient httpClient, ILogger<Libro> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<List<Libro>> listarLibros()
        {
            Console.WriteLine("LibroNegocio.listarLibros() llamado");
            try
            {
                var response = await _httpClient.GetAsync($"{_baseApiUrl}/Listar");
                Console.WriteLine($"Respuesta de listar materias: Status Code - {response.StatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var Libros = JsonSerializer.Deserialize<List<Libro>>(content, options);
                    Console.WriteLine($"Materias listadas extosamente: {Libros?.Count ?? 0} encontradas");
                    return Libros;
                }
                else
                {
                    Console.WriteLine($"Error al lstar materias: Status Code - {response.StatusCode}");
                    return null;
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"Error al listar materias: {ex.Message}");
                return null;
            }
        }
        public async Task<bool> guardarLibro(Libro libro)
        {
            libro.id = 123;
            libro.stock = 1;
            try
            {
                _logger.LogInformation($"Iniciando la llamada para guardar el libro: {JsonSerializer.Serialize(libro)}");
                var response = await _httpClient.PostAsJsonAsync($"{_baseApiUrl}/nuevo", libro);
                _logger.LogInformation($"Respuesta de guardar libro: Status Code - {response.StatusCode}");
                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error al guardar materia: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> actualizarLibro(Libro libro)
        {
            try
            {
                _logger.LogInformation($"Iniciando la llamada para actualizar la materia: {JsonSerializer.Serialize(libro)}");
                var response = await _httpClient.PatchAsJsonAsync($"{_baseApiUrl}/Actualización", libro);
                _logger.LogInformation($"Respuesta de actualizar libro: status Code - {response.StatusCode}");
                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error al actualizar libro: {ex.Message}");
                return false;
            }
        }
    }
}
