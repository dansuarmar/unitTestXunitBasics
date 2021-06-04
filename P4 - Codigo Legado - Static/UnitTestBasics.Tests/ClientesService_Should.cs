using System;
using Xunit;
using UnitTestBasics.Tests.Mocks;
using ClaseExterna.LooseCoupling;

namespace UnitTestBasics.Tests
{
    //MensajesClientes_Should.cs
    public class ClientesService_Should
    {
        [Fact]
        public void AgregarCliente_HappyPath()
        {
            //Arrange
            var emailValidador = new ValidadorEmailHelperProxyMock(true);
            var clnRepo = new ClienteRepositoryMock(false);

            var cliente = new Cliente() 
            {
                Nombre = "Pedro",
                Apellido = "Paramo",
                EMail = "pedro.paramo@juanrulfo.com",
            };

            var sut = new ClienteService(emailValidador, clnRepo);

            //Act
            var respuesta = sut.AddCliente(cliente);

            //Assert
            Assert.NotEqual(respuesta.IdCliente, Guid.Empty);
        }
    }
}
