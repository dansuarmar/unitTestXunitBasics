using System;
using System.Collections.Generic;
using System.Text;

namespace ClaseExterna.LooseCoupling
{
    public class Mensaje
    {
        public Guid IdMensaje { get; set; }
        public Guid IdCliente { get; set; }
        public DateTime FechaMensaje { get; set; }
        public string EMailCliente { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public bool Enviado { get; set; }
    }
}
