using System;

namespace ClaseExterna.StrongCoupling
{
    //ClienteService.cs
    public class ClienteService
    {
        public Cliente AddCliente(Cliente cliente) 
        {
            if(String.IsNullOrWhiteSpace(cliente.Nombre) || String.IsNullOrWhiteSpace(cliente.Apellido))
                throw new Exception("El nombre o apellido no puede estar vacio.");

            if (!ValidadorEmailHelper.EsValido(cliente.EMail))
                throw new Exception("El correo electrónico agregado no es valido.");

            var clienteRepo = new ClienteRepository();

            return clienteRepo.Add(cliente);
        }

        public Cliente GetCliente(Guid IdCliente)
        {
            //Código para recuperar el cliente del repositorio.
            return new Cliente()
            {
                IdCliente = IdCliente,
                Nombre = "Pedro",
                Apellido = "Paramo",
                EMail = "pedro.paramo@juanrulfo.com",
                EnviarCorreos = true,
            };
        }
    }
}