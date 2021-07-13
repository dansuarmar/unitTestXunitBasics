using System;
using Xunit;
using Moq;
using ClaseExterna;
using System.Collections.Generic;

namespace UnitTestBasics.Tests
{
    //MensajesClientes_Should_Inline.cs
    public class MensajesClientesService_Should_Inline
    {    
        [Fact]
        public void AgregarMensaje_HappyPath(int arrayId, bool seEnvioCorreo)
        {
            //Arrange
            var idCliente = clientes[arrayId].IdCliente;
            var titulo = "Bienvenido a nuestro Servicio.";
            var contenido = "Hola. Muchas gracias por usar nuestro servicio.";

            var sut = new MensajesClientesService(clnSrvMock, corSrvMock, msgRepo);

            //Act
            var respuesta = sut.AddMensaje(idCliente, titulo, contenido);

            //Assert
            Assert.Equal(titulo, respuesta.Titulo);
            Assert.Equal(contenido, respuesta.Contenido);
            Assert.Equal(idCliente, respuesta.IdCliente);
            Assert.Equal(seEnvioCorreo, respuesta.Enviado);
        }
    }
}
