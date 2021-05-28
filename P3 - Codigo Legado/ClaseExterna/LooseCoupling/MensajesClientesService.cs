using System;
using System.Collections.Generic;

namespace ClaseExterna.LooseCoupling
{
    public class MensajesClientesService
    {
        //MensajesClientesService.cs
        IClienteService clienteService;
        ICorreosService correosService;
        IMensajeRepository mensajesRepository;

        public MensajesClientesService() 
        {
            clienteService = new ClienteService();
            correosService = new CorreosService();
            mensajesRepository = new MensajeRepository();
        }

        public MensajesClientesService(IClienteService clnSrv, ICorreosService corSrv, IMensajeRepository msgRep) 
        {
            clienteService = clnSrv;
            correosService = corSrv;
            mensajesRepository = msgRep;
        }

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

            //var clienteService = new ClienteService();
            var cliente = clienteService.GetCliente(IdCliente);
            msgRes.EMailCliente = cliente.EMail;

            if (cliente.EnviarCorreos)
            {
                //var servicioCorreos = new CorreosService();
                msgRes.Enviado = correosService.Send(msgRes.EMailCliente, msgRes.Titulo, msgRes.Contenido);
            }
            else
                msgRes.Enviado = false;

            //var mensajesRepository = new MensajeRepository();
            mensajesRepository.Add(msgRes);

            return msgRes;
        }
    }
}
