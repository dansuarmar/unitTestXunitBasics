using System;
using Xunit;
using Moq;
using ClaseExterna;
using System.Collections.Generic;

namespace UnitTestBasics.Tests
{
    //MensajesClientes_Should_Inline.cs
    public class MensajesClientesService_Should
    {
        [Fact]
        public void AgregarMensaje_HappyPath()
        {
            //Arrange
            var msgRepoMock = new Mock<MensajeRepository>();
            msgRepoMock.Setup(x => x.Add(It.IsAny<Mensaje>())).Returns(
                (Mensaje mensaje) => 
                {
                    mensaje.IdMensaje = Guid.NewGuid();
                    return mensaje;
                });

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
            var msgRepoMock = new Mock<MensajeRepository>();
            msgRepoMock.Setup(x => x.Add(It.IsAny<Mensaje>())).Returns(
                (Mensaje mensaje) =>
                {
                    mensaje.IdMensaje = Guid.NewGuid();
                    return mensaje;
                });

            var sut = new MensajesClientesService(msgRepoMock.Object);

            //Act and Assert
            var excp = Assert.Throws<Exception>(() => sut.AddMensaje(Guid.NewGuid(), null, null));
            Assert.Equal("Titulo no puede ser null", excp.Message);
        }

    }
}
