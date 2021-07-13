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
            var idCliente = Guid.NewGuid();
            var titulo = "Bienvenido a nuestro Servicio.";
            var contenido = "Hola. Muchas gracias por usar nuestro servicio.";

            var sut = new MensajesClientesService(msgRepo);

            //Act
            var respuesta = sut.AddMensaje(idCliente, titulo, contenido);

            //Assert
            Assert.Equal(titulo, respuesta.Titulo);
            Assert.Equal(contenido, respuesta.Contenido);
            Assert.Equal(idCliente, respuesta.IdCliente);
            Assert.True(respuesta.Enviado);
        }
    }
}
