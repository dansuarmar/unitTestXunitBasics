using System;

namespace ClaseExterna.LooseCoupling.OldV2
{
    //ClienteService.cs
    public class ClienteService
    {
        public Cliente AddCliente(Cliente cliente) 
        {
            if(String.IsNullOrWhiteSpace(cliente.Nombre) || String.IsNullOrWhiteSpace(cliente.Apellido))
                throw new Exception("El nombre o apellido no puede estar vacio.");

            var validador = new ValidadorEmailHelperProxy(); //Instanciamos el nuevo Proxy.
            if (!validador.EsValido(cliente.EMail)) 
                throw new Exception("El correo electrónico agregado no es valido.");

            var clienteRepo = new ClienteRepository();

            return clienteRepo.Add(cliente);
        }
    }
}