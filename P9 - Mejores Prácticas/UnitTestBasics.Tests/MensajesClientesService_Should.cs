using System;
using Xunit;
using Moq;
using ClaseExterna;
using System.Collections.Generic;

namespace UnitTestBasics.Tests
{
    //MensajesClientes_Should.cs
    public class MensajesClientesService_Should
    {
        Mock<MensajeRepository> msgRepoMock;

        public MensajesClientesService_Should() 
        {
            msgRepoMock.Setup(x => x.Add(It.IsAny<Mensaje>())).Returns(
                (Mensaje mensaje) =>
                {
                    mensaje.IdMensaje = Guid.NewGuid();
                    return mensaje;
                });
        }

        [Fact]
        public void AgregarMensaje_HappyPath()
        {
            //Arrange
            var idCliente = Guid.NewGuid();
            var titulo = "Bienvenido a nuestro Servicio.";
            var contenido = "Hola. Muchas gracias por usar nuestro servicio.";

            var sut = new MensajesClientesService(msgRepoMock.Object);

            //Act
            var respuesta = sut.AddMensaje(idCliente, titulo, contenido);

            //Assert
            msgRepoMock.Verify(mock => mock.Add(It.IsAny<Mensaje>()), Times.Once);
            Assert.NotEqual(Guid.Empty, respuesta.IdCliente);
            Assert.Equal(titulo, respuesta.Titulo);
            Assert.Equal(contenido, respuesta.Contenido);
            Assert.Equal(idCliente, respuesta.IdCliente);
            Assert.True(respuesta.Enviado);
        }

        [Fact]
        public void AgregarMensaje_Excepcion()
        {
            //Arrange
            var sut = new MensajesClientesService(msgRepoMock.Object);

            //Act and Assert
            var excp = Assert.Throws<Exception>(() => sut.AddMensaje(Guid.NewGuid(), null, null));
            Assert.Equal("Titulo no puede ser null", excp.Message);
        }
    }
}
