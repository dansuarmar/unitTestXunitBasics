using System;
using System.Collections.Generic;
using System.Text;

namespace ClaseExterna.LooseCoupling
{
    //IClientesRepository.cs
    public interface IClientesRepository
    {
        public List<Cliente> GetAll();
    }
}
