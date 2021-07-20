using System;

namespace ClaseExterna
{
    //MensajeRepository.cs
    public class MensajeRepository
    {
        public virtual Mensaje Add(Mensaje mensaje)
        {
            //Operaciones a la Base de Datos
            return mensaje;
        }
    }
}