using System;
using System.Collections.Generic;
using System.Text;
using ClaseExterna;

namespace UnitTestBasics.Tests.TestData
{
//MensajeClientesTestData.cs

public class MensajeClientesTestData
{
    public static readonly List<Cliente> Clientes = new List<Cliente>
    {
        new Cliente()
        {
            IdCliente = Guid.NewGuid(),
            EMail = "juan.rulfo@juanrulfo.com",
            EnviarCorreos = true,
        },
        new Cliente()
        {
            IdCliente = Guid.NewGuid(),
            EMail = "pedro.paramo@juanrulfo.com",
            EnviarCorreos = false,
        },
        new Cliente()
        {
            IdCliente = Guid.NewGuid(),
            EnviarCorreos = true,
        },
        new Cliente()
        {
            IdCliente = Guid.NewGuid(),
            EnviarCorreos = false,
        },
    };

    public static readonly IEnumerable<object[]> TestData = new List<object[]>
    {
        new object[] { Clientes[0].IdCliente, true },
        new object[] { Clientes[1].IdCliente, false },
        new object[] { Clientes[2].IdCliente, false },
        new object[] { Clientes[3].IdCliente, false },
    }; 
}
}
