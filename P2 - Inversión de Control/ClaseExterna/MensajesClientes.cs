using System.Collections.Generic;
using ClaseExterna.StrongCoupling;

//MensajesClientes.cs
namespace ClaseExterna
{
    public class MensajesClientes
    {
        public List<string> CrearSaludosClientes()
        {
            var clienteRepository = new ClientesRepository();
            var clientes = clienteRepository.GetAll();
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
