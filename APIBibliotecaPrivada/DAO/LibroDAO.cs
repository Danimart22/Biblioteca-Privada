using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_Privada.Controllers;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Biblioteca_Privada.Utilidades;
using Biblioteca_Privada.Entidades;


namespace Biblioteca_Privada.DAO
{
    internal class LibroDAO : ILibroDAO
    {
        private readonly MySqlConfiguration _connectionString;
        private readonly ILogger<WeatherForecastController> _logger;

        public LibroDAO(MySqlConfiguration connectionString, ILogger<WeatherForecastController> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
