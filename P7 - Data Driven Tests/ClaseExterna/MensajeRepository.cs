using System;

namespace ClaseExterna
{
    public class MensajeRepository : IMensajeRepository
    {
        public Mensaje Add(Mensaje mensaje)
        {
            return mensaje;
        }
    }
}