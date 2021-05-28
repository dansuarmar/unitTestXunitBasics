using System;
using System.Collections.Generic;

namespace ClaseExterna.StrongCoupling
{
    public class MensajesClientesService
    {
        //MensajesClientesService.cs
        public Mensaje AddMensaje(Guid IdCliente, string Titulo, string Contenido) 
        {
            var msgRes = new Mensaje()
            {
                IdCliente = IdCliente,
                Titulo = Titulo,
                Contenido = Contenido,
                IdMensaje = Guid.NewGuid(),
                FechaMensaje = DateTime.Now,
            };

            var clienteService = new ClienteService();
            var cliente = clienteService.GetCliente(IdCliente);
            msgRes.EMailCliente = cliente.EMail;

            if (cliente.EnviarCorreos)
            {
                try
                {
                    var servicioCorreos = new CorreosService();
                    servicioCorreos.Send(msgRes.EMailCliente, msgRes.Titulo, msgRes.Contenido);
                    msgRes.Enviado = true;
                }
                catch
                {
                    msgRes.Enviado = false;
                }
            }
            else
                msgRes.Enviado = false;

            var mensajesRepository = new MensajeRepository();
            mensajesRepository.Add(msgRes);

            return msgRes;
        }
    }
}
