using APIBibliotecaPrivada.DAO;
using APIBibliotecaPrivada.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIBibliotecaPrivada.Negocio
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly IClienteDAO _clienteDAO;

        public ClienteNegocio(IClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }

        public async Task<List<Cliente>> listarClientes()
        {
            return await _clienteDAO.listarClientes();
        }

        public async Task<Cliente> obtenerClientePorId(int id)
        {
            return await _clienteDAO.obtenerClientePorId(id);
        }

        public async Task<Cliente> obtenerClientePorEmail(string email)
        {
            return await _clienteDAO.obtenerClientePorEmail(email);
        }

        public async Task<Boolean> guardarCliente(Cliente cliente)
        {
            return await _clienteDAO.guardarCliente(cliente);
        }

        public async Task<Boolean> actualizarCliente(Cliente cliente)
        {
            return await _clienteDAO.actualizarCliente(cliente);
        }

        public async Task<Boolean> eliminarCliente(int id)
        {
            return await _clienteDAO.eliminarCliente(id);
        }
    }
}