using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClaseExterna.StrongCoupling
{
    public class ClientesRepository
    {
        List<Cliente> _clientes;

        public ClientesRepository()
        { 
            _clientes = new List<Cliente>()
            {
                new Cliente()
                {
                    Nombre = "Pedro",
                    Apellido = "Paramo",
                },
                new Cliente()
                {
                    Nombre = "Juan",
                    Apellido = "Rulfo",
                },
            };
        }

        public List<Cliente> GetAll()
        {
            return _clientes;
        }

        //public Cliente GetById(Guid idCliente) 
        //{
        //    return _clientes.FirstOrDefault(m => m.IdCliente == idCliente);
        //}
    }
}
