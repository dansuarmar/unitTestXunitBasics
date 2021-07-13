using System;
using System.Collections.Generic;

namespace ClaseExterna
{
    //MensajesClientesService.cs
    public class MensajesClientesService
    {
        MensajeRepository mensajesRepository;

        public MensajesClientesService() 
        {
            mensajesRepository = new MensajeRepository();
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

            mensajesRepository.Add(msgRes);

            return msgRes;
        }
    }
}
