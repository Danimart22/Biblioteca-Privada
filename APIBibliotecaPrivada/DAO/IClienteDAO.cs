using APIBibliotecaPrivada.Entidades;



namespace APIBibliotecaPrivada.DAO
{
	public interface IClienteDAO
	{
		Task<List<Cliente>> listarClientes();
		Task<Cliente> obtenerClientePorId(int id);
		Task<Boolean> guardarCliente(Cliente cliente);
		Task<Boolean> actualizarCliente(Cliente cliente);
		Task<Boolean> eliminarCliente(int id);	
	}
}