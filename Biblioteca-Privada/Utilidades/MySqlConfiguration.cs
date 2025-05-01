namespace Biblioteca_Privada.Utilidades
{
    public class MySQLConfiguration
    {
        public string ConnectionString { get; set; }

        public MySQLConfiguration(String connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
