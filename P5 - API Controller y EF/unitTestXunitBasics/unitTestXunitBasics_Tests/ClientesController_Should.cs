using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using unitTestXunitBasics.Data;
using unitTestXunitBasics.Model;
using unitTestXunitBasics.Controllers;

namespace unitTestXunitBasics_Tests
{
    //ClientesController_Should.cs
    public class ClientesController_Should
    {
        readonly ApplicationDbContext _context;

        public ClientesController_Should()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            _context = new ApplicationDbContext(options);
            _context.Clientes.Add(
                new Cliente()
                {
                    Nombre = "Pedro",
                    Apellido = "Paramo",
                    EMail = "pedro.paramo@juanrulfo.com",
                    EnviarCorreos = true,
                });
            _context.Clientes.Add(
                new Cliente()
                {
                    Nombre = "Juan",
                    Apellido = "Preciado",
                    EMail = "juan.preciado@juanrulfo.com",
                    EnviarCorreos = true,
                });
            _context.SaveChangesAsync();
        }

        [Fact]
        public async void GetClientes_Test()
        {
            //Arrange
            var sut = new ClientesController(_context);

            //Act
            var resp = await sut.GetClientes();

            //Assert
            Assert.NotEmpty(resp.Value);
        }

        [Fact]
        public async void PutCliente_Test()
        {
            //Arrange
            var sut = new ClientesController(_context);
            var clienteACambiar = _context.Clientes.FirstOrDefault();
            clienteACambiar.Nombre = "Nuevo Nombre";
            clienteACambiar.Apellido = "Nuevo Apellido";
            clienteACambiar.EMail = "nuevo@corre.com";
            clienteACambiar.EnviarCorreos = true;

            //Act
            var resp = await sut.PutCliente(clienteACambiar.IdCliente, clienteACambiar);
            var respAsResult = (NoContentResult)resp;

            //Assert
            var clienteCambiado = _context.Clientes.First(m => m.IdCliente == clienteACambiar.IdCliente);
            Assert.Equal(204, respAsResult.StatusCode);
            Assert.Equal("Nuevo Nombre", clienteCambiado.Nombre);
            Assert.Equal("Nuevo Apellido", clienteCambiado.Apellido);
            Assert.Equal("nuevo@corre.com", clienteCambiado.EMail);
            Assert.True(clienteACambiar.EnviarCorreos);
        }

        [Fact]
        public async void PostCliente_Test()
        {
            //Arrange
            var newCliente = new Cliente()
            {
                Nombre = "Juan",
                Apellido = "Rulfo",
                EMail = "juan.rulfo@juanrulfo.com",
                EnviarCorreos = true,
            };
            var sut = new ClientesController(_context);

            //Act
            var resp = await sut.PostCliente(newCliente);
            var respValue = (CreatedAtActionResult)resp.Result;
            var respCln = (Cliente)respValue.Value;

            //Assert
            Assert.Equal(201, respValue.StatusCode);
            Assert.NotEqual(Guid.Empty, respCln.IdCliente); //Aqui estamos asumiendo funcionamiento que no es del controlador.
            Assert.Equal(newCliente.Nombre, respCln.Nombre);
            Assert.Equal(newCliente.Apellido, respCln.Apellido);
            Assert.Equal(newCliente.EMail, respCln.EMail);
            Assert.Equal(newCliente.EnviarCorreos, respCln.EnviarCorreos);
        }

        [Fact]
        public async void DeleteCliente_Test()
        {
            //Arrange
            var sut = new ClientesController(_context);
            var clienteABorrar = _context.Clientes.FirstOrDefault();

            //Act
            var resp = await sut.DeleteCliente(clienteABorrar.IdCliente);
            var respAsResult = (NoContentResult)resp;

            //Assert
            Assert.Equal(204, respAsResult.StatusCode);
            var clienteBorrado = _context.Clientes.FirstOrDefault(m => m.IdCliente == clienteABorrar.IdCliente);
            Assert.Null(clienteBorrado);
        }
    }
}
