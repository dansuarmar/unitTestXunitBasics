using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Data.Entity.Infrastructure;
using unitTestXunitBasics.Data;
using unitTestXunitBasics.Model;
using unitTestXunitBasics.Controllers;

namespace unitTestXunitBasics_Tests
{
    public class ClientesController_Should
    {
        ApplicationDbContext context;

        public ClientesController_Should()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            context = new ApplicationDbContext(options);
            context.Clientes.Add(
                new Cliente()
                {
                    Nombre = "Pedro",
                    Apellido = "Paramo",
                    EMail = "pedro.paramo@juanrulfo.com",
                    EnviarCorreos = true,
                });
            context.Clientes.Add(
                new Cliente()
                {
                    Nombre = "Juan",
                    Apellido = "Preciado",
                    EMail = "juan.preciado@juanrulfo.com",
                    EnviarCorreos = true,
                });
            context.SaveChangesAsync();
        }

        [Fact]
        public async void GetClientes_Test()
        {
            //Arrange
            var sut = new ClientesController(context);

            //Act
            var resp = await sut.GetClientes();
            var respList = resp.Value;

            //Assert
            Assert.NotNull(resp.Value);
            foreach (var cliente in respList)
                Assert.NotEqual(Guid.Empty, cliente.IdCliente);
        }

        [Fact]
        public async void PutCliente_Test()
        {
            //Arrange
            var sut = new ClientesController(context);
            var clienteACambiar = context.Clientes.FirstOrDefault();
            clienteACambiar.Nombre = "Nuevo Nombre";
            clienteACambiar.Apellido = "Nuevo Apellido";

            //Act
            var resp = await sut.PutCliente(clienteACambiar.IdCliente, clienteACambiar);
            var respAsResult = (NoContentResult)resp;
            var clienteCambiado = context.Clientes.First(m => m.IdCliente == clienteACambiar.IdCliente);

            //Assert
            Assert.NotNull(respAsResult);
            Assert.Equal(204, respAsResult.StatusCode);
            Assert.Equal("Nuevo Nombre", clienteCambiado.Nombre);
            Assert.Equal("Nuevo Apellido", clienteCambiado.Apellido);
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
            var sut = new ClientesController(context);

            //Act
            var resp = await sut.PostCliente(newCliente);
            var respValue = (CreatedAtActionResult)resp.Result;
            var respCln = (Cliente)respValue.Value;

            //Assert
            Assert.NotNull(respValue.Value);
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
            var sut = new ClientesController(context);
            var clienteABorrar = context.Clientes.FirstOrDefault();

            //Act
            var resp = await sut.DeleteCliente(clienteABorrar.IdCliente);
            var respAsResult = (NoContentResult)resp;
            var clienteBorrado = context.Clientes.FirstOrDefault(m => m.IdCliente == clienteABorrar.IdCliente);

            //Assert
            Assert.NotNull(respAsResult);
            Assert.Equal(204, respAsResult.StatusCode);
            Assert.Null(clienteBorrado);
        }
    }
}
