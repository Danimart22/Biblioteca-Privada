using System.Net.Http.Json;
using System.Text.Json;
using BlazorApp.Entidades;

namespace BlazorApp.Negocio
{
    public class ClienteNegocio
    {
    
        
            private readonly HttpClient _httpClient;
            private readonly string _baseApiUrl = "api/Clientes";
            private readonly ILogger<Cliente> _logger;

            public ClienteNegocio(HttpClient httpClient, ILogger<Cliente> logger)
            {
                _httpClient = httpClient;
                _logger = logger;
            }
            public async Task<List<Cliente>> listarClientes()
            {
                Console.WriteLine("ClienteNegocio.listarClientes llamado");
                try
                {
                    var response = await _httpClient.GetAsync($"{_baseApiUrl}/Listar");
                    Console.WriteLine($"Respuesta de listar clientes: Status Code - {response.StatusCode}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var clientes = JsonSerializer.Deserialize<List<Cliente>>(content, options);
                        Console.WriteLine($"Clientes listados exitosamente: {clientes?.Count ?? 0} encontradas");
                        return clientes;
                    }
                    else
                    {
                        Console.WriteLine($"Error al listar clientes: Status Code - {response.StatusCode}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al listar clientes: {ex.Message}");
                    return null;
                }
            }
            public async Task<bool> guardarLibro(Cliente cliente)
            {
                cliente.Id = 123;
                try
                {
                    _logger.LogInformation($"Iniciando la llamada para guardar el cliente: {JsonSerializer.Serialize(cliente)}");
                    var response = await _httpClient.PostAsJsonAsync($"{_baseApiUrl}/nuevo", cliente);
                    _logger.LogInformation($"Respuesta de guardar cliente: Status Code - {response.StatusCode}");
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error al guardar cliente: {ex.Message}");
                    return false;
                }
            }
            public async Task<bool> actualizarCliente(Cliente cliente)
            {
                try
                {
                    _logger.LogInformation($"Iniciando la llamada para guardar el cliente:  {JsonSerializer.Serialize(cliente)}");
                    var response = await _httpClient.PatchAsJsonAsync($"{_baseApiUrl}/Actualización", cliente);
                    _logger.LogInformation($"Respuesta de actualizar el cliente: status Code - {response.StatusCode}");
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error al actualizar cliente: {ex.Message}");
                    return false;
                }
            }
        }
    }



