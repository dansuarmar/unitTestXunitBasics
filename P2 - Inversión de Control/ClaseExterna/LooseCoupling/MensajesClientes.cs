using System.Collections.Generic;

namespace ClaseExterna.LooseCoupling
{
    //MensajesClientes.cs
    public class MensajesClientes
    {
        IClientesRepository _clientesRepository; //Interfaz en vez de clase.

        public MensajesClientes(IClientesRepository clienteRepository) //Interfaz en vez de clase.
        {
            _clientesRepository = clienteRepository;
        }

        public List<string> CrearSaludosClientes()
        {
            var clientes = _clientesRepository.GetAll();
            var resuesta = new List<string>();
            foreach (var cliente in clientes) 
            {
                var mensaje = "Hola " + cliente.Nombre + " " + cliente.Apellido;
                resuesta.Add(mensaje);
            }
            return resuesta;
        }
    }
}
