namespace BlazorApp.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Libros { get; set; } = string.Empty;
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
    }
} 