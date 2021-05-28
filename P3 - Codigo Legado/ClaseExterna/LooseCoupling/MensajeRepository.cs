using System;

namespace ClaseExterna.LooseCoupling
{
    public class MensajeRepository : IMensajeRepository
    {
        public Mensaje Add(Mensaje mensaje)
        {
            return mensaje;
        }
    }
}