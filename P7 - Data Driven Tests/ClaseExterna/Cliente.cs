using System;

namespace ClaseExterna
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string EMail { get; set; }
        public bool EnviarCorreos { get; set; }
    }
}
