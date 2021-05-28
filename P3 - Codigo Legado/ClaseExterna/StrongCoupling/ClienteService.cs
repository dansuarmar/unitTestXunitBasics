using System;

namespace ClaseExterna.StrongCoupling
{
    public class ClienteService
    {
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