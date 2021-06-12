using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace unitTestXunitBasics.Model
{
    //Cliente.cs
    public class Cliente
    {
        [Key]
        public Guid IdCliente { get; set; }

        [Required, MinLength(1), MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Apellido { get; set; }

        [Required, MinLength(1), MaxLength(320)]
        public string EMail { get; set; }

        [Required]
        public bool EnviarCorreos { get; set; }
    }
}
