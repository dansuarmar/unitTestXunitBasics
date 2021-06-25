using System;
using System.Collections.Generic;
using System.Linq;
using ClaseExterna;

namespace UnitTestBasics.Tests.Mocks
{
    //ClienteServiceMock.cs
    public class ClienteServiceMock : IClienteService
    {
        List<Cliente> _listaClientes;

        public ClienteServiceMock(List<Cliente> clientes) 
        {
            _listaClientes = clientes;
        }

        public Cliente GetCliente(Guid IdCliente)
        {
            return _listaClientes.FirstOrDefault(x => x.IdCliente == IdCliente);
        }
    }
}
