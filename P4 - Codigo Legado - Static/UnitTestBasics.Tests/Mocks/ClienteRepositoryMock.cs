using System;
using System.Collections.Generic;
using System.Text;
using ClaseExterna.LooseCoupling;

namespace UnitTestBasics.Tests.Mocks
{
    //ClienteRepositoryMock.cs
    public class ClienteRepositoryMock : IClientRepository
    {
        bool excepcion;

        public ClienteRepositoryMock(bool mandarExcepcion) 
        {
            excepcion = mandarExcepcion;
        }

        public Cliente Add(Cliente cliente)
        {
            if (excepcion)
                throw new Exception("Error al guardar.");

            cliente.IdCliente = Guid.NewGuid();
            return cliente;
        }
    }
}
