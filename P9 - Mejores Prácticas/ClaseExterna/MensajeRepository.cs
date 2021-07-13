using System;

namespace ClaseExterna
{
    public class MensajeRepository
    {
        public virtual Mensaje Add(Mensaje mensaje)
        {
            return mensaje;
        }
    }
}