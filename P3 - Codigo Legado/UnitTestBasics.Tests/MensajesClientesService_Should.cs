using System;
using Xunit;
using UnitTestBasics.Tests.Mocks;
using ClaseExterna.LooseCoupling;

namespace UnitTestBasics.Tests
{
    //MensajesClientes_Should.cs
    public class MensajesClientesService_Should
    {
        [Fact]
        public void AgregarMensaje_HappyPath()
        {
            //Arrange
            var clnSrvMock = new ClienteServiceMock(true);
            var corSrvMock = new CorreosServiceMock(true);
            var msgRepo = new MensajeRepositoryMock();

            var idCliente = Guid.NewGuid();
            var titulo = "Bienvenido a nuestro Servicio.";
            var contenido = "Hola. Muchas gracias por usar nuestro servicio.";

            var sut = new MensajesClientesService(clnSrvMock, corSrvMock, msgRepo);

            //Act
            var respuesta = sut.AddMensaje(idCliente, titulo, contenido);

            //Assert
            Assert.Equal(titulo, respuesta.Titulo);
            Assert.Equal(contenido, respuesta.Contenido);
            Assert.Equal(idCliente, respuesta.IdCliente);
            Assert.NotEmpty(respuesta.EMailCliente);
            Assert.True(respuesta.Enviado);
        }

        [Fact]
        public void AgregarMensaje_ExcepcionCorreos()
        {
            //Arrange
            var clnSrvMock = new ClienteServiceMock(true);
            var corSrvMock = new CorreosServiceMock(false);
            var msgRepo = new MensajeRepositoryMock();

            var idCliente = Guid.NewGuid();
            var titulo = "Bienvenido a nuestro Servicio.";
            var contenido = "Hola. Muchas gracias por usar nuestro servicio.";

            var sut = new MensajesClientesService(clnSrvMock, corSrvMock, msgRepo);

            //Act
            var respuesta = sut.AddMensaje(idCliente, titulo, contenido);

            //Assert
            Assert.False(respuesta.Enviado);
        }

        [Fact]
        public void AgregarMensaje_ClienteNoCorreos()
        {
            //Arrange
            var clnSrvMock = new ClienteServiceMock(true);
            var corSrvMock = new CorreosServiceMock(false);
            var msgRepo = new MensajeRepositoryMock();

            var idCliente = Guid.NewGuid();
            var titulo = "Bienvenido a nuestro Servicio.";
            var contenido = "Hola. Muchas gracias por usar nuestro servicio.";

            var sut = new MensajesClientesService(clnSrvMock, corSrvMock, msgRepo);

            //Act
            var respuesta = sut.AddMensaje(idCliente, titulo, contenido);

            //Assert
            Assert.False(respuesta.Enviado);
        }
    }
}
