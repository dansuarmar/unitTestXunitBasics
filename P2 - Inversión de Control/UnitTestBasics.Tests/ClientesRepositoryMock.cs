using System;
using System.Collections.Generic;
using System.Text;
using ClaseExterna;
using ClaseExterna.LooseCoupling;

namespace UnitTestBasics.Tests
{
    public class ClientesRepositoryMock : IClientesRepository
    {
        public List<Cliente> GetAll()
        {
            var clientes = new List<Cliente>()
            {
                new Cliente()
                {
                    IdCliente = Guid.NewGuid(),
                    Nombre = "Pedro",
                    Apellido = "Paramo",
                },
                new Cliente()
                {
                    IdCliente = Guid.NewGuid(),
                    Nombre = "Juan",
                    Apellido = "Rulfo",
                },
            };

            return clientes;
        }
    }
}
