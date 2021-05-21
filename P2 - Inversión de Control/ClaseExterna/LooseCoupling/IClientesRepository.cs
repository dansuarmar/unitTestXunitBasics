using System;
using System.Collections.Generic;
using System.Text;

namespace ClaseExterna.LooseCoupling
{
    public interface IClientesRepository
    {
        public List<Cliente> GetAll();
    }
}
