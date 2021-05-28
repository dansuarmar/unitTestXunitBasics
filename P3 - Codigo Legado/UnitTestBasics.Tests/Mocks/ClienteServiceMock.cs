using System;
using System.Collections.Generic;
using ClaseExterna.LooseCoupling;

namespace UnitTestBasics.Tests.Mocks
{
    //ClienteServiceMock.cs
    public class ClienteServiceMock : IClienteService
    {
        bool _enviarCorreoConf;

        public ClienteServiceMock(bool enviarCorreoConf) 
        {
            _enviarCorreoConf = enviarCorreoConf;
        }

        public Cliente GetCliente(Guid IdCliente)
        {
            return new Cliente() 
            {
                IdCliente = IdCliente,
                EMail = "pedro.paramo@juanrulfo.com",
                Nombre = "Pedro",
                Apellido = "Paramo",
                EnviarCorreos = _enviarCorreoConf,
            };
        }
    }
}
