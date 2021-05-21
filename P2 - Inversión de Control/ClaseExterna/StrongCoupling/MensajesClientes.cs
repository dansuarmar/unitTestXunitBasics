using System.Collections.Generic;

namespace ClaseExterna.StrongCoupling
{
    public class MensajesClientes
    {
        ClientesRepository _clientesRepository;

        public MensajesClientes(ClientesRepository clienteRepository) 
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
