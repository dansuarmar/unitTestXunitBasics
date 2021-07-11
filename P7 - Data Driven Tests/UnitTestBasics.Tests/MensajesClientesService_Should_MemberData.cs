using System;
using Xunit;
using UnitTestBasics.Tests.Mocks;
using ClaseExterna;
using System.Collections.Generic;
using UnitTestBasics.Tests.TestData;

namespace UnitTestBasics.Tests
{
    //MensajesClientes_Should_MemberData.cs
    public class MensajesClientesService_Should_MemberData
    {
        ClienteServiceMock clnSrvMock;
        CorreosServiceMock corSrvMock;
        MensajeRepositoryMock msgRepo;

        public MensajesClientesService_Should_MemberData()
        {
            clnSrvMock = new ClienteServiceMock(MensajeClientesTestData.Clientes);
            corSrvMock = new CorreosServiceMock(true);
            msgRepo = new MensajeRepositoryMock();
        }

        [Theory]
        [MemberData(nameof(MensajeClientesTestData.TestData), MemberType = typeof(MensajeClientesTestData))]
        public void AgregarMensaje_HappyPath(Guid clienteId, bool seEnvioCorreo)
        {
            //Arrange
            var titulo = "Bienvenido a nuestro Servicio.";
            var contenido = "Hola. Muchas gracias por usar nuestro servicio.";

            var sut = new MensajesClientesService(clnSrvMock, corSrvMock, msgRepo);

            //Act
            var respuesta = sut.AddMensaje(clienteId, titulo, contenido);

            //Assert
            Assert.Equal(titulo, respuesta.Titulo);
            Assert.Equal(contenido, respuesta.Contenido);
            Assert.Equal(clienteId, respuesta.IdCliente);
            Assert.Equal(seEnvioCorreo, respuesta.Enviado);
        }
    }
}
