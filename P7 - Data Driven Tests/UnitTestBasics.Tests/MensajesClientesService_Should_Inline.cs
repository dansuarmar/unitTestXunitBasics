using System;
using Xunit;
using UnitTestBasics.Tests.Mocks;
using ClaseExterna;
using System.Collections.Generic;

namespace UnitTestBasics.Tests
{
    //MensajesClientes_Should_Inline.cs
    public class MensajesClientesService_Should_Inline
    {
        List<Cliente> clientes;
        ClienteServiceMock clnSrvMock;
        CorreosServiceMock corSrvMock;
        MensajeRepositoryMock msgRepo;

        public MensajesClientesService_Should_Inline() 
        {
            clientes = new List<Cliente>() 
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

            clnSrvMock = new ClienteServiceMock(clientes);
            corSrvMock = new CorreosServiceMock(true);
            msgRepo = new MensajeRepositoryMock();
        }


        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, false)]
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
