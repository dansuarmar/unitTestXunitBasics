using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using ClaseExterna;

namespace UnitTestBasics.Tests
{
    //ClientesService_ConMoq_Should.cs
    public class ClientesService_ConMoq_Should
    {
        [Fact]
        public void GetAll_HappyPath()
        {
            //Arrange
            var clnRepoMock = new Mock<ClienteRepository>();
            clnRepoMock.Setup(x => x.GetAll()).Returns(
                new List<Cliente>()
                {
                    new Cliente()
                    {
                        IdCliente = Guid.NewGuid(),
                        Nombre = "Juan",
                        Apellido = "Rulfo",
                        EMail = "juan.rulfo@juanrulfo.com",
                        EnviarCorreos = true,
                    },
                    new Cliente()
                    {
                        IdCliente = Guid.NewGuid(),
                        Nombre = "Pedro",
                        Apellido = "Paramo",
                        EMail = "pedro.paramo@juanrulfo.com",
                        EnviarCorreos = true,
                    },
                }.AsQueryable());

            var sut = new ClienteService(clnRepoMock.Object);

            //Act
            var resp = sut.GetAll();

            //Assert
            Assert.NotEmpty(resp);
        }

        [Fact] 
        public void AgregarCliente_HappyPath()
        {
            //Arrange
            var idCliente = Guid.NewGuid();
            var clnRepoMock = new Mock<ClienteRepository>();
            clnRepoMock.Setup(x => x.IdUltimoCliente).Returns(idCliente);
            clnRepoMock.Setup(x => x.Add(It.IsAny<Cliente>())).Returns(
                (Cliente cliente) =>
                {
                    cliente.IdCliente = idCliente;
                    return cliente;
                });

            var sut = new ClienteService(clnRepoMock.Object);
            var cliente = new Cliente() 
            {
                Nombre = "Juan",
                Apellido = "Rulfo",
                EMail = "juan.rulfo@seidor.com",
                EnviarCorreos = true,
            };

            //Act
            var resp = sut.AddCliente(cliente);

            //Assert
            Assert.NotEqual(Guid.Empty, resp.IdCliente);
            Assert.Equal(idCliente, resp.IdCliente);
        }
    }
}
