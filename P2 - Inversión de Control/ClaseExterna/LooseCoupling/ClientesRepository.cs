using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClaseExterna.LooseCoupling
{
    public class ClientesRepository : IClientesRepository
    {
        public List<Cliente> GetAll()
        {
            //Aqui van los procesos para extraer de Base de Datos
            return new List<Cliente>();
        }
    }
}
