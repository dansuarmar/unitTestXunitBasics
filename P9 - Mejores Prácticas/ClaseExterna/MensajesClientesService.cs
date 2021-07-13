using System;
using System.Collections.Generic;

namespace ClaseExterna
{
    //MensajesClientesService.cs
    public class MensajesClientesService
    {
        MensajeRepository mensajesRepository;

        public MensajesClientesService(MensajeRepository msgRepo) 
        {
            mensajesRepository = msgRepo;
        }

        public Mensaje AddMensaje(Guid IdCliente, string Titulo, string Contenido) 
        {
            if (String.IsNullOrWhiteSpace(Titulo))
                throw new Exception("Titulo no puede ser null");

            var msgRes = new Mensaje()
            {
                IdCliente = IdCliente,
                Titulo = Titulo,
                Contenido = Contenido,
                IdMensaje = Guid.NewGuid(),
                FechaMensaje = DateTime.Now,
                Enviado = true,
            };

            mensajesRepository.Add(msgRes);

            return msgRes;
        }
    }
}
