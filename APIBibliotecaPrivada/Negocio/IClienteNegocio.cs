using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIBibliotecaPrivada.Entidades;

namespace APIBibliotecaPrivada.Negocio
{
    public interface IClienteNegocio
    {
        Task<List<Cliente>> listarClientes();
        Task<Cliente> obtenerClientePorId(int id);
        Task<Cliente> obtenerClientePorEmail(string email);
        Task<Boolean> guardarCliente(Cliente cliente);
        Task<Boolean> actualizarCliente(Cliente cliente);
        Task<Boolean> eliminarCliente(int id);
    }
}