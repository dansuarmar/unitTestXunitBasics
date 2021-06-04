using System;

namespace ClaseExterna.StrongCoupling
{
    //ClienteRepository.cs
    public class ClienteRepository
    {
        public ClienteRepository()
        {
        }

        public Cliente Add(Cliente cliente) 
        {
            if (cliente.IdCliente == Guid.Empty)
                cliente.IdCliente = Guid.NewGuid();
            //Operaciones para conexión y extracción de la Base de Datos

            return cliente;
        }
    }
}