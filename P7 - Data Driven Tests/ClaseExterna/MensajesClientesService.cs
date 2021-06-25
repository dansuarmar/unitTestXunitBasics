using System;
using System.Collections.Generic;

namespace ClaseExterna
{
    public class MensajesClientesService
    {
        //MensajesClientesService.cs
        IClienteService clienteService;
        ICorreosService correosService;
        IMensajeRepository mensajesRepository;

        //Primer Constructor
        public MensajesClientesService() 
        {
            clienteService = new ClienteService();
            correosService = new CorreosService();
            mensajesRepository = new MensajeRepository();
        }

        //Segundo Constructor
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

            var cliente = clienteService.GetCliente(IdCliente);
            msgRes.EMailCliente = cliente.EMail;

            if (cliente.EnviarCorreos && !String.IsNullOrWhiteSpace(cliente.EMail))
            {
                try
                {
                    correosService.Send(msgRes.EMailCliente, msgRes.Titulo, msgRes.Contenido);
                    msgRes.Enviado = true;
                }
                catch 
                {
                    msgRes.Enviado = false;
                }
            }
            else
                msgRes.Enviado = false;

            mensajesRepository.Add(msgRes);

            return msgRes;
        }
    }
}
