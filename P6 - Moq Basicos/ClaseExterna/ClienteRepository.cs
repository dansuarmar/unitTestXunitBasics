using System;
using System.Linq;

namespace ClaseExterna
{
    //ClienteRepository.cs
    public class ClienteRepository
    {
        public ClienteRepository()
        {
            //throw new NotImplementedException();
        }

        public virtual Guid IdUltimoCliente { get; private set; }


        public virtual Cliente Add(Cliente cliente)
        {
            this.IdUltimoCliente = Guid.NewGuid();
            throw new NotImplementedException();
        }

        public virtual IQueryable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}