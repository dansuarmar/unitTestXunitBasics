using Xunit;
using ClaseExterna.LooseCoupling;

namespace UnitTestBasics.Tests
{
    //MensajesClientes_Should.cs
    public class MensajesClientes_Should
    {
        [Fact]
        public void ValidarCrearSaluodosClientes() 
        {
            //Arrange
            var repoMock = new ClientesRepositoryMock();
            var sut = new MensajesClientes(repoMock);

            //Act
            var listaMensajes = sut.CrearSaludosClientes();

            //Assert
            Assert.NotEmpty(listaMensajes);
        }
    }
}
