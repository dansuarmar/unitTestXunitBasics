using System;
using Xunit;
using ClaseExterna;

namespace UnitTestBasics.Tests
{
    //MensajesClientes_Should.cs
    public class ClientesService_SinMoq_Should
    {
        [Fact]
        public void AgregarCliente_HappyPath()  // Sin Moq no hay manera de probar porque ClienteRepository truena.
        {
            //Arrange
            var clnRepo = new ClienteRepository();
            var sut = new ClienteService(clnRepo);
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
            Assert.Equal(resp.IdCliente, sut.IdUltimoCliente);
        }
    }
}
