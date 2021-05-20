using ClaseExterna;
using Xunit;

namespace UnitTestBasics.Tests
{
    public class Primos_Should
    {
        [Fact]
        public void ValidarQueEsPrimo() 
        {
            //Arrange
            var numeroAValidar = 11;
            var sut = new Primos();

            //Act
            var respuesta = sut.esPrimo(numeroAValidar);

            //Assert
            Assert.True(respuesta);
        }

        [Fact]
        public void ValidarQueNoEsPrimo()
        {
            var numeroAValidar = 10;
            var sut = new Primos();
            var respuesta = sut.esPrimo(numeroAValidar);
            Assert.False(respuesta);
        }
    }
}
