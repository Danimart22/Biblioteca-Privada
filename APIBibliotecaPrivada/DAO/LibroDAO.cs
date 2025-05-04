using APIBibliotecaPrivada.Controllers;
using MySql.Data.MySqlClient;
using APIBibliotecaPrivada.Utilidades;
using APIBibliotecaPrivada.Entidades;
using Dapper;
using APIBibliotecaPrivada.DAO;

namespace APIBibliotecaPrivada.DAO
{
    internal class LibroDAO : ILibroDAO
    {
        private readonly MySQLConfiguration _connectionString;
        private readonly ILogger<WeatherForecastController> _logger;

        public LibroDAO(MySQLConfiguration connectionString, ILogger<WeatherForecastController> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<List<Libro>> listarLibros()
        {
            List<Libro> result = new List<Libro>();
            try
            {
                var db = dbConnection();
                IEnumerable<Libro> lista = await db.QueryAsync<Libro>(LibroDAOHelper.listarLibros, new { });
                _logger.LogInformation(" Consulta Exitosa");
                return lista.ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError("Error al leer la base de datos: " + ex);
                Console.WriteLine("Errorr " + ex.Message);
            }
            return result;
        }
        public async Task<Boolean> guardarLibro(Libro libro)
        {
            int result = 0;
            try
            {
                var db = dbConnection();
                result = await db.ExecuteAsync(LibroDAOHelper.crearLibro, new {libro.Titulo, libro.Autor, libro.precio, libro.stock });
                return result > 0;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error al intentar insertar en la base de datos " + ex);
                Console.WriteLine("Error error"+ ex.Message);

            }
            return result > 0;  
        }
        public async Task<Boolean> actualizarLibro(Libro libro)
        {
            int result = 0;
            try
            {
                var db = dbConnection();
                result = await db.ExecuteAsync(LibroDAOHelper.actualizarLibros, new {libro.Titulo, libro.Autor, libro.precio, libro.stock });
                return result > 0;
            }catch(Exception ex)
            {
                _logger.LogError("Error al actualizar el registro ya existente en la base de datos: " + ex.Message);
                Console.WriteLine("Error error Errooor "+ex.Message);
            }
            return result > 0;
        }
    }
}
