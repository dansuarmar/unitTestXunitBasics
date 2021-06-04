using System;

namespace ClaseExterna.LooseCoupling
{
    //ClienteRepository.cs
    public class ClienteRepository : IClientRepository
    {
        public Cliente Add(Cliente cliente)
        {
            if (cliente.IdCliente == Guid.Empty)
                cliente.IdCliente = Guid.NewGuid();
            //Operaciones para conexión y extracción de la Base de Datos

            return cliente;
        }
    }
}