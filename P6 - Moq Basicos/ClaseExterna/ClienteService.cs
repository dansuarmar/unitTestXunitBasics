using System;
using System.Linq;

namespace ClaseExterna
{
    //ClienteService.cs
    public class ClienteService
    {
        ClienteRepository clienteRepo;

        public ClienteService(ClienteRepository clienteRepository)
        {
            clienteRepo = clienteRepository;
        }

        public Guid IdUltimoCliente 
        {
            get { return clienteRepo.IdUltimoCliente; }
        }

        public Cliente AddCliente(Cliente cliente) 
        {
            if(String.IsNullOrWhiteSpace(cliente.Nombre) || String.IsNullOrWhiteSpace(cliente.Apellido))
                throw new Exception("El nombre o apellido no puede estar vacio.");

            var resp = clienteRepo.Add(cliente);
            return resp;
        }

        public IQueryable<Cliente> GetAll() 
        {
            return clienteRepo.GetAll();
        }
    }
}