using System;
using Xunit;
using Moq;

using unitTestXunitBasics.Data;
using unitTestXunitBasics.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace unitTestXunitBasics_Tests
{
    public class ClientesController_Should
    {
        List<Cliente> clientesDb;
        Guid idCln1 = Guid.NewGuid();
        Guid idCln2 = Guid.NewGuid();
        Mock<DbSet<Cliente>> clnDbSetMock;

        public ClientesController_Should()
        {
            clientesDb = new List<Cliente>();
            clientesDb.Add(new Cliente() 
            {
                IdCliente = idCln1,
                Nombre = "Pedro",
                Apellido = "Paramo",
                EMail = "pedro.paramo@juanrulfo.com",
                EnviarCorreos = true,
            });
            clientesDb.Add(new Cliente()
            {
                IdCliente = idCln2,
                Nombre = "Juan",
                Apellido = "Preciado",
                EMail = "juan.preciado@juanrulfo.com",
                EnviarCorreos = true,
            });

            var queryble = clientesDb.AsQueryable();

            clnDbSetMock.As<IQueryable<Cliente>>().Setup(m => m.Expression).Returns(queryble.Expression);
            clnDbSetMock.As<IQueryable<Cliente>>().Setup(m => m.ElementType).Returns(queryble.ElementType);
            clnDbSetMock.As<IQueryable<Cliente>>().Setup(m => m.GetEnumerator()).Returns(queryble.GetEnumerator);
        }

        [Fact]
        public void Test1()
        {
            var contextMock = new Mock<ApplicationDbContext>();
            //contextMock.Setup(x => x.Clientes.Add(It.IsAny<Cliente>()))
            //    .Returns((Cliente cliente) => cliente);
                //{
                //    cliente.IdCliente = Guid.NewGuid();
                //    clientesDb.Add(cliente);
                //    return cliente;
                //});
        }
    }
}
