using System;

namespace ClaseExterna.LooseCoupling
{
    //ClienteService.cs
    public class ClienteService
    {
        IValidadorEmailHelperProxy validador;
        IClientRepository clienteRepo;

        public ClienteService()
        {
            validador = new ValidadorEmailHelperProxy();
            clienteRepo = new ClienteRepository();
        }

        public ClienteService(IValidadorEmailHelperProxy validadorMail, IClientRepository clienteRepository) 
        {
            validador = validadorMail;
            clienteRepo = clienteRepository;
        }

        public Cliente AddCliente(Cliente cliente) 
        {
            if(String.IsNullOrWhiteSpace(cliente.Nombre) || String.IsNullOrWhiteSpace(cliente.Apellido))
                throw new Exception("El nombre o apellido no puede estar vacio.");

            if (!validador.EsValido(cliente.EMail)) 
                throw new Exception("El correo electrónico agregado no es valido.");

            return clienteRepo.Add(cliente);
        }
    }
}